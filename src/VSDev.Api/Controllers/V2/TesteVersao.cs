using Microsoft.AspNetCore.Mvc;
using VSDev.Business.Interfaces;

namespace VSDev.Api.Controllers.V2
{
    [ApiVersion("2.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class TesteVersao : MainController
    {
        public TesteVersao(INotificator notificator, IUser user) : base(notificator, user)
        {
        }


        [HttpGet]
        public string Value()
        {
            return "This is version 2.0";
        }
    }
}
