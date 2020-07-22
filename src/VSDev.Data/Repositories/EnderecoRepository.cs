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
    }
}
