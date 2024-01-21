using FruitTemplate.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace FruitTemplate.Business.Services.Interfaces
{
    public interface IFruitService
    {
        Task Create(Fruit fruit);
        Task Update(Fruit fruit);
        Task Delete(int id);
        Task<Fruit> GetById(Expression<Func<Fruit, bool>>? expression = null, params string[]? includes);
        Task<List<Fruit>> GetAll(Expression<Func<Fruit, bool>>? expression = null, params string[]? includes);
    }
}
