using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using VSDev.Api.DTOs;
using VSDev.Business.Interfaces.Services;
using VSDev.Business.Models;

namespace VSDev.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CasasController : ControllerBase
    {
        private readonly ICasaService _casaService;
        private readonly IMapper _mapper;

        public CasasController(ICasaService casaService, IMapper mapper)
        {
            _casaService = casaService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IEnumerable<CasaViewModel>> ObterTodos()
        {
            return _mapper.Map<IEnumerable<CasaViewModel>>(await _casaService.GetAll());
        }

        [HttpGet("{id:guid}")]
        public async Task<ActionResult<CasaViewModel>> ObterPorId(Guid id)
        {
            var casa = await _casaService.GetById(id);

            if (casa == null) return NotFound();

            return _mapper.Map<CasaViewModel>(casa);
        }

        [HttpPut("{id:guid}")]
        public async Task<IActionResult> AtualizarRegistro(Guid id, CasaViewModel casa)
        {
            if (!CasaExists(id)) return NotFound();

            if (id != casa.Id) return BadRequest();

            try
            {
                await _casaService.Update(_mapper.Map<Casa>(casa));
            }
            catch (DbUpdateConcurrencyException)
            {
                throw;
            }

            return NoContent();
        }

        [HttpPost]
        public async Task<ActionResult<CasaViewModel>> CadastrarRegistro(CasaViewModel casa)
        {
            await _casaService.Add(_mapper.Map<Casa>(casa));

            return CreatedAtAction(nameof(CadastrarRegistro), new { id = casa.Id }, casa);
        }

        [HttpDelete("{id:guid}")]
        public async Task<ActionResult<CasaViewModel>> DeleteCasa(Guid id)
        {
            if (!CasaExists(id)) return NotFound();

            await _casaService.Delete(id);

            return NoContent();
        }


        private bool CasaExists(Guid id)
        {
            return _casaService.GetByIdAsNoTracking(id).Result != null;
        }
    }
}
