using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using ProgrammersBlog.Entities.Concrete;
using ProgrammersBlog.Entities.Dtos.Logs;
using ProgrammersBlog.Mvc.Areas.Admin.Models;
using ProgrammersBlog.Mvc.Helpers.Abstract;
using ProgrammersBlog.Services.Abstract;
using ProgrammersBlog.Shared.Utilities.Results.ComplexTypes;
using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ProgrammersBlog.Mvc.Areas.Admin.Controllers
{
    [Area("Admin")]

    public class LogController : BaseController
    {
        private readonly ILogService _logService;

        public LogController(ILogService logService, UserManager<User> userManager, IMapper mapper, IImageHelper imageHelper)
            : base(userManager, mapper, imageHelper)
        {
            _logService = logService;
        }

        [Authorize(Roles = "SuperAdmin,Log.Read")]
        [HttpGet]
        public async Task<IActionResult> Index(int page = 1, int pageSize = 10,
                                      string level = null, DateTime? startDate = null,
                                      DateTime? endDate = null, string userName = null)
        {
            var result = await _logService.GetAllByPagingAsync(page, pageSize, level, startDate, endDate, userName);
            if (result.ResultStatus == ResultStatus.Success)
                return View(result.Data);

            return View(new LogListDto { Logs = new List<Log>() });
        }

        [Authorize(Roles = "SuperAdmin,Log.Read")]
        [HttpGet]
        public async Task<JsonResult> GetAllLogs()
        {
            var logs = await _logService.GetAllAsync();
            var logResult = JsonSerializer.Serialize(logs, new JsonSerializerOptions
            {
                ReferenceHandler = ReferenceHandler.Preserve
            });
            return Json(logResult);
        }

        [Authorize(Roles = "SuperAdmin,Log.Read")]
        [HttpGet]
        public async Task<IActionResult> Detail(Guid logId)
        {
            var result = await _logService.GetAsync(logId);
            if (result.ResultStatus == ResultStatus.Success)
            {
                return View(result.Data);
            }
            return NotFound();
        }

        [Authorize(Roles = "SuperAdmin,Log.Delete")]
        [HttpPost]
        public async Task<JsonResult> Delete(Guid logId)
        {
            var result = await _logService.DeleteAsync(logId);
            var logResult = JsonSerializer.Serialize(result);
            return Json(logResult);
        }

        [Authorize(Roles = "SuperAdmin,Log.Delete")]
        [HttpPost]
        public async Task<JsonResult> DeleteAllLogs()
        {
            var result = await _logService.DeleteAllAsync();
            var logResult = JsonSerializer.Serialize(result);
            return Json(logResult);
        }

        [Authorize(Roles = "SuperAdmin,Log.Read")]
        [HttpGet]
        public async Task<IActionResult> Filter(string level, DateTime? startDate, DateTime? endDate, string userName)
        {
            var result = await _logService.FilterLogsAsync(level, startDate, endDate, userName);
            if (result.ResultStatus == ResultStatus.Success)
                return View("Index", result.Data);

            return NotFound();
        }
        [Authorize(Roles = "SuperAdmin,Editor,Log.Read")]
        [HttpGet]
        public async Task<IActionResult> GetLogLevelStats()
        {
            var result = await _logService.GetLogLevelCountsAsync();
            return Json(result, new JsonSerializerOptions
            {
                WriteIndented = true, // Geliştirme ortamında okunabilirlik için
                ReferenceHandler = ReferenceHandler.IgnoreCycles // Döngüsel referansları yok say
            });
        }
    }
}