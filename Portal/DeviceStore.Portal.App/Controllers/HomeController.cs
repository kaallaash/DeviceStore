using Microsoft.AspNetCore.Mvc;

namespace DeviceStore.Portal.App.Controllers;

public class HomeController : Controller
{
    [HttpGet]
    public IActionResult Index()
    {
        return View();
    }
}
