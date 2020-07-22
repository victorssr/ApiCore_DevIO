using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace VSDev.Api.DTOs
{
    public class EnderecoViewModel : MainEntityViewModel
    {
        [DisplayName("Casa")]
        [Required(ErrorMessage = "Informe a {0}")]
        public Guid CasaId { get; set; }

        [DisplayName("Logradouro")]
        [Required(ErrorMessage = "Informe o {0}")]
        [StringLength(200, ErrorMessage = "O {0} deve ter no máximo {1} caracteres")]
        public string Logradouro { get; set; }

        [DisplayName("Número")]
        [Required(ErrorMessage = "Informe o {0}")]
        public int Numero { get; set; }

        [DisplayName("Complemento")]
        [StringLength(10, ErrorMessage = "O {0} deve ter no máximo {1} caracteres")]
        public string Complemento { get; set; }

        [DisplayName("Bairro")]
        [Required(ErrorMessage = "Informe o {0}")]
        [StringLength(200, ErrorMessage = "O {0} deve ter no máximo {1} caracteres")]
        public string Bairro { get; set; }

        [DisplayName("Cidade")]
        [Required(ErrorMessage = "Informe a {0}")]
        [StringLength(200, ErrorMessage = "A {0} deve ter no máximo {1} caracteres")]
        public string Cidade { get; set; }

        [DisplayName("Estado")]
        [Required(ErrorMessage = "Informe o {0}")]
        [StringLength(2, ErrorMessage = "O {0} deve ter no máximo {1} caracteres")]
        public string Estado { get; set; }

        [DisplayName("CEP")]
        [Required(ErrorMessage = "Informe o {0}")]
        [StringLength(10, ErrorMessage = "O {0} deve ter no máximo {1} caracteres")]
        public string Cep { get; set; }
    }
}
