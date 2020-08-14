using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using VSDev.Business.Interfaces;

namespace VSDev.Api.Controllers.V2
{
    [ApiVersion("2.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class TesteVersao : MainController
    {
        private readonly ILogger _logger;

        public TesteVersao(INotificator notificator, IUser user, ILogger<TesteVersao> logger) : base(notificator, user)
        {
            _logger = logger;
        }

        [HttpGet]
        public string Value()
        {
            return "This is version 2.0";
        }
    }
}
