using Microsoft.AspNetCore.Mvc;
using ProgrammersBlog.Entities.Concrete;
using ProgrammersBlog.Services.Abstract;
using ProgrammersBlog.Shared.Utilities.Results.ComplexTypes;

public class MenuViewComponent : ViewComponent
{
    private readonly IMenuService _menuService;

    public MenuViewComponent(IMenuService menuService)
    {
        _menuService = menuService;
    }

    public async Task<IViewComponentResult> InvokeAsync()
    {
        var result = await _menuService.GetAllByNonDeletedAndActiveAsync();
        if (result.ResultStatus == ResultStatus.Success)
        {
            return View(result.Data.Menus);
        }
        return View(new List<Menu>()); // Hata durumunda boş liste döndür
    }
}
