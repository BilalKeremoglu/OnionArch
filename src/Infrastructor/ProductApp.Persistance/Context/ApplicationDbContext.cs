using Microsoft.EntityFrameworkCore;
using ProductApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductApp.Persistance.Context
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Product> products { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>().HasData(
                new Product()
                {
                    Id = Guid.NewGuid(),
                    Name = "Pen",
                    Quantity = 100,
                    Value = 10,
                    CreateDate = DateTime.Now
                },
                new Product()
                {
                    Id = Guid.NewGuid(),
                    Name = "Paper",
                    Quantity = 100,
                    Value = 1,
                    CreateDate = DateTime.Now
                });
            base.OnModelCreating(modelBuilder);
        }
    }
}
