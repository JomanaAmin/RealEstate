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
        public DbSet<PropertyImage> propertyImages { get; set; }

        public DbSet<City> cities { get; set; }
        public RealEstateDataContext(DbContextOptions<RealEstateDataContext> options) : base(options) { }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Seed default categories
            modelBuilder.Entity<Category>().HasData(
                new Category { Id=1,Name = "Primary", Description = "C1" },
                new Category { Id=2,Name = "Rent", Description = "C2" },
                new Category { Id=3,Name = "Resell", Description = "C3" }
            );
            modelBuilder.Entity<PropertyType>().HasData(
                new PropertyType { Id=1,Name = "Flat", Description = "D1" },
                new PropertyType { Id=2,Name = "Villa", Description = "D2" },
                new PropertyType { Id=3,Name = "TownHouse", Description = "D3" }
            );
            modelBuilder.Entity<City>().HasData(
            new City { Id = 1, Name = "Cairo" },
            new City { Id = 2, Name = "Giza"},
            new City { Id = 3, Name = "6th of October"},
            new City { Id = 4, Name = "Sheikh Zayed"},
            new City { Id = 5, Name = "New Cairo"},
            new City { Id = 6, Name = "Nasr City"},
            new City { Id = 7, Name = "Maadi" },
            new City { Id = 8, Name = "Heliopolis"}
        );
        }
    }
}
