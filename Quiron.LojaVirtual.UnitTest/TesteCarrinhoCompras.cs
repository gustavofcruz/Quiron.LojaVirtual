using Microsoft.VisualStudio.TestTools.UnitTesting;
using Quiron.LojaVirtual.Dominio.Entidade;
using Quiron.LojaVirtual.Web.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Quiron.LojaVirtual.UnitTest
{
    [TestClass]
    public class TesteCarrinhoCompras
    {
        //Teste de adiocnar itens do carrinho
        [TestMethod]
        public void AdicionarItensCarrinho() 
        {
            //Arrange - criação dos produtos
            Produto produto1 = new Produto
            {
                ProdutoId = 1,
                Nome = "Teste 1"
            };

            Produto produto2 = new Produto
            {
                ProdutoId = 2,
                Nome = "Teste 2"
            };

            Produto produto3 = new Produto
            {
                ProdutoId = 3,
                Nome = "Teste 3"
            };

            //Arrange
            Carrinho carrinho = new Carrinho();
            carrinho.AdicionarItem(produto1, 2);
            carrinho.AdicionarItem(produto2, 3);
            carrinho.AdicionarItem(produto3, 1);

            //Action
            ItemCarrinho[] itens = carrinho.ItensCarrinho.ToArray();

            //Assert
            Assert.AreEqual(itens.Length, 3); // quantidade de itens do carrinho é igual 2
            Assert.AreEqual(itens[0].Produto, produto1);
            Assert.AreEqual(itens[1].Produto, produto2);
            Assert.AreEqual(itens[2].Produto, produto3);

        }

        [TestMethod]
        public void AdicionarProdutoExistenteParaCarrinho() 
        {
            //Arrange - criação dos produtos
            Produto produto1 = new Produto
            {
                ProdutoId = 1,
                Nome = "Teste 1"
            };

            Produto produto2 = new Produto
            {
                ProdutoId = 2,
                Nome = "Teste 2"
            };

            //Produto produto3 = new Produto
            //{
            //    ProdutoId = 3,
            //    Nome = "Teste 3"
            //};

            //Arrange
            Carrinho carrinho = new Carrinho();
            carrinho.AdicionarItem(produto1, 1);
            carrinho.AdicionarItem(produto2, 1);
            carrinho.AdicionarItem(produto1, 10);

            //Action
            ItemCarrinho[] resultado = carrinho.ItensCarrinho.OrderBy(c => c.Produto.ProdutoId).ToArray();

            //Assert
            Assert.AreEqual(resultado.Length, 2);
            Assert.AreEqual(resultado[0].Quantidade, 11);

        }

        [TestMethod]
        public void RemoverItensCarrinho()
        {
            //Arrange - criação dos produtos
            Produto produto1 = new Produto
            {
                ProdutoId = 1,
                Nome = "Teste 1"
            };

            Produto produto2 = new Produto
            {
                ProdutoId = 2,
                Nome = "Teste 2"
            };

            Produto produto3 = new Produto
            {
                ProdutoId = 3,
                Nome = "Teste 3"
            };

            //Arrange
            Carrinho carrinho = new Carrinho();
            carrinho.AdicionarItem(produto1, 1);
            carrinho.AdicionarItem(produto2, 3);
            carrinho.AdicionarItem(produto3, 5);
            carrinho.AdicionarItem(produto2, 1);

            //Action     
            carrinho.RemoverItem(produto2);

            //Assert
            Assert.AreEqual(carrinho.ItensCarrinho.Where(c => c.Produto == produto2).Count(), 0);
            Assert.AreEqual(carrinho.ItensCarrinho.Count(), 2);
        }

        [TestMethod]
        public void CalcularValorTotal()
        {
            //Arrange - criação dos produtos
            Produto produto1 = new Produto
            {
                ProdutoId = 1,
                Nome = "Teste 1",
                Preco = 100M
            };

            Produto produto2 = new Produto
            {
                ProdutoId = 2,
                Nome = "Teste 2",
                Preco = 50M
            };

            //Arrange
            Carrinho carrinho = new Carrinho();
            carrinho.AdicionarItem(produto1, 1);
            carrinho.AdicionarItem(produto2, 1);
            carrinho.AdicionarItem(produto1, 3);

            //Action     
            decimal resultado = carrinho.ObterValorTotal();

            //Assert
            Assert.AreEqual(resultado, 450M);
        }

        [TestMethod]
        public void LimparItensCarrinho()
        {
            //Arrange - criação dos produtos
            Produto produto1 = new Produto
            {
                ProdutoId = 1,
                Nome = "Teste 1",
                Preco = 100M
            };

            Produto produto2 = new Produto
            {
                ProdutoId = 2,
                Nome = "Teste 2",
                Preco = 50M
            };

            //Arrange
            Carrinho carrinho = new Carrinho();
            carrinho.AdicionarItem(produto1, 1);
            carrinho.AdicionarItem(produto2, 1);

            //Action     
            carrinho.LimparCarrinho();

            //Assert
            Assert.AreEqual(carrinho.ItensCarrinho.Count(), 0);
        }

    }

    
}
