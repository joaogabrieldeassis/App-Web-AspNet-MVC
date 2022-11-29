using Microsoft.EntityFrameworkCore;
using MinhaAp.Busines.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinhaAp.Data.Context
{
    public class MeuDbContext : DbContext
    {
      
        public MeuDbContext(DbContextOptions options): base (options)
        {

        }
        public DbSet<Produto> Products { get; set; }
        public DbSet<Fornecedor> Fornecedores { get; set; }
        public DbSet<Endereco> Enderecos  { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(MeuDbContext).Assembly);
                                  
            base.OnModelCreating(modelBuilder);
        }
    }
}
