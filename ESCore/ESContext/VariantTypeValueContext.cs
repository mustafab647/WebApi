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
    public class VariantTypeValueContext : ESDBContext
    {
        public DbSet<VariantTypeValue> VariantTypeValues { get; set; }
        public VariantTypeValueContext(DbContextOptions dbContextOptions) : base(dbContextOptions)
        {
        }

        //public VariantTypeValueContext()
        //{ }

        //public VariantTypeValueContext(DbContextOptions dbContextOptions, IConfiguration configuration)
        //    : base(dbContextOptions, configuration) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<VariantTypeValue>().ToTable(nameof(VariantTypeValue));
            modelBuilder.Entity<VariantTypeValue>().HasKey(x => x.Id);
            modelBuilder.Entity<VariantTypeValue>().HasOne(x=>x.VariantType).WithMany(x=>x.Values).HasForeignKey(x=>x.VariantTypeId);
            base.OnModelCreating(modelBuilder);
        }
    }
}
