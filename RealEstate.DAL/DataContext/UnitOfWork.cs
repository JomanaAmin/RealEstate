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

        public UnitOfWork(RealEstateDataContext context) 
        {
            this.context = context;
            categories = new Lazy<ICategoryRepository>(() => new CategoryRepository(context));
        }

        public ICategoryRepository Categories => categories.Value;
        public IPropertyRepository Properties => properties ?? (properties= new PropertyRepository(context));

        public void SaveChanges()
        { 
            context.SaveChanges();
        }
    }
}
