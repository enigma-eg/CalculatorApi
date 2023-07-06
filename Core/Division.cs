namespace CalculatorApi.Core
{
    public class Division : IOperation
    {
        public double Calculate(double num1, double num2)
        {
            return num2 != 0 ? num1 / num2 : 0;
        }
    }
}
