namespace CalculatorApi.Core
{
    class Calculator
    {
        private IOperation _operation;
        public Calculator(IOperation operation)
        {
            _operation = operation;
        }
        public double Execute(double num1, double num2) 
        {
           return _operation.Calculate(num1, num2);
        }
    }
}
