using Microsoft.EntityFrameworkCore;
using QuickBuy.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace QuickBuy.Repositorio.Config
{

    public class ItemPedidoConfiguration : IEntityTypeConfiguration<ItemPedido>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<ItemPedido> builder)
        {
            builder.HasKey(i => i.Id);

            //builder utiliza o padrao Fluent          

            builder
                .Property(i => i.ProdutoId)
                .IsRequired();

            builder
               .Property(i => i.Quantidade)
               .IsRequired();

        }
    }

}
