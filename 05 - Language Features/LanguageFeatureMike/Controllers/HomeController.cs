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

            //string val = products[0]?.Name;  // Will have error as the string is not nullable,but the Right-side could be null
            string? val = products[0]?.Name;

            if (val!=null)
            {
                return View(new string[] {val});
            }
            return View(new string[] { "No Value"});
        }
    }
}
