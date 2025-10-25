using RealEstate.DAL.Contracts;
using RealEstate.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealEstate.DAL.RepositoryContracts
{
    public interface ICityRepository:IBaseRepository<City,int>
    {
    }
}
