using Microsoft.AspNetCore.Mvc;

namespace LanguageFeatureMike.Controllers
{
    public class HomeController : Controller
    {
        public ViewResult Index()
        {
            return View(new string[] {"c#","language","features"});
        }
    }
}
