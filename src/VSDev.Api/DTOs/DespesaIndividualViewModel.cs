using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace VSDev.Api.DTOs
{
    public class DespesaIndividualViewModel : MainEntityViewModel
    {
        [DisplayName("Morador")]
        [Required(ErrorMessage = "Informe o {0}")]
        public Guid MoradorId { get; set; }

        [DisplayName("Descrição")]
        [Required(ErrorMessage = "Informe a {0}")]
        [StringLength(200, ErrorMessage = "A {0} deve ter no máximo {1} caracteres")]
        public string Descricao { get; set; }

        [Required(ErrorMessage = "Informe o {0}")]
        public decimal Valor { get; set; }

        [DisplayName("Data de Vencimento")]
        [Required(ErrorMessage = "Informe a {0}")]
        public DateTime DataVencimento { get; set; }

        [DisplayName("Data de Pagamento")]
        public DateTime? DataPagamento { get; set; }

        [DisplayName("Mês da Despesa")]
        [Required(ErrorMessage = "Informe o {0}")]
        public int Mes { get; set; }

        [DisplayName("Ano da Despesa")]
        [Required(ErrorMessage = "Informe o {0}")]
        public int Ano { get; set; }

        // RELACIONAMENTOS
        public MoradorViewModel Morador { get; set; }
    }
}
