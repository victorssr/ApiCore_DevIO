using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace VSDev.Api.DTOs
{
    public class LoginViewModel
    {
        [DisplayName("E-mail")]
        [Required(ErrorMessage = "Informe o {0}")]
        [EmailAddress(ErrorMessage = "Informe um {0} válido")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Informe o {0}")]
        public string Password { get; set; }
    }
}
