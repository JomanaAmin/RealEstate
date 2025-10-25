using Microsoft.EntityFrameworkCore;
using RealEstate.DAL.Contracts;
using RealEstate.DAL.DataContext;
using RealEstate.DAL.Entities;
using RealEstate.DAL.RepositoryContracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealEstate.DAL.Repositories
{
    internal class PropertyRepository : BaseRepository<Property, int>, IPropertyRepository
    {
        public PropertyRepository(RealEstateDataContext context) : base(context) { }

        public async Task<Property?> GetPropertyAsync(int id)
        { 
            return await dbSet.Include(p => p.Category)
            .Include(p => p.PropertyType) 
            .Include(p => p.City) 
            .FirstOrDefaultAsync(p => p.Id == id);
        }
        public IQueryable<Property> GetAllWithDetailsQueryable() 
        {
            return dbSet.Include(p=>p.Category).Include(p=>p.PropertyType).Include(p=>p.City).AsQueryable();
        }
        public async Task<Property?> DeletePropertyAsync(int id) 
        {
            Property? toBeDeleted = await this.GetPropertyAsync(id);
            if (toBeDeleted == null) return null;
            dbSet.Remove(toBeDeleted);
            return toBeDeleted;
        }
        public IQueryable<Property> GetWithCategory(int categoryId) 
        {
            return dbSet.Where(p => p.CategoryId == categoryId).Include(p => p.Category).Include(p => p.PropertyType).AsQueryable();
        }

        public IQueryable<Property> GetFilteredQuery(int? categoryId=null, int? propertyTypeId = null, decimal? maxPrice=null, decimal? minPrice=null, int? cityId=null) 
        {
            IQueryable<Property> query = dbSet.Include(p => p.Category).Include(p => p.City).Include(p => p.PropertyType);
            //i created a query that has the whole table, then im gonna check each filter and add it to the query
            if (categoryId != null)
            {
                query = query.Where(p => p.CategoryId == categoryId);
            }
            if (propertyTypeId != null)
            {
                query = query.Where(p => p.PropertyTypeId == propertyTypeId);
            }
            if (maxPrice != null)
            {
                query = query.Where(p => p.Price <= maxPrice);
            }
            if (minPrice != null)
            {
                query = query.Where(p => p.Price >= minPrice);
            }
            if (cityId != null)
            {
                query = query.Where(p => p.CityId == cityId);
            }



            ///
            return query.AsQueryable();
        }


    }
}