using Microsoft.EntityFrameworkCore;
using RealEstate.DAL.Contracts;
using RealEstate.DAL.DataContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealEstate.DAL.Repositories
{
    internal class BaseRepository <TEntity, TId> : IBaseRepository<TEntity, TId> where TEntity : class
    {
        private readonly RealEstateDataContext context;
        protected readonly DbSet<TEntity> dbSet;

        public BaseRepository(RealEstateDataContext context) 
        {
            this.context = context;
            dbSet=context.Set<TEntity>();
        }


        public void Add(TEntity entity)
        {
            this.dbSet.Add(entity);
        }
        public async Task AddAsync(TEntity entity)
        {
            await this.dbSet.AddAsync(entity);
        }
        
        public IEnumerable<TEntity> GetAll()
        {
            return dbSet.ToList();
        }
        public async Task<IEnumerable<TEntity>> GetAllAsync()
        {
            return await dbSet.ToListAsync();
        }

        public IQueryable<TEntity> GetAllQueryable()
        {
             return dbSet.AsQueryable();
        }

        public TEntity? GetById(TId id)
        {
            return this.dbSet.Find(id);

        }
        public async Task<TEntity?> GetByIdAsync(TId id)
        {
            return await this.dbSet.FindAsync(id);

        }
        //update & delete cant be async as they happen in memory, save changes is what needs to be async
        public void Update(TEntity entity)
        {
            this.dbSet.Update(entity);
        }
       
        /// //////////
    
        public TEntity? Delete(TId id)
        {
            var entity = this.GetById(id);
            if (entity != null) 
            {
                this.dbSet.Remove(entity);
                return entity;
            }
            return null;

        }

        public async Task<TEntity?> DeleteAsync(TId id) 
        {
            TEntity? entity = await this.GetByIdAsync(id);
            if (entity!=null) 
            {
                this.dbSet.Remove(entity);
                return entity;
            }
            return null;
        }
        /// /////////////////////
        public async Task<long> CountAsync()
        {
            return await dbSet.LongCountAsync();
        }

        public long Count() 
        {
            return this.dbSet.LongCount<TEntity>();
        }


    }
}
