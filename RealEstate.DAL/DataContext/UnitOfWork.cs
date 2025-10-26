using RealEstate.DAL.Contracts;
using RealEstate.DAL.Repositories;
using RealEstate.DAL.RepositoryContracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealEstate.DAL.DataContext
{
    internal class UnitOfWork : IUnitOfWork
    {
        private readonly RealEstateDataContext context;
        private Lazy<ICategoryRepository> categories;
        private IPropertyRepository properties;
        private IPropertyTypeRepository propertyTypes;
        private ICityRepository cities;
        private IPropertyImageRepository propertyImages;


        public UnitOfWork(RealEstateDataContext context) 
        {
            this.context = context;
            categories = new Lazy<ICategoryRepository>(() => new CategoryRepository(context));
        }

        public ICategoryRepository Categories => categories.Value;
        public IPropertyRepository Properties => properties ?? (properties= new PropertyRepository(context));
        public IPropertyTypeRepository PropertyTypes=> propertyTypes ?? (propertyTypes= new PropertyTypeRepository(context));
        public ICityRepository Cities => cities ?? (cities = new CityRepository(context));
        public IPropertyImageRepository PropertyImages => propertyImages ?? (propertyImages = new PropertyImageRepository(context));
        public void SaveChanges()
        { 
            context.SaveChanges();
        }
        public async Task SaveChangesAsync()
        {
            await context.SaveChangesAsync();
        }
    }
}
