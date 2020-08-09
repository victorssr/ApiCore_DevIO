using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Linq;
using VSDev.Business.Interfaces;
using VSDev.Business.Notifications;

namespace VSDev.Api.Controllers
{
    [ApiController]
    public class MainController : ControllerBase
    {
        private readonly INotificator _notificator;
        protected readonly IUser _user;

        protected MainController(INotificator notificator, IUser user)
        {
            _notificator = notificator;
            _user = user;

            UsuarioId = user.GetUserId();
            UsuarioAutenticado = user.IsAuthenticated();
        }

        protected Guid UsuarioId { get; set; }
        protected bool UsuarioAutenticado { get; set; }

        protected bool OperacaoValida()
        {
            return !_notificator.HasNotification();
        }

        protected ActionResult CustomResponse(object result = null)
        {
            if (!OperacaoValida())
            {
                return BadRequest(new
                {
                    success = false,
                    errors = _notificator.GetNotifications().Select(n => n.Mensagem)
                });
            }

            return Ok(new
            {
                success = true,
                data = result
            });
        }

        protected ActionResult CustomResponse(ModelStateDictionary modelState)
        {
            if (!modelState.IsValid) NotificarErroModelInvalida(modelState);

            return CustomResponse();
        }

        protected void NotificarErroModelInvalida(ModelStateDictionary modelState)
        {
            var erros = modelState.Values.SelectMany(m => m.Errors);
            foreach (var erro in erros)
            {
                NotificarErro(erro.Exception == null ? erro.ErrorMessage : erro.Exception.Message);
            }
        }

        protected void NotificarErro(string mensagem)
        {
            _notificator.Handle(new Notification(mensagem));
        }

    }
}
