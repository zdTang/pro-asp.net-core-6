using Microsoft.AspNetCore.Mvc;
using WebApp.Filters;

namespace WebApp;

/// <summary>
/// Different level of filter!! Controller level
/// </summary>

[SimpleCacheAsync]
public class HomeController : Controller
{    
  
    //[HttpsOnly]
    //[SimpleCache]
    
    public IActionResult Index()
    {
       return View("Message","This is the Index action on the Home Controller");
    }
    

    //[RequireHttps]
    public IActionResult Secure()
    {
        return View("Message","This is the Secure action on the Home Controller");
    }
}