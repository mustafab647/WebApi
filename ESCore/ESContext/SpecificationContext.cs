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
    public class SpecificationContext : ESDBContext
    {
        public DbSet<Specification> Specifications { get; set; }
        //public SpecificationContext() { }

        public SpecificationContext(DbContextOptions dbContextOptions) : base(dbContextOptions) { }
        //public SpecificationContext(DbContextOptions dbContextOptions, IConfiguration configuration) : base(dbContextOptions, configuration) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Specification>().ToTable(nameof(Specification));
            modelBuilder.Entity<Specification>().HasKey(x => x.Id);
            
            base.OnModelCreating(modelBuilder);
        }
    }
}
