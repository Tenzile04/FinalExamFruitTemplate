using FruitTemplate.Business.Exceptions;
using FruitTemplate.Business.Services.Implementations;
using FruitTemplate.Business.Services.Interfaces;
using FruitTemplate.Core.Models;
using Microsoft.AspNetCore.Mvc;

namespace FruitTemplate.MVC.Areas.Manage.Controllers
{
    [Area("manage")]
    public class SettingController : Controller
    {
        private readonly ISettingService _settingService;

        public SettingController(ISettingService settingService)
        {
            _settingService = settingService;
        }
        public async Task<IActionResult> Index()
        {
            return View(await _settingService.GetAllAsync());
        }
        [HttpGet]
        public async Task<IActionResult> UpdateAsync(int id)
        {
            if (id == null) return View("error");
            var existSetting = await _settingService.GetByIdAsync(x => x.Id == id);
            if (existSetting == null) return View("error");
            return View(existSetting);
        }
        [ValidateAntiForgeryToken]
        [HttpPost]
        public async Task<IActionResult> Update(Setting setting)
        {
            if (!ModelState.IsValid) return View(setting);
            try
            {
                await _settingService.Update(setting);
            }
            catch (InvalidNotFoundException ex)
            {
                return View("error");

            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return View(setting);

            }
            return RedirectToAction(nameof(Index));
        }
    }
}
