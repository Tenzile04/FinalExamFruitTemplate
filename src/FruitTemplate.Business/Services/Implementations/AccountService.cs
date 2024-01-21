using FruitTemplate.Business.Exceptions;
using FruitTemplate.Business.Services.Interfaces;
using FruitTemplate.Business.ViewModels;
using FruitTemplate.Core.Models;
using FruitTemplate.Core.Repositories.Interfaces;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FruitTemplate.Business.Services.Implementations
{
    public class AccountService : IAccountService
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        public AccountService(UserManager<AppUser> userManager,SignInManager<AppUser> signInManager)
        {
                _userManager = userManager;
            _signInManager = signInManager;
        }
        public async Task Login(LoginViewModel loginViewModel)
        {
            if (loginViewModel == null) throw new InvalidNotFoundException();
            AppUser admin = null;
            admin=await _userManager.FindByNameAsync(loginViewModel.UserName);
            if(admin == null)
            {
                throw new InvalidCredentionalException("", "UserName or Password is incorrect");
                
            }
            var result = await _signInManager.PasswordSignInAsync(admin, loginViewModel.Password, false, false);
            if(!result.Succeeded)
            {
                throw new InvalidCredentionalException("", "UserName or Password is incorrect");
            }

        }
    }
}
