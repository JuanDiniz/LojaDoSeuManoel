using LojaDoSeuManoel.Models;
using LojaDoSeuManoel.Services;
using System.Collections.Generic;
using Xunit;

namespace LojaDoSeuManoel.Tests
{
    public class EmbalagemServiceTests
    {
        [Fact]
        public void TestaProdutoCabeEmCaixa()
        {
            var service = new EmbalagemService();
            var pedidos = new List<Pedido>
            {
                new Pedido
                {
                    PedidoId = 1,
                    Produtos = new List<Produto>
                    {
                        new Produto { ProdutoId = "A", Dimensoes = new Dimensoes { Altura = 10, Largura = 10, Comprimento = 10 } }
                    }
                }
            };

            var resultado = service.CalcularEmbalagem(pedidos);
            Assert.Single(resultado);
            Assert.Single(resultado[0].caixas);
            Assert.Contains("A", resultado[0].caixas[0].produtos);
            Assert.Null(resultado[0].caixas[0].observacao);  // Observação só aparece se não couber
        }

        [Fact]
        public void TestaProdutoNaoCabeEmCaixa()
        {
            var service = new EmbalagemService();
            var pedidos = new List<Pedido>
            {
                new Pedido
                {
                    PedidoId = 2,
                    Produtos = new List<Produto>
                    {
                        new Produto { ProdutoId = "B", Dimensoes = new Dimensoes { Altura = 500, Largura = 500, Comprimento = 500 } }
                    }
                }
            };

            var resultado = service.CalcularEmbalagem(pedidos);
            Assert.Single(resultado);
            Assert.Single(resultado[0].caixas);
            Assert.Contains("B", resultado[0].caixas[0].produtos);  // Produto aparece, mas com observação
            Assert.Equal("Produto não cabe em nenhuma caixa disponível.", resultado[0].caixas[0].observacao);
        }
    }
}