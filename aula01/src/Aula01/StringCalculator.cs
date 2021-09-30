using System.Linq;

namespace Aula01
{
    public class StringCalculator
    {
        public int Add(string number)
        {
            if (string.IsNullOrWhiteSpace(number))
                return 0;

            var numbers = number.Split(",").Select(x => int.Parse(x));
            return numbers.Sum();
        }
    }
}
