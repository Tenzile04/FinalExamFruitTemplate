using Microsoft.AspNetCore.Mvc;

namespace FruitTemplate.MVC.Areas.Manage.Controllers
{
    [Area("manage")]
    public class DashBoardController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
