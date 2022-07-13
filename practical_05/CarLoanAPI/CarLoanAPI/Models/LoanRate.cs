using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CarLoanAPI.Models
{
    public class LoanRate
    {
        public int Id { get; set; }

        [Range(1, 7)]
        public int Term { get; set; }

        [Range(0, 30)]
        [Column(TypeName = "decimal(4,2)")]
        public double Rate { get; set; }
    }
}
