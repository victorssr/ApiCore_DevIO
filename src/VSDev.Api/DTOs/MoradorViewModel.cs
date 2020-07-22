using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace VSDev.Api.DTOs
{
    public class MoradorViewModel : MainEntityViewModel
    {
        [DisplayName("Casa")]
        [Required(ErrorMessage = "Informe a {0}")]
        public Guid CasaId { get; set; }

        [DisplayName("Nome completo")]
        [Required(ErrorMessage = "Informe o {0}")]
        [StringLength(200, ErrorMessage = "O {0} deve ter no máximo {1} caracteres")]
        public string NomeCompleto { get; set; }

        [DisplayName("Receita Mensal")]
        public decimal? ReceitaMensal { get; set; }

        [DisplayName("Contribuição para a Casa")]
        public decimal? Contribuicao { get; set; }

        // RELACIONAMENTOS
        public CasaViewModel Casa{ get; set; }
        public IEnumerable<DespesaIndividualViewModel> DespesasIndividuais { get; set; }
    }
}
