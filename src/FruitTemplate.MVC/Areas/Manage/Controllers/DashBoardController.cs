using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FruitTemplate.MVC.Areas.Manage.Controllers
{
    [Authorize(Roles = "SuperAdmin")]
    [Area("manage")]
    public class DashBoardController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
