using ESCore.Model.Product;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESCore.ESContext
{
    public class CategoryContext : ESDBContext
    {
        //public CategoryContext()
        //{ }
        public DbSet<Category> Categories { get; set; }

        public CategoryContext(DbContextOptions options) : base(options) { }
        //public CategoryContext(DbContextOptions dbContextOptions, IConfiguration configuration) : base(dbContextOptions, configuration) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>().ToTable(nameof(Category));
            modelBuilder.Entity<Category>().HasKey(x => x.Id);
            modelBuilder.Entity<Category>().HasOne(x => x.ParentCategory)
                .WithMany(x => x.ChildCategories)
                .HasForeignKey(x=>x.ParentId);

            modelBuilder.Entity<Category>()
                .HasMany(x => x.ChildCategories)
                .WithOne(x => x.ParentCategory)
                .HasForeignKey(x => x.ParentId);

            base.OnModelCreating(modelBuilder);
        }
    }
}
