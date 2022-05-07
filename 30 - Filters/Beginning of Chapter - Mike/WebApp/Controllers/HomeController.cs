using Microsoft.AspNetCore.Mvc;

namespace WebApp;

public class HomeController : Controller
{    
    // GET
    public IActionResult Index()
    {
        if (Request.IsHttps)
        {
            return View("Message","This is the Index action on the Home Controller");
        }
        else
        {
            //the response will have no body, only header 403 Forbidden
            return new StatusCodeResult(StatusCodes.Status403Forbidden);
        }
    }
    
    /// <summary>
    /// Check HTTPS using this approach will duplicate code in every action
    /// </summary>
    /// <returns></returns>
    public IActionResult Secure()
    {
        if (Request.IsHttps)
        {
            return View("Message","This is the Secure action on the Home Controller");
        }
        else
        {
            //the response will have no body, only header 403 Forbidden
            return new StatusCodeResult(StatusCodes.Status403Forbidden);
        }
    }
}