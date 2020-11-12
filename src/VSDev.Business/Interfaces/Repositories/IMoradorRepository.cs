using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using VSDev.Business.Models;

namespace VSDev.Business.Interfaces.Repositories
{
    public interface IMoradorRepository : IRepositoryBase<Morador>
    {
        Task<IEnumerable<Morador>> ObterMoradoresCasa(Guid idCasa);
    }
}
