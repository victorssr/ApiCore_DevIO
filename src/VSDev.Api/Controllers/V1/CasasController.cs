using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Swashbuckle.AspNetCore.Annotations;
using VSDev.Api.DTOs;
using VSDev.Api.Extensions;
using VSDev.Business.Interfaces;
using VSDev.Business.Interfaces.Services;
using VSDev.Business.Models;

namespace VSDev.Api.Controllers.V1
{
    [ApiVersion("1.0")]
    [Authorize]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class CasasController : MainController
    {
        private readonly ICasaService _casaService;
        private readonly IMapper _mapper;
        private readonly INotificator _notificator;

        public CasasController(ICasaService casaService, IMapper mapper, INotificator notificator, IUser user)
            : base(notificator, user)
        {
            _casaService = casaService;
            _mapper = mapper;
            _notificator = notificator;
        }

        [HttpGet]
        [SwaggerResponse(StatusCodes.Status200OK, "", typeof(IEnumerable<CasaViewModel>))]
        public async Task<IEnumerable<CasaViewModel>> ObterTodos()
        {
            return _mapper.Map<IEnumerable<CasaViewModel>>(await _casaService.ObterCasasEndereco());
        }

        [ClaimnsAuthorize("Casas", "Detalhe")]
        [HttpGet("{id:guid}")]
        [SwaggerResponse(StatusCodes.Status200OK, "", typeof(CasaViewModel))]
        public async Task<ActionResult<CasaViewModel>> ObterPorId(Guid id)
        {
            var casa = await _casaService.GetById(id);

            if (casa == null) return NotFound();

            return _mapper.Map<CasaViewModel>(casa);
        }

        [ClaimnsAuthorize("Casas", "Atualizar")]
        [HttpPut("{id:guid}")]
        [SwaggerResponse(StatusCodes.Status200OK, "", typeof(string))]
        public async Task<IActionResult> Atualizar(Guid id, CasaViewModel casaViewModel)
        {
            if (!CasaExists(id)) return NotFound();

            if (!ModelState.IsValid) return CustomResponse(ModelState);

            if (id != casaViewModel.Id)
            {
                NotificarErro("Id informado está diferente do Id informado na query");
                return CustomResponse();
            }

            await _casaService.Update(_mapper.Map<Casa>(casaViewModel));

            return CustomResponse();
        }

        [ClaimnsAuthorize("Casas", "Adicionar")]
        [HttpPost]
        [SwaggerResponse(StatusCodes.Status200OK, "", typeof(CasaViewModel))]
        public async Task<ActionResult<CasaViewModel>> Cadastrar(CasaViewModel casaViewModel)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);

            await _casaService.Add(_mapper.Map<Casa>(casaViewModel));

            return CustomResponse(casaViewModel);
        }

        [ClaimnsAuthorize("Casas", "Excluir")]
        [HttpDelete("{id:guid}")]
        [SwaggerResponse(StatusCodes.Status200OK, "", typeof(string))]
        public async Task<ActionResult<CasaViewModel>> Excluir(Guid id)
        {
            if (!CasaExists(id)) return NotFound();

            await _casaService.Delete(id);

            return CustomResponse();
        }


        private bool CasaExists(Guid id)
        {
            return _casaService.GetByIdAsNoTracking(id).Result != null;
        }
    }
}
