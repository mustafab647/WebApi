using ESCore.Model.Product;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESCore.ESContext
{
    public class ProductSpecificationMapContext : ESDBContext
    {
        public DbSet<ProductSpecificationMap> ProductSpecificationMaps { get; set; }
        //public ProductSpecificationMapContext()
        //{ }
        public ProductSpecificationMapContext(DbContextOptions dbContextOptions) : base(dbContextOptions) { }
        //public ProductSpecificationMapContext([NotNull] DbContextOptions dbContextOptions, IConfiguration configuration) 
        //    : base(dbContextOptions, configuration) 
        //{ }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ProductSpecificationMap>().ToTable(nameof(ProductSpecificationMap));
            modelBuilder.Entity<ProductSpecificationMap>().HasKey(x => x.Id);
            //modelBuilder.Entity<ProductSpecificationMap>().HasOne(x=>x.Product).WithMany(x=>x.Specifications).HasForeignKey(x=>x.ProductId);
            //modelBuilder.Entity<ProductSpecificationMap>().HasOne(x => x.Specification).WithMany(x=>x.SpecificationMap).HasForeignKey(x=>x.SpecificationId);
            base.OnModelCreating(modelBuilder);
        }
    }
}
