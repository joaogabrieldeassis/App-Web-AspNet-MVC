using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Dev.AppMvc.ViewModels;

namespace MyAppMvc.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }                       
        public DbSet<Dev.AppMvc.ViewModels.EnderecoViewModel> EnderecoViewModel { get; set; }
    }
}