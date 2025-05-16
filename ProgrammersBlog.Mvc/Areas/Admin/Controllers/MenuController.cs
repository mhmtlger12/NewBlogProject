using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using ProgrammersBlog.Entities.Concrete;
using ProgrammersBlog.Entities.Dtos.Menus;
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
    public class MenuController : BaseController
    {
        private readonly IMenuService _menuService;

        public MenuController(IMenuService menuService, UserManager<User> userManager, IMapper mapper, IImageHelper imageHelper) : base(userManager, mapper, imageHelper)
        {
            _menuService = menuService;
        }

        [Authorize(Roles = "SuperAdmin,Menu.Read")]
        public async Task<IActionResult> Index()
        {
            var result = await _menuService.GetAllByNonDeletedAsync();
            return View(result.Data);
        }

        [Authorize(Roles = "SuperAdmin,Menu.Create")]
        [HttpGet]
        public async Task<IActionResult> Add()
        {
            // Ebeveyn menüleri getir
            var parentMenus = await _menuService.GetAllMainMenusAsync();
            ViewBag.ParentMenus = parentMenus.Data.Menus;
            return PartialView("_MenuAddPartial");
        }

        [Authorize(Roles = "SuperAdmin,Menu.Create")]
        [HttpPost]
        public async Task<IActionResult> Add(MenuAddDto menuAddDto)
        {
            if (ModelState.IsValid)
            {
                var result = await _menuService.AddAsync(menuAddDto, LoggedInUser.UserName);
                if (result.ResultStatus == ResultStatus.Success)
                {
                    var menuAddAjaxModel = JsonSerializer.Serialize(new MenuAddAjaxViewModel
                    {
                        MenuDto = result.Data,
                        MenuAddPartial = await this.RenderViewToStringAsync("_MenuAddPartial", menuAddDto)
                    });
                    return Json(menuAddAjaxModel);
                }
            }
            var parentMenus = await _menuService.GetAllMainMenusAsync();
            ViewBag.ParentMenus = parentMenus.Data.Menus;
            var menuAddAjaxErrorModel = JsonSerializer.Serialize(new MenuAddAjaxViewModel
            {
                MenuAddPartial = await this.RenderViewToStringAsync("_MenuAddPartial", menuAddDto)
            });
            return Json(menuAddAjaxErrorModel);
        }

        [Authorize(Roles = "SuperAdmin,Menu.Update")]
        [HttpGet]
        public async Task<IActionResult> Update(Guid menuId)
        {
            var result = await _menuService.GetMenuUpdateDtoAsync(menuId);
            if (result.ResultStatus == ResultStatus.Success)
            {
                var parentMenus = await _menuService.GetAllMainMenusAsync();
                ViewBag.ParentMenus = parentMenus.Data.Menus;
                return PartialView("_MenuUpdatePartial", result.Data);
            }
            else
            {
                return NotFound();
            }
        }

        [Authorize(Roles = "SuperAdmin,Menu.Update")]
        [HttpPost]
        public async Task<IActionResult> Update(MenuUpdateDto menuUpdateDto)
        {
            if (ModelState.IsValid)
            {
                var result = await _menuService.UpdateAsync(menuUpdateDto, LoggedInUser.UserName);
                if (result.ResultStatus == ResultStatus.Success)
                {
                    var menuUpdateAjaxModel = JsonSerializer.Serialize(new MenuUpdateAjaxViewModel
                    {
                        MenuDto = result.Data,
                        MenuUpdatePartial = await this.RenderViewToStringAsync("_MenuUpdatePartial", menuUpdateDto)
                    });
                    return Json(menuUpdateAjaxModel);
                }
            }
            var parentMenus = await _menuService.GetAllMainMenusAsync();
            ViewBag.ParentMenus = parentMenus.Data.Menus;
            var menuUpdateAjaxErrorModel = JsonSerializer.Serialize(new MenuUpdateAjaxViewModel
            {
                MenuUpdatePartial = await this.RenderViewToStringAsync("_MenuUpdatePartial", menuUpdateDto)
            });
            return Json(menuUpdateAjaxErrorModel);
        }

        [Authorize(Roles = "SuperAdmin,Menu.Read")]
        [HttpGet]
        public async Task<JsonResult> GetAllMenus()
        {
            var result = await _menuService.GetAllByNonDeletedAsync();
            var menus = JsonSerializer.Serialize(result.Data, new JsonSerializerOptions
            {
                ReferenceHandler = ReferenceHandler.Preserve
            });
            return Json(menus);
        }

        [Authorize(Roles = "SuperAdmin,Menu.Delete")]
        [HttpPost]
        public async Task<JsonResult> Delete(Guid menuId)
        {
            var result = await _menuService.DeleteAsync(menuId, LoggedInUser.UserName);
            var deletedMenu = JsonSerializer.Serialize(result.Data);
            return Json(deletedMenu);
        }

        [Authorize(Roles = "SuperAdmin,Menu.Read")]
        [HttpGet]
        public async Task<IActionResult> DeletedMenus()
        {
            var result = await _menuService.GetAllByDeletedAsync();
            return View(result.Data);
        }

        [Authorize(Roles = "SuperAdmin,Menu.Read")]
        public async Task<JsonResult> GetAllDeletedMenus()
        {
            var result = await _menuService.GetAllByDeletedAsync();
            var menus = JsonSerializer.Serialize(result.Data, new JsonSerializerOptions
            {
                ReferenceHandler = ReferenceHandler.Preserve
            });
            return Json(menus);
        }

        [Authorize(Roles = "SuperAdmin,Menu.Update")]
        [HttpPost]
        public async Task<JsonResult> UndoDelete(Guid menuId)
        {
            var result = await _menuService.UndoDeleteAsync(menuId, LoggedInUser.UserName);
            var undoDeletedMenu = JsonSerializer.Serialize(result.Data);
            return Json(undoDeletedMenu);
        }

        [Authorize(Roles = "SuperAdmin,Menu.Delete")]
        [HttpPost]
        public async Task<JsonResult> HardDelete(Guid menuId)
        {
            var result = await _menuService.HardDeleteAsync(menuId);
            var deletedMenu = JsonSerializer.Serialize(result);
            return Json(deletedMenu);
        }
    }
}
