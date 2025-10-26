using RealEstate.DAL.Entities;
using RealEstate.DAL.RepositoryContracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RealEstate.DAL.DataContext;
using Microsoft.EntityFrameworkCore;


namespace RealEstate.DAL.Repositories
{
    internal class PropertyImageRepository : BaseRepository<PropertyImage,int>,IPropertyImageRepository
    {
        public PropertyImageRepository(RealEstateDataContext context) : base(context)
        {
        }
        public async Task AddImagesRangeAsync(IEnumerable<PropertyImage> propertyImages) 
        {
            await dbSet.AddRangeAsync(propertyImages);
        }
        public async Task<List<PropertyImage>> DeleteImagesRangeAsync(IEnumerable<int> ids) 
        {
            var toBeDeleted = await dbSet.Where(img => ids.Contains(img.Id)).ToListAsync();
            if (toBeDeleted.Any()) 
            {
                dbSet.RemoveRange(toBeDeleted);
            }
            return toBeDeleted;
        }
    }
}
