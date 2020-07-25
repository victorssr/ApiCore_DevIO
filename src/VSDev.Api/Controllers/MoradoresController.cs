using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using VSDev.Api.DTOs;
using VSDev.Business.Interfaces;
using VSDev.Business.Interfaces.Services;
using VSDev.Business.Models;

namespace VSDev.Api.Controllers
{
    [Route("api/[controller]")]
    public class MoradoresController : MainController
    {
        private readonly IMoradorService _moradorService;
        private readonly IMapper _mapper;

        public MoradoresController(INotificator notificator, IMoradorService moradorService, IMapper mapper) : base(notificator)
        {
            _moradorService = moradorService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IEnumerable<MoradorViewModel>> ObterTodos()
        {
            return _mapper.Map<IEnumerable<MoradorViewModel>>(await _moradorService.GetAll());
        }

        [HttpGet("{id:guid}")]
        public async Task<ActionResult<MoradorViewModel>> ObterMorador(Guid id)
        {
            var morador = await _moradorService.GetById(id);

            if (morador == null) return NotFound();

            return _mapper.Map<MoradorViewModel>(morador);
        }

        [HttpPut("{id:guid}")]
        public async Task<IActionResult> Atualizar(Guid id, MoradorViewModel morador)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);

            if (!MoradorExists(id)) return NotFound();

            if (id != morador.Id)
            {
                NotificarErro("Id informado está diferente do Id informado na query");
                return CustomResponse();
            }

            await _moradorService.Update(_mapper.Map<Morador>(morador));

            return CustomResponse();
        }

        [HttpPost]
        public async Task<ActionResult<MoradorViewModel>> Cadastrar(MoradorViewModel morador)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);

            string prefixImageName = Guid.NewGuid() + "_";
            if (!await UploadFoto(morador.FotoImagem, prefixImageName)) return CustomResponse();

            morador.Foto = prefixImageName + morador.FotoImagem.FileName;
            await _moradorService.Add(_mapper.Map<Morador>(morador));

            return CustomResponse(morador);
        }

        [HttpDelete("{id:guid}")]
        public async Task<ActionResult<MoradorViewModel>> Excluir(Guid id)
        {
            if (!MoradorExists(id)) return NotFound();

            await _moradorService.Delete(id);

            return CustomResponse();
        }


        private async Task<bool> UploadFoto(IFormFile formFile, string prefixImageName)
        {
            if (formFile == null || formFile.Length == 0)
            {
                NotificarErro("Informe o arquivo da foto.");
                return false;
            }

            var imageName = prefixImageName + formFile.FileName;
            var pathFile = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/imagens", imageName);
            if (System.IO.File.Exists(pathFile))
            {
                NotificarErro("Já existe uma foto com este nome.");
                return false;
            }

            using (var stream = new FileStream(pathFile, FileMode.Create))
            {
                await formFile.CopyToAsync(stream);
            }

            return true;
        }

        private bool MoradorExists(Guid id)
        {
            return _moradorService.GetByIdAsNoTracking(id).Result != null;
        }
    }
}
