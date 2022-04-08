using Microsoft.AspNetCore.Mvc;

namespace HazonClient.Controllers
{
    public class BusinessController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult UnReleased()
        {
            return View();
        }

        public IActionResult Released()
        {
            return View();
        }
    }
}
