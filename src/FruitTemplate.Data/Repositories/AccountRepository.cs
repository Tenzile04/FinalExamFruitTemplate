using FruitTemplate.Core.Models;
using FruitTemplate.Core.Repositories.Interfaces;
using FruitTemplate.Data.DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FruitTemplate.Data.Repositories
{
    public class AccountRepository : GenericRepository<Fruit>, IAccountRepository
    {
        public AccountRepository(AppDbContext context) : base(context)
        {
        }
    }
}
