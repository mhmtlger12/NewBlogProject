using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.Data.SqlClient;
using ProgrammersBlog.Entities.Concrete;
using ProgrammersBlog.Shared.Entities.Concrete;
using System;
using System.Data.SqlTypes;
using System.IO;
using System.Net;
using System.Security;
using System.Text;
using NLog;
using LogLevel = NLog.LogLevel;

namespace ProgrammersBlog.Mvc.Filters
{
    public class MvcExceptionFilter : IExceptionFilter
    {
        private readonly IHostEnvironment _environment;
        private readonly IModelMetadataProvider _metadataProvider;
        private readonly ILogger<MvcExceptionFilter> _logger;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public MvcExceptionFilter(
            IHostEnvironment environment,
            IModelMetadataProvider metadataProvider,
            ILogger<MvcExceptionFilter> logger,
            IHttpContextAccessor httpContextAccessor)
        {
            _environment = environment;
            _metadataProvider = metadataProvider;
            _logger = logger;
            _httpContextAccessor = httpContextAccessor;
        }

        public void OnException(ExceptionContext context)
        {
            var httpContext = _httpContextAccessor.HttpContext;
            var exceptionType = context.Exception.GetType().Name;
            var controllerName = context.RouteData.Values["controller"]?.ToString() ?? "Bilinmiyor";
            var actionName = context.RouteData.Values["action"]?.ToString() ?? "Bilinmiyor";
            var requestPath = httpContext?.Request.Path.ToString() ?? "Bilinmiyor";
            var requestMethod = httpContext?.Request.Method ?? "Bilinmiyor";
            var userAgent = httpContext?.Request.Headers["User-Agent"].ToString() ?? "Bilinmiyor";
            var clientIp = GetClientIpAddress(httpContext);
            var requestId = httpContext?.TraceIdentifier ?? Guid.NewGuid().ToString();

            // Kullanıcı bilgilerini alıyoruz
            var userId = httpContext?.User.Identity?.IsAuthenticated == true ?
                httpContext.User.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier)?.Value : "Anonim";
            var userName = httpContext?.User.Identity?.IsAuthenticated == true ?
                httpContext.User.Identity.Name : "Anonim";

            // QueryString bilgilerini alıyoruz
            var queryString = httpContext?.Request.QueryString.ToString() ?? string.Empty;

            // Browser bilgilerini basitçe alıyoruz
            string browserInfo = userAgent.Length > 150 ? userAgent.Substring(0, 150) : userAgent;

            // Request Body içeriğini almaya çalışıyoruz
            string requestBody = "Alınamadı";
            try
            {
                if (httpContext?.Request.Body != null && httpContext.Request.Body.CanSeek)
                {
                    httpContext.Request.Body.Position = 0;
                    using (var streamReader = new StreamReader(httpContext.Request.Body, Encoding.UTF8, leaveOpen: true))
                    {
                        requestBody = streamReader.ReadToEndAsync().Result;
                        httpContext.Request.Body.Position = 0;
                    }
                }
            }
            catch (Exception)
            {
                requestBody = "Body okunamadı";
            }

            // HTTP durum kodunu belirliyoruz
            int statusCode = 500;
            string errorMessage = "Beklenmeyen bir hata oluştu.";

            if (context.Exception is SqlNullValueException || context.Exception is SqlException)
            {
                statusCode = 500;
                errorMessage = "Veritabanı hatası oluştu.";
            }
            else if (context.Exception is NullReferenceException)
            {
                statusCode = 500;
                errorMessage = "Null referans hatası oluştu.";
            }
            else if (context.Exception is SecurityException || context.Exception is UnauthorizedAccessException)
            {
                statusCode = 403;
                errorMessage = "Yetki hatası oluştu.";
            }
            else if (context.Exception is InvalidOperationException || context.Exception is ArgumentException)
            {
                statusCode = 400;
                errorMessage = "Geçersiz işlem hatası oluştu.";
            }
            else if (context.Exception is TimeoutException)
            {
                statusCode = 408;
                errorMessage = "Zaman aşımı hatası oluştu.";
            }
            else if (context.Exception is IOException)
            {
                statusCode = 500;
                errorMessage = "Dosya işlemi hatası oluştu.";
            }

            // Detaylı log mesajı oluşturma
            var logMessage = new StringBuilder();
            logMessage.AppendLine($"======== HATA RAPORU [{DateTime.Now:yyyy-MM-dd HH:mm:ss}] ========");
            logMessage.AppendLine($"HATA TÜRÜ: {exceptionType}");
            logMessage.AppendLine($"MESAJ: {context.Exception.Message}");
            logMessage.AppendLine();
            logMessage.AppendLine("------- İSTEK BİLGİLERİ -------");
            logMessage.AppendLine($"Controller/Action: {controllerName}/{actionName}");
            logMessage.AppendLine($"URL: {requestMethod} {requestPath}{queryString}");
            logMessage.AppendLine($"Durum Kodu: {statusCode}");
            logMessage.AppendLine($"İstek ID: {requestId}");
            logMessage.AppendLine();
            logMessage.AppendLine("------- KULLANICI BİLGİLERİ -------");
            logMessage.AppendLine($"Kullanıcı: {userName} (ID: {userId})");
            logMessage.AppendLine($"IP Adresi: {clientIp}");
            logMessage.AppendLine($"Tarayıcı: {browserInfo}");
            logMessage.AppendLine();
            logMessage.AppendLine("------- HATA AYIKLAMA BİLGİLERİ -------");
            logMessage.AppendLine("Stack İzi:");
            logMessage.AppendLine(context.Exception.StackTrace);
            logMessage.AppendLine("================================================");

            // NLog LogEventInfo oluşturarak özel alanları ekleyelim
            var logEvent = new LogEventInfo(LogLevel.Error, _logger.GetType().FullName, logMessage.ToString());
            logEvent.Exception = context.Exception;

            // Eksik alanları Properties koleksiyonuna ekle
            logEvent.Properties["ExceptionType"] = exceptionType;
            logEvent.Properties["Browser"] = browserInfo;
            logEvent.Properties["RequestQueryString"] = queryString;
            logEvent.Properties["StatusCode"] = statusCode;

            // Diğer alanları da NLog'a gönder
            logEvent.Properties["Controller"] = controllerName;
            logEvent.Properties["Action"] = actionName;
            logEvent.Properties["UserId"] = userId;
            logEvent.Properties["UserName"] = userName;
            logEvent.Properties["RequestPath"] = requestPath;
            logEvent.Properties["RequestMethod"] = requestMethod;
            logEvent.Properties["ClientIp"] = clientIp;
            logEvent.Properties["UserAgent"] = userAgent;
            logEvent.Properties["RequestId"] = requestId;
            logEvent.Properties["RequestBody"] = requestBody;

            // LogManager üzerinden doğrudan NLog'a gönder
            LogManager.GetCurrentClassLogger().Log(logEvent);

            // Kullanıcıya gösterilecek hata sayfasını hazırlıyoruz
            if (_environment.IsDevelopment() || _environment.IsStaging())
            {
                context.ExceptionHandled = true;
                var mvcErrorModel = new MvcErrorModel
                {
                    Message = errorMessage,
                    Detail = context.Exception.Message,
                    ErrorCode = statusCode.ToString(),
                    RequestId = requestId,
                    StackTrace = _environment.IsDevelopment() ? context.Exception.StackTrace : null
                };

                var result = new ViewResult
                {
                    ViewName = "Error",
                    StatusCode = statusCode
                };

                result.ViewData = new ViewDataDictionary(_metadataProvider, context.ModelState);
                result.ViewData.Add("MvcErrorModel", mvcErrorModel);
                context.Result = result;
            }
        }

        private string GetClientIpAddress(HttpContext httpContext)
        {
            if (httpContext == null)
                return "Bilinmiyor";

            // X-Forwarded-For header'ını kontrol et (Load balancer, proxy arkasında çalışıyorsa)
            string ip = httpContext.Request.Headers["X-Forwarded-For"].ToString();

            // Header boşsa doğrudan IP adresini al
            if (string.IsNullOrEmpty(ip))
            {
                ip = httpContext.Connection.RemoteIpAddress?.ToString();
            }
            else
            {
                // X-Forwarded-For birden fazla IP içerebilir, ilk IP'yi al
                ip = ip.Split(',')[0].Trim();
            }

            return string.IsNullOrEmpty(ip) ? "Bilinmiyor" : ip;
        }
    }
}