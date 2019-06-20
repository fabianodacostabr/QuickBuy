using Microsoft.EntityFrameworkCore;
using QuickBuy.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace QuickBuy.Repositorio.Config
{
    public class UsuarioConfiguration : IEntityTypeConfiguration<Usuario>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Usuario> builder)
        {
            builder.HasKey(u => u.Id);

            //builder utiliza o padrao Fluent
            builder
                .Property(u => u.Email)
                .IsRequired()
                .HasMaxLength(100);

            builder
                .Property(u => u.Nome)
                .IsRequired()
                .HasMaxLength(100);

            builder
               .Property(u => u.SobreNome)
               .IsRequired()
               .HasMaxLength(100);

            builder
                .Property(u => u.Email)
                .IsRequired()
                .HasMaxLength(100);

            builder
               .Property(u => u.Senha)
               .IsRequired()
               .HasMaxLength(200);


            builder
                .HasMany(u => u.Pedidos)
                .WithOne(p=>p.Usuario);

        }
    }
}
