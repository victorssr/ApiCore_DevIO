using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using VSDev.Business.Models;

namespace VSDev.Business.Interfaces.Repositories
{
    public interface IRepositoryBase<TEntity> : IDisposable where TEntity : MainEntity
    {
        Task Add(TEntity entity);
        Task Update(TEntity entity);
        Task Delete(Guid id);
        Task<TEntity> GetById(Guid id);
        Task<TEntity> GetByIdAsNoTracking(Guid id);
        Task<IEnumerable<TEntity>> GetAll();
        Task<int> SaveChanges();
    }
}
