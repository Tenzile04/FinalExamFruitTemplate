using FruitTemplate.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace FruitTemplate.Business.Services.Interfaces
{
    public interface ISettingService
    {
        Task Update(Setting setting);
        Task<List<Setting>> GetAllAsync(Expression<Func<Setting, bool>>? expression = null, params string[]? includes);
        Task<Setting> GetByIdAsync(Expression<Func<Setting, bool>>? expression = null, params string[]? includes);
    }
}
