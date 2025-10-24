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
    }
}
