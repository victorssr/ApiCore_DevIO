using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;
using VSDev.Business.Interfaces.Repositories;
using VSDev.Business.Models;
using VSDev.Data.Context;

namespace VSDev.Data.Repositories
{
    public class EnderecoRepository : RepositoryBase<Endereco>, IEnderecoRepository
    {
        public EnderecoRepository(ContextBase contextBase) : base(contextBase)
        {
        }

        public async Task<Endereco> ObterEnderecoCasa(Guid idCasa)
        {
            return await _contextBase.Enderecos.AsNoTracking()
                    .FirstOrDefaultAsync(e => e.CasaId == idCasa);
        }
    }
}
