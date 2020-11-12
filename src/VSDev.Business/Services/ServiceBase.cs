using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using VSDev.Business.Interfaces.Repositories;
using VSDev.Business.Interfaces.Services;
using VSDev.Business.Models;

namespace VSDev.Business.Services
{
    public class ServiceBase<TEntity> : IServiceBase<TEntity> where TEntity : MainEntity
    {
        private readonly IRepositoryBase<TEntity> _repositoryBase;

        public ServiceBase(IRepositoryBase<TEntity> repositoryBase)
        {
            _repositoryBase = repositoryBase;
        }

        public async Task Add(TEntity entity)
        {
            await _repositoryBase.Add(entity);
        }

        public async Task Update(TEntity entity)
        {
            await _repositoryBase.Update(entity);
        }

        public virtual async Task Delete(Guid id)
        {
            await _repositoryBase.Delete(id);
        }

        public async Task<IEnumerable<TEntity>> GetAll()
        {
            return await _repositoryBase.GetAll();
        }

        public async Task<TEntity> GetById(Guid id)
        {
            return await _repositoryBase.GetById(id);
        }

        public async Task<TEntity> GetByIdAsNoTracking(Guid id)
        {
            return await _repositoryBase.GetByIdAsNoTracking(id);
        }

        public void Dispose()
        {
            _repositoryBase.Dispose();
        }
    }
}
