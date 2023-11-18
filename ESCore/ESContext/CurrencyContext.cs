using ESCore.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESCore.ESContext
{
    public class CurrencyContext : ESDBContext
    {
        //public CurrencyContext()
        //{ }
        public DbSet<Currency> Currencies { get; set; }
        public CurrencyContext(DbContextOptions dbContextOptions) : base(dbContextOptions) { } 
        //public CurrencyContext(DbContextOptions dbContextOptions, IConfiguration configuration)
        //    : base(dbContextOptions, configuration) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Currency>().ToTable(nameof(Currency));
            modelBuilder.Entity<Currency>().HasKey(x => x.Id);
            base.OnModelCreating(modelBuilder);
        }
    }
}
