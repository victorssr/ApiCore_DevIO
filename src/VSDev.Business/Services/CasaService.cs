using System.Collections.Generic;
using System.Threading.Tasks;
using VSDev.Business.Interfaces.Repositories;
using VSDev.Business.Interfaces.Services;
using VSDev.Business.Models;

namespace VSDev.Business.Services
{
    public class CasaService : ServiceBase<Casa>, ICasaService
    {
        private readonly ICasaRepository _casaRepository;

        public CasaService(ICasaRepository casaRepository)
            : base(casaRepository)
        {
            _casaRepository = casaRepository;
        }

        public async Task<IEnumerable<Casa>> ObterCasasEndereco()
        {
            return await _casaRepository.ObterCasasEndereco();
        }
    }
}
