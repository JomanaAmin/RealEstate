using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealEstate.DAL.Contracts
{
    internal interface IBaseRepository <TEntity,TId> where TEntity : class
    {
        IQueryable<TEntity> GetAllQueryable ();
        IEnumerable<TEntity> GetAll ();
        TEntity? GetByID(TId id);
        void Add(TEntity entity);
        void Update(TEntity entity);
        TEntity? Delete(TId id);

    }
}
