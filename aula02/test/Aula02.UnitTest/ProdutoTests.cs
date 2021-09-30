using FluentAssertions;
using System;
using System.Collections;
using System.Collections.Generic;
using Xunit;

namespace Aula02.UnitTest
{
    public class DataValidaTests : IEnumerable<object[]>
    {
        public IEnumerator<object[]> GetEnumerator()
        {
            yield return new object[] { new DateTime(day: 03, month: 01, year: 2021), new DateTime(day: 02, month: 01, year: 2021) };
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }

    public class ProdutoTests
    {
        /// <summary>
        /// [Unidade]_[Cenário]_[ComportamentoEsperado]
        /// </summary>
        [Fact]
        public void EstaValido_ProdutoComDataValidadeMaiorQueHoje_RetornaVerdadeiro()
        {
            //produto 1
        }

        [Theory]
        //[MemberData(nameof(Data))]    
        [ClassData(typeof(DataValidaTests))]
        public void EstaValido_ProdutoComDataValidade_RetornaVerdadeiro(DateTime data, DateTime dataValidade)

        {
            var produto = new Produto();
            produto.DataValidade = data;

            Assert.True(produto.EstaValido(dataValidade));
        }

        [Theory]
        [MemberData(nameof(DataInvalidas))]
        public void EstaValido_ProdutoForaDaDataDeValidade_RetornaFalso(DateTime data, DateTime dataValidade)

        {
            var produto = new Produto();
            produto.DataValidade = data;
            var act = produto.EstaValido(dataValidade);

            act.Should().BeTrue();

            Assert.False(produto.EstaValido(dataValidade));
        }

        public static IEnumerable<object[]> Data =>
        new List<object[]>
        {
            new object[] { new DateTime(day: 03, month: 01, year:2021), new DateTime(day: 02, month: 01, year: 2021)},
        };

        public static IEnumerable<object[]> DataInvalidas =>
        new List<object[]>
        {
            new object[] { new DateTime(day: 01, month: 01, year:2021), new DateTime(day: 02, month: 01, year: 2021)},
        };

        [Fact]
        public void Produto_Dentro_Do_Prazo_De_Validade_Eh_Valido()
        {
            //produto 2
        }

        [Fact]
        public void Produto_ComDataValidadePreenchida_RetornaDataValidade()
        {
            var produto = CriarProduto();

            var data = DateTime.Now;

            produto.DataValidade = data;

            Assert.Equal(data, produto.DataValidade);
        }

        public Produto CriarProduto()
        {
            return new Produto();
        }
    }
}
