using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace VSDev.Api.DTOs
{
    public class RegisterViewModel
    {
        [DisplayName("E-mail")]
        [Required(ErrorMessage = "Informe o {0}")]
        [EmailAddress(ErrorMessage = "Informe um {0} válido")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Informe o {0}")]
        public string Password { get; set; }

        [DisplayName("Confirmação da senha")]
        [Required(ErrorMessage = "Informe a {0}")]
        [Compare(nameof(Password), ErrorMessage = "Senha e a confirmação de senha não estão iguais")]
        public string ConfirmPassword { get; set; }
    }
}
