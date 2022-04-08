using Microsoft.AspNetCore.Mvc;

namespace HazonClient.Controllers
{
    public class NotificationController : Controller
    {
        public IActionResult Email()
        {
            return View();
        }

        public IActionResult Sms()
        {
            return View();
        }

        public IActionResult WhatsApp()
        {
            return View();
        }

        public IActionResult Inbox()
        {
            return View();
        }
    }
}
