using CalculatorApi.Models;

namespace CalculatorApi.Controllers.V1
{
    [ApiController]
    [ApiVersion("1.0")]
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
            double result;
            switch (model.Sign)
            {
                case '+':
                    {
                        result = model.FirstNumber + model.SecondNumber;
                        break;
                    }
                case '-':
                    {
                        result = model.FirstNumber - model.SecondNumber;
                        break;
                    }
                case '*':
                    {
                        result = model.FirstNumber * model.SecondNumber;
                        break;
                    }
                case '/':
                    {
                        result = model.SecondNumber != 0 ? model.FirstNumber / model.SecondNumber : 0;
                        break;
                    }
                default:
                    return "Invalid Sign";
            }
            return result.ToString(); ;
        }
    }
}
