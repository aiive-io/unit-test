using FluentAssertions;
using Xunit;

namespace Aula01.UnitTest
{
    public class StringCalculatorTests
    {
        [Fact]
        public void Add_ParametroVazio_Retorna0()
        {
            //Arrange
            var calculator = CreateStringCalculator();

            //Act
            var result = calculator.Add("");

            //Assert
            result.Should().Be(0);
            Assert.Equal(0, result);

        }

        [Theory]
        [InlineData("1", 1)]
        [InlineData("2", 2)]
        public void Add_ParametroComUmNumero_RetornaNumero(string numbers, int esperado)
        {
            //Arrange
            var calculator = CreateStringCalculator();

            //Act
            var result = calculator.Add(numbers);

            //Assert
            result.Should().Be(esperado);
            Assert.Equal(esperado, result);
        }


        [Theory]
        [InlineData("1,2", 3)]
        [InlineData("1,3", 4)]
        public void Add_ParametroComDoisNumeros_RetornaSoma(string numeros, int esperado)
        {
            //Arrange
            var calculator = CreateStringCalculator();

            //Act
            var result = calculator.Add(numeros);

            //Assert
            result.Should().Be(esperado);
            Assert.Equal(esperado, result);
        }

        [Fact]
        public void Add_ParametrosComMaisDeDoisNumeros_RetornaSoma()
        {
            var calculator = CreateStringCalculator();

            var result = calculator.Add("1,2,3");

            result.Should().Be(6);
        }

        private StringCalculator CreateStringCalculator()
        {
            return new StringCalculator();
        }
    }
}
