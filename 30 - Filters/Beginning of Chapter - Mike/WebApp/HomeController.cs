using Microsoft.AspNetCore.Mvc;

namespace WebApp;

public class HomeController : Controller
{
    // GET
    public IActionResult Index()
    {
        return View("Message","This is the Index action on the Home Controller");
    }
}