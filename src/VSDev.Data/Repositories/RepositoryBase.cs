using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using VSDev.Business.Interfaces.Repositories;
using VSDev.Business.Models;
using VSDev.Data.Context;

namespace VSDev.Data.Repositories
{
    public class RepositoryBase<TEntity> : IRepositoryBase<TEntity> where TEntity : MainEntity, new()
    {
        protected readonly ContextBase _contextBase;
        protected readonly DbSet<TEntity> _entity;

        public RepositoryBase(ContextBase contextBase)
        {
            _contextBase = contextBase;
            _entity = contextBase.Set<TEntity>();
        }

        public virtual async Task Add(TEntity entity)
        {
            _entity.Add(entity);
            await SaveChanges();
        }

        public virtual async Task Delete(Guid id)
        {
            _entity.Remove(new TEntity { Id = id });
            await SaveChanges();
        }

        public virtual async Task<IEnumerable<TEntity>> GetAll()
        {
            return await _entity.ToListAsync();
        }

        public virtual async Task<TEntity> GetById(Guid id)
        {
            return await _entity.FindAsync(id);
        }

        public virtual async Task<TEntity> GetByIdAsNoTracking(Guid id)
        {            
            var entity = await _entity.FindAsync(id);

            _contextBase.Entry(entity).State = EntityState.Detached;

            return entity;
        }

        public virtual async Task Update(TEntity entity)
        {
            _entity.Update(entity);
            await SaveChanges();
        }


        public async Task<int> SaveChanges()
        {
            return await _contextBase.SaveChangesAsync();
        }

        public void Dispose()
        {
            _contextBase?.Dispose();
        }
    }
}
