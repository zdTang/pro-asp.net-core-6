namespace LanguageFeatureMike.Models
{
    public interface IProductSelection
    {
        IEnumerable<Product> Products { get; }
        IEnumerable<string>? Names=>Products.Select(p=>p.Name);  // Using Interface Default Implementation
    }
}
