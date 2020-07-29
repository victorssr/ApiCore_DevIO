using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using VSDev.Api.DTOs;
using VSDev.Business.Interfaces;

namespace VSDev.Api.Controllers
{
    [Route("api/")]
    public class AuthController : MainController
    {
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly UserManager<IdentityUser> _userManager;

        public AuthController(INotificator notificator, SignInManager<IdentityUser> signInManager, UserManager<IdentityUser> userManager) : base(notificator)
        {
            _signInManager = signInManager;
            _userManager = userManager;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Registrar(RegisterViewModel registerViewModel)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);

            var user = new IdentityUser
            {
                UserName = registerViewModel.Email,
                Email = registerViewModel.Email,
                EmailConfirmed = true
            };

            var result = await _userManager.CreateAsync(user, registerViewModel.Password);
            if (result.Succeeded)
            {
                await _signInManager.SignInAsync(user, false);
                return CustomResponse(registerViewModel);
            }
            foreach (var erro in result.Errors)
            {
                NotificarErro(erro.Description);
            }

            return CustomResponse();
        }

        [HttpPost("login")]
        public async Task<IActionResult> Acessar(LoginViewModel loginViewModel)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);

            var result = await _signInManager.PasswordSignInAsync(loginViewModel.Email, loginViewModel.Password, false, true);
            if (result.Succeeded)
            {
                return CustomResponse(loginViewModel);
            }
            if (result.IsLockedOut)
            {
                NotificarErro("Usuário bloqueado por várias tentativas de login.");
                return CustomResponse();
            }

            NotificarErro("Usuário não encontrado. E-mail e/ou senha incorretos.");
            return CustomResponse();
        }

    }
}
