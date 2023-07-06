namespace CalculatorApi.Core
{
    public class Multiplication : IOperation
    {
        public double Calculate(double num1, double num2)
        {
            return num1 * num2;
        }
    }
}
