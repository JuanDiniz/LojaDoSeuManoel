namespace LojaDoSeuManoel.Models
{
public class Caixa
{
    public string CaixaId { get; set; }
    public Dimensoes Dimensoes { get; set; }
    public List<string> Produtos { get; set; } = new List<string>();
    public string Observacao { get; set; }
}
};