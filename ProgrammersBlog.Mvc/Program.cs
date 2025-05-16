// Import kütüphaneleri - ASP.NET Core, Entity Framework, NLog ve projenin diğer bileşenleri
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;
using NLog.Web;
using ProgrammersBlog.Data.Concrete.EntityFramework.Contexts;
using ProgrammersBlog.Entities.Concrete;
using ProgrammersBlog.Mvc.AutoMapper.Profiles;
using ProgrammersBlog.Mvc.Helpers.Abstract;
using ProgrammersBlog.Mvc.Helpers.Concrete;
using ProgrammersBlog.Services.Abstract;
using ProgrammersBlog.Services.AutoMapper.Profiles;
using ProgrammersBlog.Services.Concrete;
using ProgrammersBlog.Services.Extensions;
using ProgrammersBlog.Shared.Utilities.Extensions;
using System.Configuration;
using System.Text.Json.Serialization;

// Web uygulaması oluşturucu nesnesini tanımlama
var builder = WebApplication.CreateBuilder(args);


// Konfigürasyonu `builder.Configuration` üzerinden yapılandırıyoruz
builder.Configuration
    .SetBasePath(Directory.GetCurrentDirectory()) // Proje dizinine ayarlıyoruz
    .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
    .AddJsonFile($"appsettings.{builder.Environment.EnvironmentName}.json", optional: true, reloadOnChange: true)
    .AddEnvironmentVariables(); // Ortam değişkenlerini ekliyoruz

// Komut satırı argümanları varsa, onları da ekleyelim
if (args != null)
{
    builder.Configuration.AddCommandLine(args);
}


//--------------------------------- Service Configurations ------------------------------------ 
#region Service Tanımlamaları
// Loglama yapılandırması - NLog kullanılarak yapılandırılıyor
builder.Logging.ClearProviders();
builder.Logging.SetMinimumLevel(LogLevel.Information); // Minimum log seviyesi
builder.Host.UseNLog();



// 📌 Authentication yapılandırması aktif ediliyor
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(); // Cookie ile kimlik doğrulama

// Config ayarı // Hakkımızda
// AppSettings'ten konfigürasyon sınıflarına verileri bağlama
builder.Services.Configure<AboutUsPageInfo>(builder.Configuration.GetSection("AboutUsPageInfo"));
builder.Services.Configure<WebsiteInfo>(builder.Configuration.GetSection("WebsiteInfo"));
//Email ayarları
builder.Services.Configure<SmtpSettings>(builder.Configuration.GetSection("SmtpSettings"));

// Yazılabilir konfigürasyon sınıfları için ayarlar
builder.Services.ConfigureWritable<WebsiteInfo>(builder.Configuration.GetSection("WebsiteInfo"));
builder.Services.ConfigureWritable<SmtpSettings>(builder.Configuration.GetSection("SmtpSettings"));
builder.Services.ConfigureWritable<AboutUsPageInfo>(builder.Configuration.GetSection("AboutUsPageInfo"));
builder.Services.Configure<ArticleRightSideBarWidgetOptions>(builder.Configuration.GetSection("ArticleRightSideBarWidgetOptions"));
builder.Services.ConfigureWritable<ArticleRightSideBarWidgetOptions>(builder.Configuration.GetSection("ArticleRightSideBarWidgetOptions"));

// 📌 Veritabanı Bağlantısı
// - SQL Server kullanılıyor ve bağlantı dizesi "DefaultConnection" üzerinden alınıyor.
builder.Services.AddDbContext<ProgrammersBlogContext>(options =>
    options.UseSqlServer(
        builder.Configuration.GetConnectionString("DefaultConnection"),
        sqlServerOptions => sqlServerOptions.EnableRetryOnFailure(
            maxRetryCount: 5,
            maxRetryDelay: TimeSpan.FromSeconds(30),
            errorNumbersToAdd: null)));

// 📌 MVC ve Razor Runtime Compilation
// - Razor dosyalarında yapılan değişikliklerin anında yansımasını sağlamak için AddRazorRuntimeCompilation ekleniyor.
builder.Services.AddControllersWithViews(options =>
{
    options.ModelBindingMessageProvider.SetValueMustNotBeNullAccessor(
        _ => "Bu alan boş bırakılamaz.");
    options.Filters.Add<ProgrammersBlog.Mvc.Filters.MvcExceptionFilter>(); // Hata yönetimi için özel bir filtre ekleniyor
}).AddRazorRuntimeCompilation().AddJsonOptions(opt =>
{
    opt.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
    opt.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.Preserve;

}).AddNToastNotifyToastr();
builder.Services.AddSession();
// 📌 AutoMapper Konfigürasyonu
// - Program sınıfı üzerinden AutoMapper profillerinin yüklenmesini sağlıyor.
builder.Services.AddAutoMapper(typeof(CategoryProfile), typeof(ArticleProfile), typeof(UserProfile), typeof(ViewModelsProfile), typeof(CommentProfile), typeof(ArticleViewModelProfile));
// 📌 Servisleri Yükleme
// - LoadMyServices() metodu, Dependency Injection için özel servisleri eklemek için kullanılıyor.
builder.Services.LoadMyServices();
builder.Services.AddScoped<IImageHelper, ImageHelper>();
builder.Services.AddScoped<ILogService, LogService>();

// Çerez (Cookie) ayarları
builder.Services.ConfigureApplicationCookie(options =>
{
    // Kullanıcı login olmadığında yönlendirileceği sayfa
    options.LoginPath = new PathString("/Admin/Auth/Login");
    // 📝 Örnek: Kullanıcı /Admin birimine ulaşmaya çalıştığında login değilse bu sayfaya yönlendirilir.

    // Kullanıcı logout işlemi yaptığında çalışacak yol
    options.LogoutPath = new PathString("/Admin/Auth/Logout");
    // 📝 Örnek: Logout butonuna basıldığında kullanıcı bu path'e yönlendirilir.

    // Cookie ayarları yapılandırılıyor
    options.Cookie = new CookieBuilder
    {
        Name = "ProgrammersBlog", // Oluşturulan çerezin adı
        HttpOnly = true, // JavaScript ile erişilmesini engeller (güvenlik amaçlı)
        SameSite = SameSiteMode.Strict, // Çerez sadece aynı origin'den yapılan isteklerle gönderilir
        SecurePolicy = CookieSecurePolicy.None, // HTTPS üzerinden çalışmıyorsa çerez gönderilmez
        // 📝 Örnek: Saldırılara karşı daha güvenli bir çerez yapısı tanımlanmış olur
    };

    options.SlidingExpiration = true;
    // 📝 Oturum süresi kullanıcı her işlem yaptığında uzar. (kayan zamanlı oturum)
    // Örnek: 2. gün sistemde işlem yaparsa son kullanım 4 gün daha uzar.

    options.ExpireTimeSpan = System.TimeSpan.FromDays(4);
    // 📝 Oturum süresi 4 gün olarak ayarlanır. Kullanıcı işlem yapmazsa 4 gün sonra sistemden düşer.

    options.AccessDeniedPath = new PathString("/Admin/Auth/AccessDenied");
    // 📝 Kullanıcının yetkisi olmayan bir sayfaya erişmeye çalıştığında bu sayfaya yönlendirilir.
});


#endregion
//--------------------------------- Service Configurations ------------------------------------


// Uygulamayı oluştur
var app = builder.Build();

// Ortam kontrolü ve hata yönetimi ayarları
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseStatusCodePages();
    app.UseHsts();
}


// Middleware tanımlamaları - İstek işleme pipeline'ı
app.UseSession(); // Oturum yönetimi
//app.UseHttpsRedirection(); //bunu yayın zamanı aktif et.
app.UseStaticFiles(); // Statik dosyaları servis etme (CSS, JS, resim vb.)
app.UseRouting(); // Rota yönetimi 
app.UseAuthentication(); // Kimlik doğrulama
app.UseAuthorization(); // Yetkilendirme
app.UseNToastNotify(); // Bildirim sistemi

//--------------------------------- Route Tanımlamaları ------------------------------------ 
#region Route Açıklaması

// 📌 Neden Admin Route'u Önce Yazılmalı?
// - .NET Routing sistemi yukarıdan aşağıya doğru çalışır ve ilk eşleşen kurala göre yönlendirme yapar.
// - Eğer önce "default" route'u tanımlarsan, "/Admin/..." gibi bir istek geldiğinde önce 
//   "{controller=Home}/{action=Index}/{id?}" desenine bakar ve Admin Area'ya yönlendirme yapamayabilir.  
// - Bu yüzden, Admin alanı için özel bir route varsa, önce onu tanımlamak gerekir. 

#endregion

// 🛠 Admin Area Route (Öncelikli olmalı)

// Area route (Admin için)
app.MapAreaControllerRoute(
    name: "Admin",
    areaName: "Admin",
    pattern: "Admin/{controller=Home}/{action=Index}/{id?}");

// Home Area route (Eğer Home area kullanıyorsanız)
app.MapAreaControllerRoute(
    name: "Home",
    areaName: "Home",
    pattern: "Home/{controller=Home}/{action=Index}/{id?}");
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

// Varsayılan route (Area olmayan sayfalar için)
app.MapControllerRoute(
    name: "article",
                    pattern: "{title}/{articleId}",
                    defaults: new { controller = "Article", action = "Detail" }
                    );

//--------------------------------- Route Tanımlamaları ------------------------------------ 
// Uygulamayı başlat
app.Run();