using RealEstate.DAL.Contracts;
using RealEstate.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealEstate.DAL.RepositoryContracts
{
    public interface IPropertyRepository : IBaseRepository<Property, int>
    {

        Task<Property?> GetPropertyAsync(int id);
        IQueryable<Property> GetAllWithDetailsQueryable();
        Task<Property?> DeletePropertyAsync(int id);
        IQueryable<Property> GetFilteredQuery(int? categoryId = null, int? propertyTypeId = null, decimal? maxPrice = null, decimal? minPrice = null, int? cityId = null, int? minBedrooms=null, int? maxBedrooms=null);

    }
}
