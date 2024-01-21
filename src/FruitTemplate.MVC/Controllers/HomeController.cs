
using FruitTemplate.Business.Services.Interfaces;
using FruitTemplate.Core.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace FruitTemplate.MVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly IFruitService _fruitService;

        public HomeController(IFruitService fruitService)
        {
            _fruitService = fruitService;
        }
        public async Task<IActionResult> Index()
        {
            List<Fruit> fruits=await _fruitService.GetAll();
            return View(fruits);
        }

    
    }
}
