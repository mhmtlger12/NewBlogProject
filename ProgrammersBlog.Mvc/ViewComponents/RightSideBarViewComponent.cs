using Microsoft.AspNetCore.Mvc;
using ProgrammersBlog.Mvc.Models;
using ProgrammersBlog.Services.Abstract;

namespace ProgrammersBlog.Mvc.ViewComponents
{
    public class RightSideBarViewComponent:ViewComponent
    {
        private readonly IMenuService _menuService;
        private readonly IArticleService _articleService;

        public RightSideBarViewComponent(IMenuService menuService, IArticleService articleService)
        {
            _menuService = menuService;
            _articleService = articleService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var menusResult = await _menuService.GetAllByNonDeletedAndActiveAsync();
            var articlesResult = await _articleService.GetAllByViewCountAsync(isAscending: false, takeSize: 5);
            return View(new RightSideBarViewModel
            {
                Menus = menusResult.Data.Menus,
                Articles = articlesResult.Data.Articles
            });
        }
    }
}
