using Microsoft.EntityFrameworkCore;

namespace SportsStore.Models{
    public class StoreDbContext:DbContext{
        
        // who will pass the options parameter here ???
        public StoreDbContext(DbContextOptions<StoreDbContext> options):base(options){}
        public DbSet<Product> Products => Set<Product>();
    }
}