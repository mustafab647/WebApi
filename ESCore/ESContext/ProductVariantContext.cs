using ESCore.Model.Product;
using Microsoft.EntityFrameworkCore;

namespace ESCore.ESContext
{
    public class ProductVariantContext : ESDBContext
    {
        public DbSet<ProductVariant> ProductVariants { get; set; }
        public ProductVariantContext(DbContextOptions dbContextOptions) : base(dbContextOptions)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ProductVariant>().ToTable(nameof(ProductVariant));
            modelBuilder.Entity<ProductVariant>().Navigation(x => x.VariantMap).AutoInclude();
            base.OnModelCreating(modelBuilder);
        }
    }
}
