using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using MinhaAp.Busines.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinhaAp.Data.Mapping
{
    public class FornecedorMapping : IEntityTypeConfiguration<Fornecedor>
    {
        public void Configure(EntityTypeBuilder<Fornecedor> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Nome)
                .IsRequired()
                .HasColumnType("varchar(150)");

            builder.Property(x => x.Documento)
                .IsRequired()
                .HasColumnType("varchar(14)");

            //Um Fornecedor tem um Endereço e um Endereço tem um Fornecedor
            builder.HasOne(x => x.Endereco)
                .WithOne(x => x.Fornecedor);

            //Um Fornecedor tem muitos produtos e um Produto tem um Fornecedor
            builder.HasMany(x => x.Produtos)
                .WithOne(x => x.Fornecedor)
                .HasForeignKey(x => x.FornecedorId);

            builder.ToTable("Fornecedores");
        }
    }
}
