using System.Collections;

namespace LanguageFeatureMike.Models
{
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
