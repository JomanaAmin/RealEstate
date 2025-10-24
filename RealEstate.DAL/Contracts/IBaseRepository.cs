using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealEstate.DAL.Contracts
{
    public interface IBaseRepository <TEntity,TId> where TEntity : class
    {
        IQueryable<TEntity> GetAllQueryable ();
        Task<IEnumerable<TEntity>> GetAllAsync ();
        IEnumerable<TEntity> GetAll ();
        Task<TEntity?> GetByIdAsync(TId id);
        TEntity? GetById(TId id);
        Task AddAsync(TEntity entity);
        void Add(TEntity entity);
        //update & delete cant be async as they happen in memory, save changes is what needs to be async
        void Update(TEntity entity);
        TEntity? Delete(TId id);
        Task<long> CountAsync();
        long Count();

    }
}
