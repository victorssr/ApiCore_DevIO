using System;
using System.Threading.Tasks;
using VSDev.Business.Interfaces.Repositories;
using VSDev.Business.Interfaces.Services;
using VSDev.Business.Models;

namespace VSDev.Business.Services
{
    public class EnderecoService : ServiceBase<Endereco>, IEnderecoService
    {
        private readonly IEnderecoRepository _enderecoRepository;

        public EnderecoService(IEnderecoRepository enderecoRepository) : base(enderecoRepository)
        {
            _enderecoRepository = enderecoRepository;
        }

        public async Task<Endereco> ObterEnderecoCasa(Guid idCasa)
        {
            return await _enderecoRepository.ObterEnderecoCasa(idCasa);
        }
    }
}
