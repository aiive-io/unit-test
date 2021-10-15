﻿using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Aula07.UnitTests
{
    public class PedidoTests
    {
        [Fact]
        public void AdicionarProduto_AdicionarProduto_ListaDeProdutosAumenta()
        {
            var product = new Produto("Arroz");
            var pedido = new Pedido();

            pedido.AdicionarProduto(product);

            pedido.Produtos.Count.Should().Be(1);
            pedido.Produtos.First().Should().Be(product);            
        }
    }
}