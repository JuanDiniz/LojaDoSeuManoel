using System.Text.Json.Serialization;

namespace LojaDoSeuManoel.Models
{
    public class Caixa
    {
        [JsonPropertyName("caixa_id")]
        public string CaixaId { get; set; }
        public Dimensoes Dimensoes { get; set; }
        public List<string> Produtos { get; set; } = new List<string>();

        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string Observacao { get; set; }
        public int VolumeOcupado { get; set; } = 0;
    }
};