using JhonStore.Models;
using Microsoft.EntityFrameworkCore;

namespace JhonStore.Controllers.Data
{
    public class MyDbContext : DbContext
    {
        private readonly ILoggerFactory _logger = LoggerFactory.Create(x => x.AddConsole());

        public DbSet<Aluno> Alunos{ get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            
        options.UseLoggerFactory(_logger)
                .EnableSensitiveDataLogging()
                .UseSqlServer("Server=localhost,1433;Database=JhonStore;User ID=sa;Password=@#$;Trusted_Connection=False; TrustServerCertificate=True;");
        }
    }
}
