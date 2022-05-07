using Microsoft.AspNetCore.Mvc;

namespace WebApp;

/// <summary>
/// Different level of filter!! Controller level
/// </summary>
[RequireHttps]
public class HomeController : Controller
{    
  
    //[RequireHttps]
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