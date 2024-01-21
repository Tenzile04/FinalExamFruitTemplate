using FruitTemplate.Business.Exceptions;
using FruitTemplate.Business.Services.Interfaces;
using FruitTemplate.Core.Models;
using Microsoft.AspNetCore.Mvc;

namespace FruitTemplate.MVC.Areas.Manage.Controllers
{
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
                ModelState.AddModelError(ex.PropertyName, ex.Message);
                return View(fruit);

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
            if (id == null) throw new InvalidNotFoundException();
            var existFruit=await _fruitService.GetById(x=>x.Id==id);
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
                ModelState.AddModelError(ex.PropertyName, ex.Message);
                return View(fruit);

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
            if (id == null) throw new InvalidNotFoundException();
            var existFruit = await _fruitService.GetById(x => x.Id == id && x.IsDeleted==false);
            return View(existFruit);
        }
        public async Task<IActionResult> Delete(Fruit fruit)
        {
            if (!ModelState.IsValid) return View(fruit);
            try
            {
                await _fruitService.Delete(fruit.Id);
            }
            catch (InvalidNotFoundException ex)
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
    }
}
