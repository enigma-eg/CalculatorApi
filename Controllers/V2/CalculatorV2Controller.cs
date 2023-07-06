using CalculatorApi.Core;
using CalculatorApi.Models;

namespace CalculatorApi.Controllers.V2
{
    [ApiController]
    [ApiVersion("2.0")]
    public class CalculatorController : VersionedApiController
    {

        /// <summary>
        ///Calculator for four basic arithmetic operations (+, -, *, /)
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        public string Calculate(CalculatorModel model)
        {
            Calculator calculator;
            switch (model.Sign)
            {
                case '+':
                    {
                        calculator = new Calculator(new Addition());
                        break;
                    }
                case '-':
                    {
                        calculator = new Calculator(new Subtraction());
                        break;
                    }
                case '*':
                    {
                        calculator = new Calculator(new Multiplication());
                        break;
                    }
                case '/':
                    {
                        calculator = new Calculator(new Division());
                        break;
                    }
                default:
                    return "Invalid Sign";
            }
            return calculator.Execute(model.FirstNumber, model.SecondNumber).ToString();
        }
    }
}
