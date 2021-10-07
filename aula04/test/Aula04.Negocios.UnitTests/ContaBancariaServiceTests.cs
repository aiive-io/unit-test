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
        public void Debitar_ContaComSaldo_ContaDeveSerAtualizada()
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
            A.CallTo(() => fakeContaBancariaRepositorio.Atualizar(conta))
                .MustHaveHappenedOnceExactly();
        }

        [Fact]
        public void Debitar_ContaSemSaldoSemSaldoEmprestimo_RetornaExcecao()
        {
            //arrange
            var contaId = Guid.NewGuid();
            var saldoEmprestimo = 10;

            var conta = new ContaBancaria()
            {
                Id = contaId,
                Saldo = 0,
                SaldoEmprestimo = 0
            };

            var fakeContaBancariaRepositorio = A.Fake<IContaBancariaRepositorio>();
            A.CallTo(() => fakeContaBancariaRepositorio.GetById(contaId)).Returns(conta);

            var contaBancariaService = new ContaBancariaService(fakeContaBancariaRepositorio,
                null);

            //act
            Action act = () => contaBancariaService.Debitar(contaId, saldoEmprestimo);

            //assert
            act.Should().ThrowExactly<NegocioException>();
            //conta.SaldoEmprestimo.Should().Be(0);
            
        }

        [Fact]
        public void Debitar_ContaSemSaldoComSaldoEmprestimo_ValorDebitadoDoSaldoEmprestimo()
        {
            //arrange
            var contaId = Guid.NewGuid();
            var saldoEmprestimo = 10;

            var conta = new ContaBancaria()
            {
                Id = contaId,
                Saldo = 0,
                SaldoEmprestimo = saldoEmprestimo
            };

            var fakeContaBancariaRepositorio = A.Fake<IContaBancariaRepositorio>();
            A.CallTo(() => fakeContaBancariaRepositorio.GetById(contaId)).Returns(conta);

            var fakeChequeEspecialRepositorio = A.Fake<IChequeEspecialRepositorio>();

            var contaBancariaService = new ContaBancariaService(fakeContaBancariaRepositorio,
                fakeChequeEspecialRepositorio);

            //act
            contaBancariaService.Debitar(contaId, saldoEmprestimo);

            //assert
            conta.SaldoEmprestimo.Should().Be(0);
            A.CallTo(() => fakeChequeEspecialRepositorio.CriarEmprestimo(contaId, saldoEmprestimo))
                .MustHaveHappenedOnceExactly();
        }

        [Theory]
        [InlineData(10, 10, 0)]
        [InlineData(11, 10, 1)]
        public void Debitar_ContaComSaldo_ValorDebitadoDaConta(decimal saldo, decimal valor, decimal esperado)
        {
            //arrange
            var contaId = Guid.NewGuid();            

            var conta = new ContaBancaria()
            {
                Id = contaId,
                Saldo = saldo
            };

            var fakeContaBancariaRepositorio = A.Fake<IContaBancariaRepositorio>();
            A.CallTo(() => fakeContaBancariaRepositorio.GetById(contaId)).Returns(conta);

            var contaBancariaService = new ContaBancariaService(fakeContaBancariaRepositorio,
                null);

            //act
            contaBancariaService.Debitar(contaId, valor);

            //assert
            conta.Saldo.Should().Be(esperado);
            
        }
    }
}
