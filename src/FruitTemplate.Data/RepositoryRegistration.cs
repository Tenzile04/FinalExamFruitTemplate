using FruitTemplate.Core.Repositories.Interfaces;
using FruitTemplate.Data.Repositories;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FruitTemplate.Data
{
    public static class RepositoryRegistration
    {
        public static void AddRepository(this IServiceCollection services)
        {
            services.AddScoped<IFruitRepository, FruitRepository>();
            services.AddScoped<IAccountRepository, AccountRepository>();
        }
    }
}
