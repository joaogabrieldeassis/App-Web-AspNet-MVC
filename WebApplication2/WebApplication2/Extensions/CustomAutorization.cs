using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Security.Claims;

namespace WebApplication2.Extensions
{
    public class CustomAutorization
    {
        public static bool ValidarClaimsUsuarios(HttpContext content, string claimName, string claimValue)
        {
            return content.User.Identity.IsAuthenticated && content.User.Claims.Any(x => x.Type == claimName && x.Value.Contains(claimValue));
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
                if (!ValidarClaimsUsuarios(context.HttpContext, _claim.Type, _claim.Value))
                {
                    context.Result = new ForbidResult();
                }
            }
        }
    }
}
