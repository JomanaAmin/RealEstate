using RealEstate.DAL.Contracts;
using RealEstate.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealEstate.DAL.RepositoryContracts
{
    internal interface IPropertyRepository : IBaseRepository<Property, int>
    {
    
    }
}
