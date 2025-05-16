using Microsoft.AspNetCore.Mvc;
using ProgrammersBlog.Entities.Concrete;
using ProgrammersBlog.Mvc.Models.CategoryModel;
using ProgrammersBlog.Services.Abstract; // Eğer CategoryService buradaysa
using ProgrammersBlog.Shared.Utilities.Results.ComplexTypes;

public class CategoryMenuViewComponent : ViewComponent
{
    private readonly ICategoryService _categoryService;

    public CategoryMenuViewComponent(ICategoryService categoryService)
    {
        _categoryService = categoryService;
    }

    public async Task<IViewComponentResult> InvokeAsync()
    {
        var result = await _categoryService.GetAllAsync();
        if (result.ResultStatus == ResultStatus.Success)
        {
            return View(result.Data.Categories);
        }
        return View(new List<Category>()); // Hata durumunda boş liste döndür
    }
}
