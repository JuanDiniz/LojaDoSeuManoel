using System.Collections.Generic;
using System.Linq;
using LojaDoSeuManoel.Models;

namespace LojaDoSeuManoel.Services
{
    public class EmbalagemService
    {
        private readonly List<Caixa> caixasDisponiveis = new List<Caixa>
        {
            new Caixa { CaixaId = "Caixa 1", Dimensoes = new Dimensoes { Altura = 30, Largura = 40, Comprimento = 80 } },
            new Caixa { CaixaId = "Caixa 2", Dimensoes = new Dimensoes { Altura = 80, Largura = 50, Comprimento = 40 } },
            new Caixa { CaixaId = "Caixa 3", Dimensoes = new Dimensoes { Altura = 50, Largura = 80, Comprimento = 60 } },
        };

        public List<PedidoResposta> CalcularEmbalagem(List<Pedido> pedidos)
        {
            var respostas = new List<PedidoResposta>();

            foreach (var pedido in pedidos)
            {
                var caixasUsadas = new List<CaixaResposta>();

                var produtosNaoAlocados = pedido.Produtos
                    .OrderByDescending(p => p.Dimensoes.Volume)
                    .ToList();

                var caixasDisponiveis = new List<Caixa>
        {
            new Caixa { CaixaId = "Caixa 1", Dimensoes = new Dimensoes { Altura = 30, Largura = 40, Comprimento = 80 } },
            new Caixa { CaixaId = "Caixa 2", Dimensoes = new Dimensoes { Altura = 80, Largura = 50, Comprimento = 40 } },
            new Caixa { CaixaId = "Caixa 3", Dimensoes = new Dimensoes { Altura = 50, Largura = 80, Comprimento = 60 } },
        };

                var caixasUsadasInternas = new List<Caixa>();

                foreach (var produto in produtosNaoAlocados)
                {
                    bool alocado = false;

                    foreach (var caixa in caixasUsadasInternas)
                    {
                        if (ProdutoCabeNaCaixa(produto, caixa))
                        {
                            caixa.Produtos.Add(produto.ProdutoId);
                            alocado = true;
                            break;
                        }
                    }

                    if (!alocado)
                    {
                        foreach (var caixaDisponivel in caixasDisponiveis.OrderBy(c => c.Dimensoes.Volume))
                        {
                            if (ProdutoCabeNaCaixa(produto, caixaDisponivel))
                            {
                                var novaCaixa = new Caixa
                                {
                                    CaixaId = caixaDisponivel.CaixaId,
                                    Dimensoes = caixaDisponivel.Dimensoes,
                                    Produtos = new List<string> { produto.ProdutoId }
                                };
                                caixasUsadasInternas.Add(novaCaixa);
                                alocado = true;
                                break;
                            }
                        }
                    }

                    if (!alocado)
                    {
                        caixasUsadas.Add(new CaixaResposta
                        {
                            caixa_id = null,
                            produtos = new List<string> { produto.ProdutoId },
                            observacao = "Produto não cabe em nenhuma caixa disponível."
                        });
                    }
                }

                foreach (var caixa in caixasUsadasInternas)
                {
                    caixasUsadas.Add(new CaixaResposta
                    {
                        caixa_id = caixa.CaixaId,
                        produtos = caixa.Produtos
                    });
                }

                respostas.Add(new PedidoResposta
                {
                    pedido_id = pedido.PedidoId,
                    caixas = caixasUsadas
                });
            }

            return respostas;
        }

        private bool ProdutoCabeNaCaixa(Produto produto, Caixa caixa)
        {
            return produto.Dimensoes.Altura <= caixa.Dimensoes.Altura &&
                   produto.Dimensoes.Largura <= caixa.Dimensoes.Largura &&
                   produto.Dimensoes.Comprimento <= caixa.Dimensoes.Comprimento;
        }
    }
}