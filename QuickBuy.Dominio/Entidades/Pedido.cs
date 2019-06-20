using System;
using System.Collections.Generic;
using System.Linq;
using QuickBuy.Dominio.ObjetoValor;

namespace QuickBuy.Dominio.Entidades
{
    public class Pedido : Entidade
    {
        public int Id { get; set; }
        public DateTime DataPedido { get; set; }
        public int UsuarioId { get; set; }
        public virtual Usuario Usuario { get; set; }
        public DateTime DataPrevisaoEntrega { get; set; }
        public string CEP { get; set; }
        public string Estado { get; set; }
        public string Cidade { get; set; }
        public string EnderecoCompleto { get; set; }
        public string NumeroEndereco { get; set; }

        public int FormaPagamentoId { get; set; }
        public virtual FormaPagamento FormaPagamento { get; set; }

        public virtual ICollection<ItemPedido> ItensPedido { get; set; }

        public override void Validate()
        {
            LimparMensagensValidacao();

            if (!ItensPedido.Any())
            {
                AdicionarCritica("Crítica: Pedido não pode ser sem Item de Pedido");
            }
            if (string.IsNullOrEmpty(CEP))
            {
                AdicionarCritica("Crítica: CEP não foi informado");
            }
            if (FormaPagamentoId <= 0)
            {
                AdicionarCritica("Crítica: Forma de pagamento não informada");
            }


        }
    }
}