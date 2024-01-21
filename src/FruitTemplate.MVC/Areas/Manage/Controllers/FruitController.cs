using FruitTemplate.Business.Exceptions;
using FruitTemplate.Business.Services.Interfaces;
using FruitTemplate.Core.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FruitTemplate.MVC.Areas.Manage.Controllers
{
    [Authorize(Roles ="SuperAdmin")]
    [Area("manage")]
    public class FruitController : Controller
    {
        private readonly IFruitService _fruitService;

        public FruitController(IFruitService fruitService)
        {
            _fruitService = fruitService;
        }
        public async Task<IActionResult> Index()
        {
            return View(await _fruitService.GetAll());
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [ValidateAntiForgeryToken]
        [HttpPost]
        public async Task<IActionResult> Create(Fruit fruit)
        {
            if (!ModelState.IsValid) return View(fruit);
            try
            {
                await _fruitService.Create(fruit);
            }
            catch (InvalidNotFoundException ex)
            {
                return View("error");

            }
            catch (InvalidContentTypeException ex)
            {
                ModelState.AddModelError(ex.PropertyName, ex.Message);
                return View(fruit);

            }
            catch (InvalidImageSizeException ex)
            {
                ModelState.AddModelError(ex.PropertyName, ex.Message);
                return View(fruit);
            }
            catch (InvalidImageFileException ex)
            {
                ModelState.AddModelError(ex.PropertyName, ex.Message);
                return View(fruit);

            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return View(fruit);

            }
            return RedirectToAction(nameof(Index));            
        }
        [HttpGet]
        public async Task<IActionResult> Update(int id)
        {
            if (id == null) return View("error");
            var existFruit=await _fruitService.GetById(x=>x.Id==id);
            if (existFruit == null) return View("error");
            return View(existFruit);
        }
        [ValidateAntiForgeryToken]
        [HttpPost]
        public async Task<IActionResult> Update(Fruit fruit)
        {
            if(!ModelState.IsValid) return View(fruit);
            try
            {
                await _fruitService.Update(fruit);
            }
            catch (InvalidNotFoundException ex)
            {
                return View("error");

            }
            catch (InvalidContentTypeException ex)
            {
                ModelState.AddModelError(ex.PropertyName, ex.Message);
                return View(fruit);

            }
            catch (InvalidImageSizeException ex)
            {
                ModelState.AddModelError(ex.PropertyName, ex.Message);
                return View(fruit);
            }
            catch (InvalidImageFileException ex)
            {
                ModelState.AddModelError(ex.PropertyName, ex.Message);
                return View(fruit);

            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return View(fruit);

            }
            return RedirectToAction(nameof(Index));
        }
        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            if (id == null) return View("error");
            var existFruit = await _fruitService.GetById(x => x.Id == id && x.IsDeleted==false);
            if (existFruit == null) return View("error");
            return View(existFruit);
        }
        [ValidateAntiForgeryToken]
        [HttpPost]
        public async Task<IActionResult> Delete(Fruit fruit)
        {
            //if (!ModelState.IsValid) return View(fruit);
            try
            {
                await _fruitService.Delete(fruit.Id);
            }
            catch (InvalidNotFoundException ex)
            {
                return View("error");

            }           
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return View(fruit);

            }
            return RedirectToAction(nameof(Index));
        }
    }
}
