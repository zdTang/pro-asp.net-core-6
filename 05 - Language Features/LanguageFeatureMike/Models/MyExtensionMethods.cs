namespace LanguageFeatureMike.Models
{
    //class for holding Extension method must be "static"
    public static class MyExtensionMethods
    {

        public static decimal TotalPrices(this IEnumerable<Product?> products)
        {
            decimal total = 0;
            foreach (Product? prod in products)
            {
                total += prod?.Price ?? 0;
            }  
            return total;
        }
    }
}
