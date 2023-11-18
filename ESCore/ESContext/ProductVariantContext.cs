using ESCore.Model.Product;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESCore.ESContext
{
    public class ProductVariantContext : ESDBContext
    {
        public DbSet<ProductVariant> ProductVariants { get; set; }
        public ProductVariantContext(DbContextOptions dbContextOptions) : base(dbContextOptions)
        {
        }

        //public ProductVariantContext()
        //{ }
        //public ProductVariantContext(DbContextOptions dbContextOptions,IConfiguration configuration)
        //    :base(dbContextOptions, configuration)
        //{

        //}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ProductVariant>().ToTable(nameof(ProductVariant));
            modelBuilder.Entity<ProductVariant>().HasKey(x => x.Id);
            modelBuilder.Entity<ProductVariant>().HasOne(x => x.Product).WithMany(x => x.Variants).HasForeignKey(x => x.ProductId);
            base.OnModelCreating(modelBuilder);
        }
    }
}
