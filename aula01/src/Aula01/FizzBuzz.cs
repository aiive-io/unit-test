namespace Aula01
{
    /// <summary>
    /// FizzBuzz
    /// 
    /// Vou passar um número. 
    /// - Se esse numero for divisivel por 3 o método retorna "Fizz"
    /// - Se esse numero for divisivel por 5 o método retorna "Buzz".
    /// - Se esse numero for divisivel por 5 e 3 o método retorn "FizzBuzz"
    /// - Senão ele retorna o numero. 
    /// </summary>
    public class FizzBuzz
    {
        public string Output(int number)
        {
            return number % 3 == 0 && number % 5 == 0 ? "FizzBuzz" :
                number % 3 == 0
                ? "Fizz" : number % 5 == 0
                ? "Buzz" : number.ToString();
        }
    }
}
