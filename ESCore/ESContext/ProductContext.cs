using ESCore.Model.Product;
using Microsoft.EntityFrameworkCore;

namespace ESCore.ESContext
{
    public class ProductContext : ESDBContext
    {
        public DbSet<Product> Products { get; set; }
        //public ProductContext()
        //{ }
        public ProductContext(DbContextOptions dbContextOptions) 
            : base(dbContextOptions) 
        { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            
            modelBuilder.Entity<Product>().ToTable(nameof(Product));
            modelBuilder.Entity<Product>().Navigation(x => x.Variants).UsePropertyAccessMode(PropertyAccessMode.Field).AutoInclude();

            base.OnModelCreating(modelBuilder);
        }
    }
}
