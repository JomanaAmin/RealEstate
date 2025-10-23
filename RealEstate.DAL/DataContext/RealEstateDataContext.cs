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
        public RealEstateDataContext(DbContextOptions<RealEstateDataContext> options) : base(options) { }
    }
}
