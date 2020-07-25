using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using VSDev.Api.Extensions;
using VSDev.Business.Models;

namespace VSDev.Api.DTOs
{
    [ModelBinder(typeof(JsonWithFilesFormDataModelBinder), Name = "morador")]
    public class MoradorViewModel : MainEntityViewModel
    {
        [DisplayName("Casa")]
        [Required(ErrorMessage = "Informe a {0}")]
        public Guid? CasaId { get; set; }

        [DisplayName("Nome completo")]
        [Required(ErrorMessage = "Informe o {0}")]
        [StringLength(200, ErrorMessage = "O {0} deve ter no máximo {1} caracteres")]
        public string NomeCompleto { get; set; }

        [DisplayName("Receita Mensal")]
        public decimal? ReceitaMensal { get; set; }

        [DisplayName("Contribuição para a Casa")]
        public decimal? Contribuicao { get; set; }

        [DisplayName("Nome do arquivo da foto")]
        [Required(ErrorMessage = "Informe o {0}")]
        public string Foto { get; set; }

        [DisplayName("Foto em Imagem")]
        [Required(ErrorMessage = "Informe a {0}")]
        public IFormFile FotoImagem { get; set; }

        [DisplayName("Data de Nascimento")]
        [Required(ErrorMessage = "Informe a {0}")]
        public DateTime DataNascimento { get; set; }

        [DisplayName("Tipo de Morador")]
        [Required(ErrorMessage = "Informe o {0}")]
        public TipoMorador TipoMorador { get; set; }


        // RELACIONAMENTOS
        public CasaViewModel Casa{ get; set; }
        public IEnumerable<DespesaIndividualViewModel> DespesasIndividuais { get; set; }
    }
}
