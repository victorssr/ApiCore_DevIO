using VSDev.Business.Interfaces.Repositories;
using VSDev.Business.Interfaces.Services;
using VSDev.Business.Models;

namespace VSDev.Business.Services
{
    public class DespesaIndividualService : ServiceBase<DespesaIndividual>, IDespesaIndividualService
    {
        private readonly IDespesaIndividualRepository _despesaIndividualRepository;

        public DespesaIndividualService(IDespesaIndividualRepository despesaIndividualRepository)
            : base(despesaIndividualRepository)
        {
            _despesaIndividualRepository = despesaIndividualRepository;
        }
    }
}
