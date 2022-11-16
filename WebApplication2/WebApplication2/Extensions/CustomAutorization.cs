using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.IdentityModel.JsonWebTokens;
using System.Security.Claims;

namespace WebApplication2.Extensions
{
    public class CustomAutorization
    {
        public static bool ValidarClaimsUsuarios(HttpContext content, string claimName, string claimValue)
        {
            return content.User.Identity.IsAuthenticated &&
            content.User.Claims.Any(x => x.Type == claimName && x.Value.Contains(claimValue));
        }
    }
    public class ClaimsAuthorizeAttribute : TypeFilterAttribute
    {
        public ClaimsAuthorizeAttribute(string claimName,string claimValue)
            :base(typeof(RequisitoClaimFilter))
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
            
            if (!CustomAutorization.ValidarClaimsUsuarios(context.HttpContext, _claim.Type, _claim.Value))
            {
                context.Result = new ForbidResult();
            }
        }
    }
}

/*public ClaimsAuthorizeAttribute(string claimName, string claimValue) : base(typeof(RequisitoClaimFilter));
{
    Arguments = new Object[] { new Claim(claimName, claimValue) }
       }
*/



