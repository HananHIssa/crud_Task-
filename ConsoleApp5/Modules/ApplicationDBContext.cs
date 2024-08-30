using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleApp5.content;
using Microsoft.EntityFrameworkCore;

namespace ConsoleApp5.Modules
{
    internal class ApplicationDBContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=.;Database=MyDatabase;Trusted_Connection=True;");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Order>().Property(o => o.CreatedAt).HasDefaultValueSql("GETDATE()");
        }
        public DbSet<Product> Products { get; set;}
        public DbSet<Order> Orders { get; set; }

    }
}
