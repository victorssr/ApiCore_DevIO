using VSDev.Business.Interfaces.Repositories;
using VSDev.Business.Models;
using VSDev.Data.Context;

namespace VSDev.Data.Repositories
{
    public class DespesaIndividualRepository : RepositoryBase<DespesaIndividual>, IDespesaIndividualRepository
    {
        public DespesaIndividualRepository(ContextBase contextBase) : base(contextBase)
        {
        }
    }
}
