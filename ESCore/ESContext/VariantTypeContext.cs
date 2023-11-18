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
    public class VariantTypeContext : ESDBContext
    {
        public DbSet<VariantType> VariantTypes { get; set; }
        public VariantTypeContext(DbContextOptions dbContextOptions) : base(dbContextOptions)
        {
        }

        //public VariantTypeContext()
        //{ }

        //public VariantTypeContext(DbContextOptions dbContextOptions, IConfiguration configuration)
        //    : base(dbContextOptions, configuration) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<VariantType>().ToTable(nameof(VariantType));
            modelBuilder.Entity<VariantType>().HasKey(x => x.Id);
            
            base.OnModelCreating(modelBuilder);
        }
    }
}
