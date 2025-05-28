namespace LojaDoSeuManoel.Models;
using System.Text.Json.Serialization;

public class Produto
{
    [JsonPropertyName("produto_id")]
    public string ProdutoId { get; set; }

    public Dimensoes Dimensoes { get; set; }
}