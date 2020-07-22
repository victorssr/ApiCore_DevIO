using VSDev.Business.Interfaces.Repositories;
using VSDev.Business.Interfaces.Services;
using VSDev.Business.Models;

namespace VSDev.Business.Services
{
    public class MoradorService : ServiceBase<Morador>, IMoradorService
    {
        private readonly IMoradorRepository _moradorRepository;

        public MoradorService(IMoradorRepository moradorRepository) : base(moradorRepository)
        {
            _moradorRepository = moradorRepository;
        }
    }
}
