//using Microsoft.AspNetCore.Mvc;
//using LanguageFeatureMike.Models;
// those namespaces are ignored by GlobalUsing

namespace LanguageFeatureMike.Controllers
{
    public class HomeController : Controller
    {
        public ViewResult Index()
        {
            Product?[]products=Product.GetProducts();

            
            return View(new string[] { products[0]?.Name??"No value"});
        }
    }
}
