using System;

// EmbalagemService.cs
public class EmbalagemService
{
    private List<Caixa> caixasDisponiveis = new List<Caixa>
    {
        new Caixa { CaixaId = "Caixa 1", Dimensoes = new Dimensoes { Altura = 30, Largura = 40, Comprimento = 80 } },
        new Caixa { CaixaId = "Caixa 2", Dimensoes = new Dimensoes { Altura = 80, Largura = 50, Comprimento = 40 } },
        new Caixa { CaixaId = "Caixa 3", Dimensoes = new Dimensoes { Altura = 50, Largura = 80, Comprimento = 60 } },
    };

    public List<EmbalagemResposta> CalcularEmbalagem(List<Pedido> pedidos)
    {
        var respostas = new List<EmbalagemResposta>();

        foreach (var pedido in pedidos)
        {
            var resposta = new EmbalagemResposta
            {
                PedidoId = pedido.PedidoId,
                Caixas = new List<Caixa>()
            };

            var produtosNaoAlocados = new List<Produto>(pedido.Produtos);
            produtosNaoAlocados.Sort((a, b) => b.Dimensoes.Volume.CompareTo(a.Dimensoes.Volume));

            foreach (var caixaDisponivel in caixasDisponiveis)
            {
                var caixaAtual = new Caixa
                {
                    CaixaId = caixaDisponivel.CaixaId,
                    Dimensoes = caixaDisponivel.Dimensoes,
                    Produtos = new List<string>()
                };

                foreach (var produto in produtosNaoAlocados.ToList())
                {
                    if (CabeNaCaixa(produto, caixaDisponivel))
                    {
                        caixaAtual.Produtos.Add(produto.ProdutoId);
                        produtosNaoAlocados.Remove(produto);
                    }
                }

                if (caixaAtual.Produtos.Any())
                    resposta.Caixas.Add(caixaAtual);
            }

            if (produtosNaoAlocados.Any())
            {
                foreach (var produto in produtosNaoAlocados)
                {
                    resposta.Caixas.Add(new Caixa
                    {
                        CaixaId = null,
                        Produtos = new List<string> { produto.ProdutoId },
                        Observacao = "Produto não cabe em nenhuma caixa disponível."
                    });
                }
            }

            respostas.Add(resposta);
        }

        return respostas;
    }

    private bool CabeNaCaixa(Produto produto, Caixa caixa)
    {
        return produto.Dimensoes.Altura <= caixa.Dimensoes.Altura &&
               produto.Dimensoes.Largura <= caixa.Dimensoes.Largura &&
               produto.Dimensoes.Comprimento <= caixa.Dimensoes.Comprimento;
    }
}