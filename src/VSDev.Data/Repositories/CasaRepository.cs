using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using VSDev.Business.Interfaces.Repositories;
using VSDev.Business.Models;
using VSDev.Data.Context;

namespace VSDev.Data.Repositories
{
    public class CasaRepository : RepositoryBase<Casa>, ICasaRepository
    {
        public CasaRepository(ContextBase contextBase) : base(contextBase)
        {
        }

        public async Task<IEnumerable<Casa>> ObterCasasEndereco()
        {
            return await _contextBase.Casas.AsNoTracking()
                            .Include(c => c.Endereco)
                            .ToListAsync();
        }

        public async Task<Casa> ObterCasaEndereco(Guid id)
        {
            return await _contextBase.Casas.AsNoTracking()
                            .Include(c => c.Endereco)
                            .FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task<Casa> ObterCasaEnderecoMoradores(Guid id)
        {
            return await _contextBase.Casas.AsNoTracking()
                            .Include(c => c.Endereco)
                            .Include(c => c.Moradores)
                            .FirstOrDefaultAsync(c => c.Id == id);
        }
    }
}
