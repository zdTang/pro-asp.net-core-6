using System.Collections;

namespace LanguageFeatureMike.Models
{
    //Here, as the New interface is using Default Implementation
    //So that the old method which has implement that interface will not need to be changed !!
    //And it is a GREAT BENEFIT !!!
    
    public class ShoppingCartTwo : IProductSelection
    {
        private List<Product> products = new();
        
        // THIS ONE IMPLEMENT INTERFACE !!
        public IEnumerable<Product>? Products { get => products; }
        
        public ShoppingCartTwo(params Product[] prods)
        {
            products.AddRange(prods);
        }
        
    }
}
