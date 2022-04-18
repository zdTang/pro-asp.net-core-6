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

        public ViewResult Index3()
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


            decimal priceFilterTotal = productArray.FilterByPrice(20).TotalPrices();
            decimal nameFilterTotal = productArray.FilterByName('L').TotalPrices();
            return View("Index", new string[] { $"priceFilterTotal:{priceFilterTotal:C2}", 
                $"nameFilterTotal:{nameFilterTotal:C2}" });
        }
        // Before using lambda Expression
        //bool FilterByPrice(Product? p)
        //{
        //    return (p?.Price ?? 0) >= 0;
        //}
        // Be Aware this is not a function, this is an Expression.
        // Delegate is an old approach to represent anonymous method
        //Func<Product?, bool> nameFilter = delegate (Product? p)
        //   {
        //       return p?.Name[0] == 'K';
        //   };
        public ViewResult Index4()
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

            // Pass an Lambda to Filter !!
            decimal priceFilterTotal = productArray.Filter(p=>(p?.Price??0)>=20).TotalPrices();
            decimal nameFilterTotal = productArray.Filter(p=>p?.Name?[0]=='K').TotalPrices();
            return View("Index", new string[] { $"priceFilterTotal:{priceFilterTotal:C2}",
                $"nameFilterTotal:{nameFilterTotal:C2}" });
        }
        // TEST ANONYMOUS TYPE
        public ViewResult Index5()
        {
            var products = new []
            {
                new {Name="Kayak",Price=275M},
                new {Name="LifeJacket",Price=48.95M},
                new {Name="Kayak2",Price=18M},
                new {Name="LifeJacket2",Price=48.95M},
                new {Name="Kayak3",Price=275M},
                new {Name="LifeJacket3",Price=15M}
            };

            return View("Index", products.Select(p=>p.GetType().Name)); // select Name into a new collection
        }

        public ViewResult Index6()
        {
            IProductSelection cart = new ShoppingCartTwo(
                new Product{ Name = "Kayak", Price = 275M },
                new Product { Name = "LifeJacket", Price = 48.95M },
                new Product { Name = "Kayak2", Price = 18M },
                new Product { Name = "LifeJacket2", Price = 48.95M },
                new Product { Name = "Kayak3", Price = 275M },
                new Product { Name = "LifeJacket3", Price = 15M });
            
            // The Names property is a default implementation of the Interface !!!
            // We can use it eventhough the ShoppingCartTwo class hasn't implement it!
            return View("Index", cart.Names); // select Name into a new collection
        }

        public string IndexApi()
        {
            var length=MyAsyncMethods.GetPageLength();
            return length?.Result?.ToString()??"Zero";
        }

        public async Task<string> IndexApiTwo()
        {
            var length = await MyAsyncMethods.GetPageLengthTwo();
            return length?.ToString() ?? "Zero";
        }
    }
}
