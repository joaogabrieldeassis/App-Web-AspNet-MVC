using Microsoft.AspNetCore.Mvc.Filters;

namespace WebApplication2.Extensions
{
    public class CustomAutorization
    {
        public static bool ValidarClaimsUsuarios(HttpContext content,string claimName,string claimValue)
        {
            return content.User.Identity.IsAuthenticated && content.User.Claims.Any(x=>x.Type == claimName && x.Value.Contains(claimValue));      
        }
    }
    public class RequisitoClaimFilter : IAuthorizationFilter
    {
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            throw new NotImplementedException();
        }
    }
}
