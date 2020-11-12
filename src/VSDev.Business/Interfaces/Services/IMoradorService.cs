using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using VSDev.Business.Models;

namespace VSDev.Business.Interfaces.Services
{
    public interface IMoradorService : IServiceBase<Morador>
    {
        Task<IEnumerable<Morador>> ObterMoradoresCasa(Guid idCasa);
    }
}
