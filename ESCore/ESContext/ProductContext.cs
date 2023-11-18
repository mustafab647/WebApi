using ESCore.Model.Product;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DbContext = System.Data.Entity.DbContext;

namespace ESCore.ESContext
{
    public class ProductContext : ESDBContext
    {
        public Microsoft.EntityFrameworkCore.DbSet<Product> Products { get; private set; }
        //public ProductContext()
        //{ }
        public ProductContext(DbContextOptions dbContextOptions) : base(dbContextOptions) { }
        //public ProductContext([NotNull] DbContextOptions<ProductContext> options, IConfiguration configuration)
        //    : base(options, configuration)
        //{
        //}
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>().ToTable(nameof(Product));
            modelBuilder.Entity<Product>().HasKey(x => x.Id);
            modelBuilder.Entity<Product>().HasMany<CategoryProductMap>(x => x.Categories)
                .WithOne(x=>x.Product)
                .HasForeignKey(x => x.ProductId);
            modelBuilder.Entity<Product>().Property<decimal>(x => x.ListPrice).HasDefaultValue(0).HasColumnType<decimal>("decimal(20,2");
            modelBuilder.Entity<Product>().Property<decimal>(x => x.Price).HasDefaultValue(0).HasColumnType<decimal>("decimal(20,2");

            modelBuilder.Entity<Product>().HasMany<ProductSpecificationMap>(x => x.Specifications)
                .WithOne(x => x.Product)
                .HasForeignKey(x => x.ProductId);
            
            base.OnModelCreating(modelBuilder);
        }
    }
}
