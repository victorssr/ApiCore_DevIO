using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VSDev.Business.Interfaces.Repositories;
using VSDev.Business.Interfaces.Services;
using VSDev.Business.Models;

namespace VSDev.Business.Services
{
    public class CasaService : ServiceBase<Casa>, ICasaService
    {
        private readonly ICasaRepository _casaRepository;
        private readonly IEnderecoService _enderecoService;
        private readonly IMoradorService _moradorService;

        public CasaService(ICasaRepository casaRepository,
                           IEnderecoService enderecoService,
                           IMoradorService moradorService) : base(casaRepository)
        {
            _casaRepository = casaRepository;
            _enderecoService = enderecoService;
            _moradorService = moradorService;
        }

        public async Task<IEnumerable<Casa>> ObterCasasEndereco()
        {
            return await _casaRepository.ObterCasasEndereco();
        }

        public async Task<Casa> ObterCasaEndereco(Guid id)
        {
            return await _casaRepository.ObterCasaEndereco(id);
        }

        public async override Task Delete(Guid id)
        {
            var endereco = await _enderecoService.ObterEnderecoCasa(id);
            if (endereco != null) await _enderecoService.Delete(endereco.Id);

            var moradores = await _moradorService.ObterMoradoresCasa(id);
            foreach (var morador in moradores) await _moradorService.Delete(morador.Id);

            await base.Delete(id);
        }

        public async Task<Casa> ObterCasaEnderecoMoradores(Guid id)
        {
            return await _casaRepository.ObterCasaEnderecoMoradores(id);
        }
    }
}
