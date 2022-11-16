using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Razor;

namespace WebApplication2.Extensions
{
    public static class RazorExtensions
    {
        public static bool IfClaim(this RazorPage page,string claimName,string claimValue)
        {
            return CustomAutorization.ValidarClaimsUsuarios(page.Context, claimName, claimValue);
        }
        public static string IfClaimShow(this RazorPage page, string claimName, string claimValue)
        {
            return CustomAutorization.ValidarClaimsUsuarios(page.Context, claimName, claimValue) ? "" : "disable";
        }
        public static IHtmlContent IfClaimShow(this IHtmlContent page, HttpContext context, string claimName, string claimValue)
        {
            return CustomAutorization.ValidarClaimsUsuarios(context, claimName, claimValue) ? page : null;
        }
    }
}
