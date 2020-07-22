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
    }
}
