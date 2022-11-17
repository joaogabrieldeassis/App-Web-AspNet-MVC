using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace WebApplication2.Config
{
    public static class IdentityConfig
    {
        public static IServiceCollection ResolveDependencies(IServiceCollection services)
        {
            services.AddAuthorization(options =>
            {
                options.AddPolicy("PodeExcluir", policy => policy.RequireClaim("PodeExcluir"));
            });
            return services;
        }
    }
}
