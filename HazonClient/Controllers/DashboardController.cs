using HazonClient.Pages;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HazonClient.Controllers;
public class DashboardController : Controller
{
    //[Authorize(Roles = MainMenu.Dashboard.RoleName)]
    public IActionResult Index()
    {
        return View();
    }
}