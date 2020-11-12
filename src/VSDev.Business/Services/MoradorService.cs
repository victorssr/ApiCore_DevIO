using System;
using System.Collections.Generic;
using System.Threading.Tasks;
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

        public async Task<IEnumerable<Morador>> ObterMoradoresCasa(Guid idCasa)
        {
            return await _moradorRepository.ObterMoradoresCasa(idCasa);
        }
    }
}
