namespace LanguageFeatureMike.Models {

    /// <summary>
    /// This class is a great example for understanding Class or Type
    /// Fields are solid within an object, which represent states
    /// Methods are not solid which are taking care of Logics and not occupy Instance space
    /// </summary>
    
    public class Product {

        //public string Name { get; set; } = "Mike"; //not nullable, need init
        //public string? Name { get; set; }  // nullable, need not init
        public string Name { get; set; }     // Not nullable, but has Ctor
        public decimal? Price { get; set; }
        public Product()
        {
            Name = string.Empty;    // Even though the Name is no-nullable,ctor will give init value
        }
        public static Product?[] GetProducts() {

            Product kayak = new Product {
                Name = "Kayak", Price = 275M
            };

            Product lifejacket = new Product {
                Name = "Lifejacket", Price = 48.95M
            };

            return new Product?[] { kayak, lifejacket, null };
        }
    }
}
