using System.ComponentModel.DataAnnotations;

namespace Pract2.Models
{
    public class Employee
    {
        [Required, MinLength(3, ErrorMessage = "Enter at least 3 characters."), MaxLength(8)]
        public string? Id { get; set; }

        [Required]
        public string? NRIC { get; set; }

        [Required, MaxLength(30)]
        public string? Name { get; set; }

        [Required]
        public string? Gender { get; set; }

        [DataType(DataType.Date)]
        public DateTime BirthDate { get; set; }

        [Range(1500, 9000, ErrorMessage = "Enter salary from 1500 to 9000.")]
        public decimal Salary { get; set; }

        [Required]
        public string? DeptId { get; set; }
    }
}
