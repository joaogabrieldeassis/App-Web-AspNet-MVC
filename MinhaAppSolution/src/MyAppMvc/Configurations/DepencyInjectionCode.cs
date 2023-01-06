using Dev.Bussines.Interfaces;
using Dev.Data.Repository;
using MyAppMvc.Data;

namespace Dev.AppMvc.Configurations
{
    public static class DepencyInjectionCode 
    {
        public static IServiceCollection ResolveDepencies(this IServiceCollection services)
        {
            services.AddScoped<ApplicationDbContext>();
            services.AddScoped<IProdutoRepository, ProdutoRepository>();
            services.AddScoped<IFornecedorRepository, FornecedorRepository>();
            services.AddScoped<IEnderecoRepository, EnderecoRepository>();
            return services;
        }
    }
}
