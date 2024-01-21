using FruitTemplate.Business.Services.Interfaces;
using FruitTemplate.Core.Models;
using Microsoft.AspNetCore.Mvc;

namespace FruitTemplate.MVC.Areas.ViewService
{
    public class LayoutSevice
    {
        private readonly ISettingService _settingService;
        public LayoutSevice(ISettingService settingService)
        {
            _settingService = settingService;
        }
        public async Task<List<Setting>> GetSetting()
        {
            var settings=await _settingService.GetAllAsync();
            return settings;
        }

    }
}
