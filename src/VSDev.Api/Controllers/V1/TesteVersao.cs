using Microsoft.AspNetCore.Mvc;
using VSDev.Business.Interfaces;

namespace VSDev.Api.Controllers.V1
{
    [ApiVersion("1.0", Deprecated = true)]    
    [Route("api/v{version:apiVersion}/[controller]")]
    public class TesteVersao : MainController
    {
        public TesteVersao(INotificator notificator, IUser user) : base(notificator, user)
        {
        }


        [HttpGet]        
        public string Value()
        {
            return "This is version 1.0";
        }
    }
}
