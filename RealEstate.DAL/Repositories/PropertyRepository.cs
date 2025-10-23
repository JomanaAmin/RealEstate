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
    }
}