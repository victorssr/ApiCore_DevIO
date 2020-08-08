using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using VSDev.Api.DTOs;
using VSDev.Api.Extensions;
using VSDev.Business.Interfaces;
using VSDev.Business.Interfaces.Services;
using VSDev.Business.Models;

namespace VSDev.Api.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    public class CasasController : MainController
    {
        private readonly ICasaService _casaService;
        private readonly IMapper _mapper;
        private readonly INotificator _notificator;

        public CasasController(ICasaService casaService, IMapper mapper, INotificator notificator)
            : base(notificator)
        {
            _casaService = casaService;
            _mapper = mapper;
            _notificator = notificator;
        }

        [HttpGet]
        public async Task<IEnumerable<CasaViewModel>> ObterTodos()
        {
            return _mapper.Map<IEnumerable<CasaViewModel>>(await _casaService.GetAll());
        }

        [ClaimnsAuthorize("Casas", "Detalhe")]
        [HttpGet("{id:guid}")]
        public async Task<ActionResult<CasaViewModel>> ObterPorId(Guid id)
        {
            var casa = await _casaService.GetById(id);

            if (casa == null) return NotFound();

            return _mapper.Map<CasaViewModel>(casa);
        }

        [ClaimnsAuthorize("Casas", "Atualizar")]
        [HttpPut("{id:guid}")]
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

        [ClaimnsAuthorize("Casas", "Cadastrar")]
        [HttpPost]
        public async Task<ActionResult<CasaViewModel>> Cadastrar(CasaViewModel casaViewModel)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);

            await _casaService.Add(_mapper.Map<Casa>(casaViewModel));

            return CustomResponse(casaViewModel);
        }

        [ClaimnsAuthorize("Casas", "Excluir")]
        [HttpDelete("{id:guid}")]
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
