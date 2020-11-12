using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using VSDev.Business.Models;

namespace VSDev.Business.Interfaces.Repositories
{
    public interface ICasaRepository : IRepositoryBase<Casa>
    {
        Task<IEnumerable<Casa>> ObterCasasEndereco();
        Task<Casa> ObterCasaEndereco(Guid id);
    }
}
