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
    public class CategoryProductMapContext : ESDBContext
    {
        //protected CategoryProductMapContext()
        //    :base("name:")
        //{
        //}
        public DbSet<CategoryProductMap> CategoryProductMaps { get; set; }
        public CategoryProductMapContext(DbContextOptions dbContextOptions) : base(dbContextOptions) { }
        //public CategoryProductMapContext(DbContextOptions<CategoryProductMapContext> dbContextOptions, IConfiguration configuration)
        //    : base(dbContextOptions, configuration)
        //{ }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>().ToTable(nameof(CategoryProductMap));
            modelBuilder.Entity<CategoryProductMap>().HasKey(x => x.Id);
            modelBuilder.Entity<CategoryProductMap>().HasOne(x => x.Category);
            modelBuilder.Entity<CategoryProductMap>().HasOne(x => x.Product);
            base.OnModelCreating(modelBuilder);
        }
    }
}
