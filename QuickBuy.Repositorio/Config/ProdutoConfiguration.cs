using Microsoft.EntityFrameworkCore;
using QuickBuy.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace QuickBuy.Repositorio.Config
{
  
    public class ProdutoConfiguration : IEntityTypeConfiguration<Produto>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Produto> builder)
        {
            builder.HasKey(p => p.Id);

            //builder utiliza o padrao Fluent          

            builder
                .Property(p => p.Nome)
                .IsRequired()
                .HasMaxLength(100);

            builder
                .Property(p => p.Descricao)
                .IsRequired()
                .HasMaxLength(500);

            builder
                .Property(p => p.Preco)
                .IsRequired();
                
        }
    }
}
