using System;

public class Dimensoes
{
    public int Altura { get; set; }
    public int Largura { get; set; }
    public int Comprimento { get; set; }

    public int Volume => Altura * Largura * Comprimento;
}

// Produto.cs
public class Produto
{
    public string ProdutoId { get; set; }
    public Dimensoes Dimensoes { get; set; }
}

// Pedido.cs
public class Pedido
{
    public int PedidoId { get; set; }
    public List<Produto> Produtos { get; set; }
}

// Caixa.cs
public class Caixa
{
    public string CaixaId { get; set; }
    public Dimensoes Dimensoes { get; set; }
    public List<string> Produtos { get; set; } = new List<string>();
    public string Observacao { get; set; }
}

// EmbalagemResposta.cs
public class EmbalagemResposta
{
    public int PedidoId { get; set; }
    public List<Caixa> Caixas { get; set; }
}