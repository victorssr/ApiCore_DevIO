using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace VSDev.Api.DTOs
{
    public class CasaViewModel : MainEntityViewModel
    {
        [DisplayName("Valor para Despesas")]
        [Required(ErrorMessage = "Informe o {0}")]
        public decimal ValorDespesas { get; set; }

        // RELACIONAMENTOS
        public IEnumerable<MoradorViewModel> Moradores { get; set; }
        public EnderecoViewModel Endereco { get; set; }
    }
}
