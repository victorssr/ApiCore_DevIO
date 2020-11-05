using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
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
    }
}
