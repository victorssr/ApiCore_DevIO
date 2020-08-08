using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Linq;
using System.Security.Claims;

namespace VSDev.Api.Extensions
{
    public class CustomAuthorize
    {
        public static bool ValidaClaimUsuario(HttpContext httpContext, string claimName, string claimValue)
        {
            return httpContext.User.Identity.IsAuthenticated &&
                    httpContext.User.Claims.Any(u => u.Type == claimName && u.Value.Contains(claimValue));
        }
    }

    public class ClaimnsAuthorizeAttribute : TypeFilterAttribute
    {
        public ClaimnsAuthorizeAttribute(string claimName, string claimValue) : base(typeof(RequisitoClaimFilter))
        {
            Arguments = new object[] { new Claim(claimName, claimValue) };
        }
    }

    public class RequisitoClaimFilter : IAuthorizationFilter
    {
        private readonly Claim _claim;

        public RequisitoClaimFilter(Claim claim)
        {
            _claim = claim;
        }

        public void OnAuthorization(AuthorizationFilterContext context)
        {
            if (!context.HttpContext.User.Identity.IsAuthenticated)
            {
                context.Result = new StatusCodeResult(401);
                return;
            }

            if(!CustomAuthorize.ValidaClaimUsuario(context.HttpContext, _claim.Type, _claim.Value))
            {
                context.Result = new StatusCodeResult(403);
            }
        }
    }

}
