using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using VSDev.Api.DTOs;
using VSDev.Business.Interfaces;
using VSDev.Business.Interfaces.Services;
using VSDev.Business.Models;

namespace VSDev.Api.Controllers.V1
{
    [ApiVersion("1.0")]
    [Authorize]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class EnderecoController : MainController
    {
        private readonly IEnderecoService _enderecoService;
        private readonly IMapper _mapper;

        public EnderecoController(INotificator notificator,
                                     IUser user,
                                     IEnderecoService enderecoService,
                                     IMapper mapper) : base(notificator, user)
        {
            _enderecoService = enderecoService;
            _mapper = mapper;
        }

        [HttpPut("{id:guid}")]
        public async Task<IActionResult> Atualizar(Guid id, EnderecoViewModel enderecoViewModel)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);

            var endereco = await _enderecoService.GetByIdAsNoTracking(id);
            if (endereco == null) return NotFound("Endereço não encontrado.");

            if (endereco.Id != enderecoViewModel.Id)
                return BadRequest("O Id informado na rota está diferente do id informado no payload.");

            await _enderecoService.Update(_mapper.Map<Endereco>(enderecoViewModel));

            return CustomResponse("Endereço atualizado com sucesso!");
        }
    }
}
