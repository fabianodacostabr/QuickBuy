using System;
using System.Collections.Generic;
using System.Text;

namespace QuickBuy.Dominio.Entidades
{
    public class ItemPedido: Entidade
    {
        public int Id { get; set; }
        public int ProdutoId { get; set; }
        public int Quantidade { get; set; }

        public override void Validate()
        {
            //throw new System.NotImplementedException();
            LimparMensagensValidacao();
            if (ProdutoId <= 0)
            {                
                AdicionarCritica("Crítica: Não foi identificado qual a referência do Produto");
            }
            if (Quantidade <= 0)
            {
                AdicionarCritica("Crítica: Não foi informada a quantidade do Produto");
            }
        }
    }
}
