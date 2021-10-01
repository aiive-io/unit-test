using Xunit;

namespace Aula01.UnitTest
{
    /// <summary>
    /// FizzBuzz
    /// 
    /// Vou passar um número. 
    /// - Se esse numero for divisivel por 3 o método retorna "Fizz"
    /// - Se esse numero for divisivel por 5 o método retorna "Buzz".
    /// - Se esse numero for divisivel por 5 e 3 o método retorna "FizzBuzz"
    /// - Senão ele retorna o numero. 
    /// </summary>
    public class FizzBuzzTests
    {
        [Theory]
        [InlineData(3)]
        [InlineData(6)]
        public void Output_NumeroDivisivelPor3_RetornaFizz(int number)
        {
            //AAA
            //A - Arrange
            var fizzBuzz = CreateFizzBuzz();

            //A - Act
            var result = fizzBuzz.Output(number);

            //A - Assert
            Assert.Equal("Fizz", result);
        }

        [Fact]
        public void Output_NumeroDivisivelPor5_RetornaBuzz()
        {
            //Arrange
            var fizzBuzz = CreateFizzBuzz();

            //Act
            var result = fizzBuzz.Output(5);

            //Assert
            Assert.Equal("Buzz", result);
        }

        [Fact]
        public void Output_NumeroDivisivelPor3E5_RetornaFizzBuzz()
        {
            //Arrange
            var fizzBuzz = CreateFizzBuzz();

            //Act
            var result = fizzBuzz.Output(15);

            //Assert
            Assert.Equal("FizzBuzz", result);
        }

        [Fact]
        public void Output_NumeroNaoDivisivelPor3NemPor5_RetornaNumero()
        {
            //Arrange
            var fizzBuzz = CreateFizzBuzz();

            //Act
            var result = fizzBuzz.Output(2);

            //Assert
            Assert.Equal("2", result);
        }

        private FizzBuzz CreateFizzBuzz()
        {
            return new FizzBuzz();
        }
    }
}
