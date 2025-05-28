namespace LojaDoSeuManoel.Models
{
    public class EmbalagemResposta
    {
        public int PedidoId { get; set; }
        public List<Caixa> Caixas { get; set; }
    }
}
