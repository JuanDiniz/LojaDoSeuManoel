namespace LojaDoSeuManoel.Models
{
    public class SaidaPedidos
    {
        public List<PedidoResposta> pedidos { get; set; }
    }

    public class PedidoResposta
    {
        public int pedido_id { get; set; }
        public List<CaixaResposta> caixas { get; set; }
    }

    public class CaixaResposta
    {
        public string caixa_id { get; set; }
        public List<string> produtos { get; set; }
        public string observacao { get; set; }
    }
}
