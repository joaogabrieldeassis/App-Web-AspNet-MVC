using Microsoft.EntityFrameworkCore;
using ProcessoSeletivo.Models;

namespace ProcessoSeletivo.Data
{
    public class TesteDbContent : DbContext
    {
        private readonly ILoggerFactory _logger = LoggerFactory.Create(x => x.AddConsole());
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Container> Containers { get; set; }
        public DbSet<Movimentacao> Movimentacaos { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options
                .UseLoggerFactory(_logger)
                .EnableSensitiveDataLogging()
                .UseSqlServer("Server=localhost,1433;Database=TesteBancoContent;User ID=sa;Password=1q2w3e4r@#$;Trusted_Connection=False; TrustServerCertificate=True;");
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfigurationsFromAssembly(typeof(TesteDbContent).Assembly);

        }
    }
}
