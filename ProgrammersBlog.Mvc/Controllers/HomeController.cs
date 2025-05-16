using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using NToastNotify;
using ProgrammersBlog.Entities.Concrete;
using ProgrammersBlog.Entities.Dtos.Contacts;
using ProgrammersBlog.Mvc.Filters;
using ProgrammersBlog.Services.Abstract;
using ProgrammersBlog.Shared.Utilities.Helpers.Abstract;
using System.Data.SqlTypes;

namespace ProgrammersBlog.Mvc.Controllers
{
    [Route("/")]
    public class HomeController : Controller
    {
        private readonly IArticleService _articleService;
        private readonly IMenuService _menuService;
        private readonly AboutUsPageInfo _aboutUsPageInfo;
        private readonly IMailService _mailService;
        private readonly IToastNotification _toastNotification;
        private readonly ILogger<MvcExceptionFilter> _logger;
        private readonly IWritableOptions<AboutUsPageInfo> _aboutUsPageInfoWriter;

        public HomeController(IArticleService articleService, IMenuService menuService, IOptionsSnapshot<AboutUsPageInfo> aboutUsPageInfo, IMailService mailService, IToastNotification toastNotification, ILogger<MvcExceptionFilter> logger, IWritableOptions<AboutUsPageInfo> aboutUsPageInfoWriter)
        {
            _articleService = articleService;
            _menuService = menuService;
            _aboutUsPageInfo = aboutUsPageInfo.Value;
            _mailService = mailService;
            _toastNotification = toastNotification;
            _logger = logger;
            _aboutUsPageInfoWriter = aboutUsPageInfoWriter;
        }
        [Route("index")]
        [Route("anasayfa")]
        [Route("")]
        [HttpGet]
        public async Task<IActionResult> Index(Guid? menuId, int currentPage = 1, int pageSize = 5, bool isAscending = false)
        {
            // Eğer menuId parametresi varsa, menüyü kontrol et
            if (menuId.HasValue)
            {
                var menuResult = await _menuService.GetAsync(menuId.Value);
                
                // Eğer menü "Ana Sayfa" ise, menuId parametresini temizle ve ana sayfaya yönlendir
                if (menuResult.ResultStatus == Shared.Utilities.Results.ComplexTypes.ResultStatus.Success)
                {
                    string menuName = menuResult.Data.Menu.Name.ToLower().Trim();
                    if (menuName == "ana sayfa" || menuName == "anasayfa")
                    {
                        return RedirectToAction("Index", "Home", new { });
                    }
                    
                    // Menü adını URL-friendly hale getir ve yönlendir
                    string menuSlug = ConvertToUrlFriendly(menuResult.Data.Menu.Name);
                    return RedirectToAction("MenuBySlug", new { slug = menuSlug });
                }
            }
            
            var articlesResult = await _articleService.GetAllByPagingAsync(null, currentPage, pageSize, isAscending);
            return View(articlesResult.Data);
        }
        
        [Route("menu/{slug}")]
        [HttpGet]
        public async Task<IActionResult> MenuBySlug(string slug, int currentPage = 1, int pageSize = 5, bool isAscending = false)
        {
            if (string.IsNullOrEmpty(slug))
            {
                return RedirectToAction("Index");
            }
            
            // Tüm menüleri getir
            var menusResult = await _menuService.GetAllByNonDeletedAndActiveAsync();
            if (menusResult.ResultStatus != Shared.Utilities.Results.ComplexTypes.ResultStatus.Success)
            {
                return NotFound();
            }
            
            // Slug'a göre menüyü bul
            var menu = menusResult.Data.Menus.FirstOrDefault(m => 
                ConvertToUrlFriendly(m.Name) == slug);
                
            if (menu == null)
            {
                return NotFound();
            }
            
            var articlesResult = await _articleService.GetAllByPagingAsync(menu.Id, currentPage, pageSize, isAscending);
            return View("Index", articlesResult.Data);
        }
        
        // Menü adını URL-friendly hale getiren yardımcı metot
        private string ConvertToUrlFriendly(string text)
        {
            if (string.IsNullOrEmpty(text)) return "";
            
            // Türkçe karakterleri çevir
            text = text.ToLower()
                .Replace("ç", "c")
                .Replace("ğ", "g")
                .Replace("ı", "i")
                .Replace("ö", "o")
                .Replace("ş", "s")
                .Replace("ü", "u")
                .Replace(" ", "-")
                .Replace(".", "")
                .Replace(",", "")
                .Replace(";", "")
                .Replace("'", "")
                .Replace("\"", "")
                .Replace(":", "")
                .Replace("!", "")
                .Replace("?", "");
                
            return text.Trim('-');
        }
        [Route("hakkimizda")]
        [Route("hakkinda")]
        [HttpGet]
        public async Task<IActionResult> About()
        {
         
            return View(_aboutUsPageInfo);
        }
        [Route("iletisim")]
        [HttpGet]
        public IActionResult Contact()
        {
   
            return View();
        }
        [Route("iletisim")]
        [HttpPost]
        public IActionResult Contact(EmailSendDto emailSendDto)
        {
           
            if (!ModelState.IsValid)
            {
                var errors = ModelState
                    .Where(x => x.Value.Errors.Count > 0)
                    .Select(x => new {
                        Key = x.Key,
                        Errors = x.Value.Errors.Select(e => e.ErrorMessage).ToList()
                    })
                    .ToList();

     
                foreach (var error in errors)
                {
                    _logger.LogError($"Model validation error - {error.Key}: {string.Join(", ", error.Errors)}");
                }
            }

            if (ModelState.IsValid)
            {
                var result = _mailService.SendContactEmail(emailSendDto);
                _toastNotification.AddSuccessToastMessage(result.Message, new ToastrOptions
                {
                    Title = "Başarılı İşlem!"
                });
                TempData["RedirectToHome"] = true;

                return View();
            }
            return View(emailSendDto);
        }
    }
}
