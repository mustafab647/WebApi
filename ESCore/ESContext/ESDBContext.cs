using Microsoft.EntityFrameworkCore;
using ESCore.Model.Product;
using ESCore.Model;
using ESCore.Model.Authentication;
using Microsoft.EntityFrameworkCore.Infrastructure;
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
        public ESDBContext(DbContextOptions dbContextOptions) : base(dbContextOptions)
        {
        }
        //public ESDBContext(DbContextOptions dbContextOptions,IConfiguration configration)
        //    : base(dbContextOptions)
        //{
        //    _connectionString = configration.GetConnectionString("MsSqlConnStr") ?? "";
        //}

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    //optionsBuilder.UseSqlServer(x => x.MigrationsAssembly("WebApi"));
        //    //optionsBuilder.UseSqlServer(_connectionString);
        //    base.OnConfiguring(optionsBuilder);
        //}
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>().ToTable(nameof(Category)).HasMany(x => x.ChildCategories);
            modelBuilder.Entity<CategoryProductMap>().ToTable(nameof(CategoryProductMap));//.HasKey(x => x.Id);
            modelBuilder.Entity<Currency>().ToTable(nameof(Currency));//.HasKey(x => x.Id);
            modelBuilder.Entity<Product>().ToTable(nameof(Product));//.HasKey(x => x.Id);
            
            modelBuilder.Entity<ProductSpecificationMap>().ToTable(nameof(ProductSpecificationMap));//.HasKey(x => x.Id);
            modelBuilder.Entity<ProductVariant>().ToTable(nameof(ProductVariant));//.HasKey(x => x.Id);
            modelBuilder.Entity<SpecificationType>().ToTable(nameof(SpecificationType));//.HasKey(x=>x.Id);
            modelBuilder.Entity<Specification>().ToTable(nameof(Specification));//.HasKey(x => x.Id);
            modelBuilder.Entity<VariantType>().ToTable(nameof(VariantType));//.HasKey(x => x.Id);
            modelBuilder.Entity<VariantTypeValue>().ToTable(nameof(VariantTypeValue));//.HasKey(x => x.Id);
            modelBuilder.Entity<ProductImage>().ToTable(nameof(ProductImage));//.HasKey(x => x.Id);
            modelBuilder.Entity<ProductVariantMap>().ToTable(nameof(ProductVariantMap));//.HasKey(x => x.Id);

            modelBuilder.Entity<Product>().Navigation(x => x.Variants).UsePropertyAccessMode(PropertyAccessMode.Field).AutoInclude();
            modelBuilder.Entity<ProductVariant>().Navigation(x => x.VariantMap).AutoInclude();
            modelBuilder.Entity<Product>().HasMany(x=>x.Variants).WithOne(x=>x.Product).HasForeignKey(x=>x.ProductId).HasPrincipalKey(x=>x.Id).IsRequired();

            modelBuilder.Entity<User>().ToTable("ApiUser");
            base.OnModelCreating(modelBuilder);
        }

        //protected override void OnModelCreating(DbModelBuilder modelBuilder)
        //{
        //    base.OnModelCreating(modelBuilder);
        //}
    }
}
