
using Microsoft.EntityFrameworkCore;
using Teste.Models;

namespace Teste.Data
{
    public class BancoDaAplicacao  : DbContext
    {
        public DbSet<Cliente> Clientes{ get; set; }
        public DbSet<Container> Containers { get; set; }
        public DbSet<Movimentacao> Movimentacaos{ get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder options)
        => options.UseSqlServer("Server=localhost,1433;Database=DensenvolvedorIo;User ID=sa;Password=1q2w3e4r@#$;Trusted_Connection=False; TrustServerCertificate=True;");
        

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfigurationsFromAssembly(typeof(BancoDaAplicacao).Assembly);
        }
    }
}
