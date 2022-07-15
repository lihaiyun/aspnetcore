using System.ComponentModel.DataAnnotations;

namespace BWW.Models
{
    public class LoanApplication
    {
        [Required, RegularExpression(@"^[STFG]\d{7}[A-Z]$", ErrorMessage = "Invalid NRIC."), MaxLength(9)]
        public string NRIC { get; set; } = string.Empty;

        [Required, MaxLength(50)]
        public string Name { get; set; } = string.Empty;

        [Required, MinLength(8, ErrorMessage = "Invalid phone number."), MaxLength(8)]
        public string Contact { get; set; } = string.Empty;

        [Range(2000, 1e6)]
        [Display(Name = "Monthly Salary")]
        public decimal Salary { get; set; }

        [Range(5000, 1e9)]
        [Display(Name = "Loan Amount")]
        public decimal LoanAmt { get; set; }

        [Range(1, 7)]
        public int Term { get; set; }
    }
}
