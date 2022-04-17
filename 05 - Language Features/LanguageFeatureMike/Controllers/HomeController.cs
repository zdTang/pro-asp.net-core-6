//using Microsoft.AspNetCore.Mvc;
//using LanguageFeatureMike.Models;
// those namespaces are ignored by GlobalUsing

namespace LanguageFeatureMike.Controllers
{
    public class HomeController : Controller
    {
        public ViewResult Index()
        {
            ShoppingCart cart = new ShoppingCart {Products=Product.GetProducts()}; 
            

            Product[] productArray =
            {
                new Product{Name="Kayak",Price=275M},
                new Product{Name="LifeJacket",Price=48.95M}
            };

            decimal cartTotal = cart.TotalPrices();
            decimal arrayTotal=productArray.TotalPrices();
            
            return View("Index",new string[] {$"Cart Total:{cartTotal:C2}",
            $"Array Total:{arrayTotal:C2}"});
        }


        public ViewResult Index2()
        {
            
            Product[] productArray =
            {
                new Product{Name="Kayak",Price=275M},
                new Product{Name="LifeJacket",Price=48.95M},
                new Product{Name="Kayak2",Price=18M},
                new Product{Name="LifeJacket2",Price=48.95M},
                new Product{Name="Kayak3",Price=275M},
                new Product{Name="LifeJacket3",Price=15M}
            };

            
            decimal arrayTotal = productArray.FilterByPrice(20).TotalPrices();

            return View("Index", new string[] {$"Array Total:{arrayTotal:C2}"});
        }
    }
}
