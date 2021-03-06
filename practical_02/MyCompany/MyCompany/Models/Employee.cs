using System.ComponentModel.DataAnnotations;

namespace MyCompany.Models
{
    public class Employee
    {
        [Required, MinLength(3, ErrorMessage = "Enter at least 3 characters."), MaxLength(8)]
        [Display(Name = "Employee ID")]
        public string EmployeeId { get; set; } = string.Empty;

        [Required, RegularExpression(@"^[STFG]\d{7}[A-Z]$", ErrorMessage = "Invalid NRIC."), MaxLength(9)]
        public string NRIC { get; set; } = string.Empty;

        [Required, MaxLength(50)]
        public string Name { get; set; } = string.Empty;

        [Required, MaxLength(1)]
        public string Gender { get; set; } = string.Empty;

        [DataType(DataType.Date)]
        [Display(Name = "Birthday")]
        public DateTime BirthDate { get; set; } = new DateTime(DateTime.Now.Year - 18, 1, 1);

        [Required]
        [Display(Name = "Department")]
        public string DepartmentId { get; set; } = string.Empty;

        [Range(2000, 15000)]
        public decimal Salary { get; set; }
    }
}
