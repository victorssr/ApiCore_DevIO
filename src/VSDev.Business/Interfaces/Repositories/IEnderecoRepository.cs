using System;
using System.Threading.Tasks;
using VSDev.Business.Models;

namespace VSDev.Business.Interfaces.Repositories
{
    public interface IEnderecoRepository : IRepositoryBase<Endereco>
    {
        Task<Endereco> ObterEnderecoCasa(Guid idCasa);
    }
}
