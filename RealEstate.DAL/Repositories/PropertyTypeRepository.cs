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
    internal class PropertyTypeRepository : BaseRepository<PropertyType,int>, IPropertyTypeRepository
    {
        private readonly RealEstateDataContext context;
        public PropertyTypeRepository(RealEstateDataContext context) : base(context)
        {
        }
    }
}
