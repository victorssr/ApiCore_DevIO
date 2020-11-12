using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using VSDev.Business.Models;

namespace VSDev.Business.Interfaces.Services
{
    public interface ICasaService : IServiceBase<Casa>
    {
        Task<IEnumerable<Casa>> ObterCasasEndereco();
        Task<Casa> ObterCasaEndereco(Guid id);
    }
}
