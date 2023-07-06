using System.ComponentModel.DataAnnotations;

namespace CalculatorApi.Models
{
    public class CalculatorModel
    {
        [Required]
        public double FirstNumber { get; set; }

        [Required]
        public double SecondNumber { get; set; }

        [Required]
        public char Sign { get; set; }
    }
}
