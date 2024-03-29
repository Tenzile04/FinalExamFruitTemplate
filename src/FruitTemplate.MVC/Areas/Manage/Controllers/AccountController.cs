﻿using FruitTemplate.Business.Services.Interfaces;
using FruitTemplate.Business.ViewModels;
using FruitTemplate.Core.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using NuGet.Protocol.Plugins;
using System.Security.Authentication;

namespace FruitTemplate.MVC.Areas.Manage.Controllers
{
    [Area("manage")]
    public class AccountController : Controller
    {
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly UserManager<AppUser> _userManager;
        private readonly IAccountService _accountService;
        public AccountController(RoleManager<IdentityRole> roleManager,UserManager<AppUser> userManager,IAccountService accountService)
        {
            _roleManager = roleManager;
            _userManager = userManager;
            _accountService = accountService;
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }
        [ValidateAntiForgeryToken]
        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel loginViewModel)
        {
            if (!ModelState.IsValid) return View(loginViewModel);
            try
            {
                await _accountService.Login(loginViewModel);
            }
            catch (InvalidCredentialException ex)
            {
                ModelState.AddModelError("", ex.Message);
                return View(loginViewModel);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return View(loginViewModel);
            }
            return RedirectToAction("index", "fruit");
        }



        //public async Task<IActionResult> CreateRole()
        //{
        //    var role1 = new IdentityRole("SuperAdmin");
        //    var role2 = new IdentityRole("Admin");
        //    var role3 = new IdentityRole("Member");

        //    await _roleManager.CreateAsync(role1);
        //    await _roleManager.CreateAsync(role2);  
        //    await _roleManager.CreateAsync(role3);
        //    return Ok("Role yarandi");
        //}
        //public async Task<IActionResult> CreateAdmin()
        //{
        //    AppUser admin = new AppUser()
        //    {
        //        FullName = "Tenzile Abdiyeva",
        //        UserName = "SuperAdmin"
        //    };
        //    await _userManager.CreateAsync(admin,"Admin123@");
        //    await _userManager.AddToRoleAsync(admin, "SuperAdmin");
        //    return Ok("Admin Yarandi");
        //}
    }
}
