using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Infrastructure.Internal;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore.Infrastructure;
using ESCore.Model.Product;
using ESCore.Model;
using ESCore.Model.Authentication;
//using System.Data.Entity;

namespace ESCore.ESContext
{
    public class ESDBContext : Microsoft.EntityFrameworkCore.DbContext
    {
        private const string _tenantIdKey = "TenantID";
        public DbSet<Category> Categories { get; set; }
        public DbSet<CategoryProductMap> CategoryProductMaps { get; set; }
        public DbSet<Currency> Currencies { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductImage> ProductImages { get; set; }
        public DbSet<ProductSpecificationMap> ProductSpecificationMaps { get; set; }
        public DbSet<ProductVariant> ProductVariants { get; set; }
        public DbSet<SpecificationType> SpecificationTypes { get; set; }
        public DbSet<Specification> Specifications { get; set; }
        public DbSet<VariantType> VariantTypes { get; set; }
        public DbSet<VariantTypeValue> VariantTypeValues { get; set; }
        public DbSet<User> Users { get; set; }

        //public ESDBContext(string connectionString) : base(connectionString) { }
        public ESDBContext(DbContextOptions<ESDBContext> dbContextOptions) : base(dbContextOptions)
        {
        }
        //public ESDBContext(DbContextOptions dbContextOptions,IConfiguration configration)
        //    : base(dbContextOptions)
        //{
        //    _connectionString = configration.GetConnectionString("MsSqlConnStr") ?? "";
        //}

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //optionsBuilder.UseSqlServer(x => x.MigrationsAssembly("WebApi"));
            //optionsBuilder.UseSqlServer(_connectionString);
            base.OnConfiguring(optionsBuilder);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>().ToTable(nameof(Category)).HasMany(x => x.ChildCategories);
            modelBuilder.Entity<CategoryProductMap>().ToTable(nameof(CategoryProductMap));
            modelBuilder.Entity<Currency>().ToTable(nameof(Currency));
            modelBuilder.Entity<Product>().ToTable(nameof(Product)).HasMany(x => x.Categories);
            modelBuilder.Entity<ProductSpecificationMap>().ToTable(nameof(ProductSpecificationMap));
            modelBuilder.Entity<ProductVariant>().ToTable(nameof(ProductVariant));
            modelBuilder.Entity<SpecificationType>().ToTable(nameof(SpecificationType));
            modelBuilder.Entity<Specification>().ToTable(nameof(Specification));
            modelBuilder.Entity<VariantType>().ToTable(nameof(VariantType));
            modelBuilder.Entity<VariantTypeValue>().ToTable(nameof(VariantTypeValue));
            modelBuilder.Entity<ProductImage>().ToTable(nameof(ProductImage));
            modelBuilder.Entity<ProductVariantMap>().ToTable(nameof(ProductVariantMap));
            modelBuilder.Entity<User>().ToTable("ApiUser");
            base.OnModelCreating(modelBuilder);
        }

        //protected override void OnModelCreating(DbModelBuilder modelBuilder)
        //{
        //    base.OnModelCreating(modelBuilder);
        //}
    }
}
