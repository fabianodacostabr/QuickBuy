using Microsoft.EntityFrameworkCore;
using QuickBuy.Dominio.Entidades;
using QuickBuy.Dominio.ObjetoValor;
using System;
using System.Collections.Generic;
using System.Text;

namespace QuickBuy.Repositorio.Config
{   
    public class FormaPagamentoConfiguration : IEntityTypeConfiguration<FormaPagamento>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<FormaPagamento> builder)
        {
            builder.HasKey(f => f.Id);

            //builder utiliza o padrao Fluent          

            builder
                .Property(f => f.Nome)
                .HasMaxLength(100)
                .IsRequired();

            builder
               .Property(f => f.Descricao)
               .HasMaxLength(100)
               .IsRequired();

        }
    }
}
