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


       public static IEnumerable<Product?> FilterByPrice(
       this IEnumerable<Product?> productEnum, decimal minimumPrice)
        {
            foreach (Product? product in productEnum)
            {
                if ((product?.Price ?? 0) >= minimumPrice)// Pay attention here!
                {
                    yield return product;
                }
            }
        }


        public static IEnumerable<Product?> FilterByName(
       this IEnumerable<Product?> productEnum, char firstLetter)
        {
            foreach (Product? product in productEnum)
            {
                if (product?.Name?[0] == firstLetter)// Pay attention here!
                {
                    yield return product;
                }
            }
        }
    }

   
}
