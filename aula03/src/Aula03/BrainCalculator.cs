namespace Aula03
{
    public class BrainCalculator
    {
        public string LastCalc { get; private set; }
        public int LastResult { get; private set; }

        public decimal Add(int a, int b)
        {
            LastResult = (a + b);
            LastCalc = $" {a} + {b}";
            return LastResult;
        }

        public decimal Subtract(int a, int b)
        {
            LastResult = (a - b);
            LastCalc = $" {a} - {b}";
            return LastResult;
        }
        
    }
}
