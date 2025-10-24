using RealEstate.DAL.RepositoryContracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealEstate.DAL.Contracts
{
    public interface IUnitOfWork
    {
        public IPropertyRepository Properties { get; }
        public ICategoryRepository Categories { get; }
        void SaveChanges();
        Task SaveChangesAsync();

    }
}
