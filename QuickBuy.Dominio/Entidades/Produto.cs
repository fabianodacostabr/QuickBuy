
namespace QuickBuy.Dominio.Entidades
{
    public class Produto: Entidade
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public decimal Preco { get; set; }

        public override void Validate()
        {
            //throw new System.NotImplementedException();
            LimparMensagensValidacao();
            if (string.IsNullOrEmpty(Nome))
            {
                AdicionarCritica("Crítica: Nome não foi informado");
            }
            if (string.IsNullOrEmpty(Descricao))
            {
                AdicionarCritica("Crítica: Descricao não foi informada");
            }
            if (Preco <=0 )
            {
                AdicionarCritica("Crítica: Preço não foi informado");
            }

        }
    }
}
