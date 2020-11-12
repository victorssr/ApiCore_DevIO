using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VSDev.Business.Interfaces.Repositories;
using VSDev.Business.Models;
using VSDev.Data.Context;

namespace VSDev.Data.Repositories
{
    public class MoradorRepository : RepositoryBase<Morador>, IMoradorRepository
    {
        public MoradorRepository(ContextBase contextBase) : base(contextBase)
        {
        }

        public async Task<IEnumerable<Morador>> ObterMoradoresCasa(Guid idCasa)
        {
            return await _contextBase.Moradores.AsNoTracking()
                    .Where(m => m.CasaId == idCasa)
                    .ToListAsync();
        }
    }
}
