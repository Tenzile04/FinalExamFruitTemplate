using FruitTemplate.Business.Exceptions;
using FruitTemplate.Business.Services.Interfaces;
using FruitTemplate.Core.Models;
using FruitTemplate.Core.Repositories.Interfaces;
using FruitTemplate.Data.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace FruitTemplate.Business.Services.Implementations
{
    public class SettingService : ISettingService
    {
        private readonly ISettingRepository _settingRepository;
        public SettingService(ISettingRepository settingRepository)
        {
            _settingRepository = settingRepository;
        }

        public async Task<List<Setting>> GetAllAsync(Expression<Func<Setting, bool>>? expression = null, params string[]? includes)
        {
           return await _settingRepository.GetAllWhereAsync(expression,includes).ToListAsync();
        }

        public async Task<Setting> GetByIdAsync(Expression<Func<Setting, bool>>? expression = null, params string[]? includes)
        {
            return await _settingRepository.GetByIdAsync(expression, includes);
        }

        public async Task Update(Setting setting)
        {
            if (setting == null) throw new InvalidNotFoundException();
            var existSetting = await _settingRepository.GetByIdAsync(x => x.Id == setting.Id);
            if (existSetting == null) throw new InvalidNotFoundException();
            existSetting.Value = setting.Value;

            await _settingRepository.CommitAsync();
        }
    }
}
