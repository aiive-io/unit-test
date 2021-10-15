using FluentAssertions;
using System;
using Xunit;

namespace Aula07.UnitTests
{
    public class LojistaTests
    {
        [Fact]
        public void Discount_of_two_products()
        {
            var product1 = new Produto("Arroz");
            var product2 = new Produto("Feijao");
            var lojista = new Lojista();
            var result  = lojista.CalcularDesconto(product1, product2);

            result.Should().Be(0.02m);            
        }       
    }
}
