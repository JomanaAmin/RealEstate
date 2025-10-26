using RealEstate.DAL.Contracts;
using RealEstate.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealEstate.DAL.RepositoryContracts
{
    public interface IPropertyImageRepository : IBaseRepository<PropertyImage, int>
    {
        Task AddImagesRangeAsync(IEnumerable<PropertyImage> propertyImages);
        Task<List<PropertyImage>> DeleteImagesRangeAsync(IEnumerable<int> ids);

    }
}
