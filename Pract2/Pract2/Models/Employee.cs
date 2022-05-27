using System.ComponentModel.DataAnnotations;

namespace Pract2.Models
{
    public class Employee
    {
        [Required, MinLength(3, ErrorMessage = "Enter at least 3 characters."), MaxLength(8)]
        [Display(Name = "Employee ID")]
        public string? Id { get; set; }

        [Required, RegularExpression(@"^[STFG]\d{7}[A-Z]$", ErrorMessage = "Invalid NRIC.")]
        public string? NRIC { get; set; }

        [Required, MaxLength(30)]
        public string? Name { get; set; }

        [Required]
        public string? Gender { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "Birthday")]
        public DateTime BirthDate { get; set; }

        [Range(1500, 9000)]
        public decimal Salary { get; set; }

        [Required]
        [Display(Name = "Department")]
        public string? DeptId { get; set; }
    }
}
