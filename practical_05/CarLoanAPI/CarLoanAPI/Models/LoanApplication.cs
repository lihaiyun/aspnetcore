using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CarLoanAPI.Models
{
    public class LoanApplication
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }

        [Required, RegularExpression(@"^[STFG]\d{7}[A-Z]$", ErrorMessage = "Invalid NRIC."), MaxLength(9)]
        public string NRIC { get; set; } = string.Empty;

        [Required, MaxLength(50)]
        public string Name { get; set; } = string.Empty;

        [Required, MinLength(8, ErrorMessage = "Invalid phone number."), MaxLength(8)]
        public string Contact { get; set; } = string.Empty;

        [Range(2000, 1e6)]
        [Column(TypeName = "decimal(9,2)")]
        public decimal Salary { get; set; }

        [Range(5000, 1e9)]
        [Column(TypeName = "decimal(12,2)")]
        public decimal LoanAmt { get; set; }

        [Range(1, 7)]
        public int Term { get; set; }

        public DateTime TimeCreated { get; set; } = DateTime.Now;
    }
}
