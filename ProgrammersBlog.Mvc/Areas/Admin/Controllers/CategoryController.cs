﻿using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using ProgrammersBlog.Entities.Concrete;
using ProgrammersBlog.Entities.Dtos.Categories;
using ProgrammersBlog.Mvc.Areas.Admin.Models;
using ProgrammersBlog.Mvc.Helpers.Abstract;
using ProgrammersBlog.Services.Abstract;
using ProgrammersBlog.Shared.Utilities.Extensions;
using ProgrammersBlog.Shared.Utilities.Results.ComplexTypes;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace ProgrammersBlog.Mvc.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CategoryController : BaseController
    {
        private readonly ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService,UserManager<User> userManager,IMapper mapper,IImageHelper imageHelper):base(userManager,mapper,imageHelper)
        {
            _categoryService = categoryService;
        }

        [Authorize(Roles = "SuperAdmin,Category.Read")]
        public async Task<IActionResult> Index()
        {
            var result = await _categoryService.GetAllByNonDeletedAsync();
            return View(result.Data); // burada if bloğuna gerek yok eror kısmı zaten data ile geliyor.
        }

        [Authorize(Roles = "SuperAdmin,Category.Create")]
        [HttpGet]
        public IActionResult Add()
        {
            return PartialView("_CategoryAddPartial");
        }

        [Authorize(Roles = "SuperAdmin,Category.Create")]
        [HttpPost]
        public async Task<IActionResult> Add(CategoryAddDto categoryAddDto)
        {
            if(ModelState.IsValid)
            {
                var result = await _categoryService.AddAsync(categoryAddDto, LoggedInUser.UserName);
                if(result.ResultStatus==ResultStatus.Success)
                {
                    var categoryAddAjaxModel=JsonSerializer.Serialize(new CategoryAddAjaxViewModel
                    {
                        CategoryDto  = result.Data,
                        CategoryAddPartial=await this.RenderViewToStringAsync("_CategoryAddPartial",categoryAddDto)
                    });
                    return Json(categoryAddAjaxModel);
                }
            }
            var categoryAddAjaxErrorModel = JsonSerializer.Serialize(new CategoryAddAjaxViewModel
            {
                CategoryAddPartial = await this.RenderViewToStringAsync("_CategoryAddPartial", categoryAddDto)
            });
            return Json(categoryAddAjaxErrorModel);
        }
        [Authorize(Roles = "SuperAdmin,Category.Update")]
        [HttpGet]
        public async Task<IActionResult> Update(Guid categoryId)
        {
            var result = await _categoryService.GetCategoryUpdateDtoAsync(categoryId);
            if(result.ResultStatus==ResultStatus.Success)
            {
                return PartialView("_CategoryUpdatePartial",result.Data);
            }
            else
            {
                return NotFound();
            }
        }

        [Authorize(Roles = "SuperAdmin,Category.Update")]
        [HttpPost]
        public async Task<IActionResult> Update(CategoryUpdateDto categoryUpdateDto)
        {
            if (ModelState.IsValid)
            {
                var result = await _categoryService.UpdateAsync(categoryUpdateDto, LoggedInUser.UserName);
                if (result.ResultStatus == ResultStatus.Success)
                {
                    var categoryUpdateAjaxModel = JsonSerializer.Serialize(new CategoryUpdateAjaxViewModel
                    {
                        CategoryDto = result.Data,
                        CategoryUpdatePartial = await this.RenderViewToStringAsync("_CategoryUpdatePartial", categoryUpdateDto)
                    });
                    return Json(categoryUpdateAjaxModel);
                }
            }
            var categoryUpdateAjaxErrorModel = JsonSerializer.Serialize(new CategoryUpdateAjaxViewModel
            {
                CategoryUpdatePartial = await this.RenderViewToStringAsync("_CategoryUpdatePartial", categoryUpdateDto)
            });
            return Json(categoryUpdateAjaxErrorModel);
        }

        [Authorize(Roles = "SuperAdmin,Category.Read")]
        [HttpGet]
        public async Task<JsonResult> GetAllCategories()
        {
            var result = await _categoryService.GetAllByNonDeletedAsync();
            var categories = JsonSerializer.Serialize(result.Data, new JsonSerializerOptions
            {
                ReferenceHandler = ReferenceHandler.Preserve
            });
            return Json(categories);
        }
        [Authorize(Roles = "SuperAdmin,Category.Read")]
        [HttpPost]
        public async Task<JsonResult> Delete(Guid categoryId)
        {
            var result = await _categoryService.DeleteAsync(categoryId, LoggedInUser.UserName);
            var deletedCategory=JsonSerializer.Serialize(result.Data);
            return Json(deletedCategory);
        }
        [Authorize(Roles = "SuperAdmin,Category.Read")]
        [HttpGet]
        public async Task<IActionResult> DeletedCategories()
        {
            var result = await _categoryService.GetAllByDeletedAsync();
            return View(result.Data);
        }
        public async Task<JsonResult> GetAllDeletedCategories()
        {
            var result = await _categoryService.GetAllByDeletedAsync();
            var categories = JsonSerializer.Serialize(result.Data, new JsonSerializerOptions
            {
                ReferenceHandler = ReferenceHandler.Preserve
            });
            return Json(categories);
        }
        [Authorize(Roles = "SuperAdmin,Category.Update")]
        [HttpPost]
        public async Task<JsonResult> UndoDelete(Guid categoryId)
        {
            var result = await _categoryService.UndoDeleteAsync(categoryId, LoggedInUser.UserName);
            var undoDeletedCategory = JsonSerializer.Serialize(result.Data);
            return Json(undoDeletedCategory);
        }
        [Authorize(Roles = "SuperAdmin,Category.Delete")]
        [HttpPost]
        public async Task<JsonResult> HardDelete(Guid categoryId)
        {
            var result = await _categoryService.HardDeleteAsync(categoryId);
            var deletedCategory = JsonSerializer.Serialize(result);
            return Json(deletedCategory);
        }
    }
}
