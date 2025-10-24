using Microsoft.EntityFrameworkCore;
using RealEstate.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealEstate.DAL.DataContext
{
    internal class RealEstateDataContext: DbContext 
    {
        public DbSet<Property> properties { get; set; }
        public DbSet<Category> categories { get; set; }
        public DbSet<PropertyType> propertyTypes { get; set; }
        public RealEstateDataContext(DbContextOptions<RealEstateDataContext> options) : base(options) { }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Seed default categories
            modelBuilder.Entity<Category>().HasData(
                new Category { Id=-1,Name = "Primary", Description = "C1" },
                new Category { Id=-2,Name = "Rent", Description = "C2" },
                new Category { Id=-3,Name = "Resell", Description = "C3" }
            );
            modelBuilder.Entity<PropertyType>().HasData(
                new Category { Id=-1,Name = "Flat", Description = "D1" },
                new Category { Id=-2,Name = "Villa", Description = "D2" },
                new Category { Id=-3,Name = "TownHouse", Description = "D3" }
            );
        }
    }
}
