using FakeItEasy;
using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Aula04.Negocios.UnitTests
{
    public class ContaBancariaServiceTests
    {
        [Fact]
        public void Debitar_ContaComSaldo_ValorDebitadoDaConta()
        {
            //arrange
            var contaId = Guid.NewGuid();
            var saldo = 10;

            var conta = new ContaBancaria()
            {
                Id = contaId,
                Saldo = saldo
            };

            var fakeContaBancariaRepositorio = A.Fake<IContaBancariaRepositorio>();
            A.CallTo(() => fakeContaBancariaRepositorio.GetById(contaId)).Returns(conta);

            var contaBancariaService = new ContaBancariaService(fakeContaBancariaRepositorio, null);

            //act
            contaBancariaService.Debitar(contaId, saldo);

            //assert
            conta.Saldo.Should().Be(0);
            A.CallTo(() => fakeContaBancariaRepositorio.Atualizar(conta)).MustHaveHappenedOnceExactly();
        }
    }
}
