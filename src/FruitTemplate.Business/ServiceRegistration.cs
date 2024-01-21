using FruitTemplate.Business.Services.Implementations;
using FruitTemplate.Business.Services.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FruitTemplate.Business
{
    public static class ServiceRegistration
    {
        public static void AddService(this IServiceCollection services)
        {
            services.AddScoped<IFruitService,FruitService>();
            services.AddScoped<IAccountService,AccountService>();
        }
    }
}
