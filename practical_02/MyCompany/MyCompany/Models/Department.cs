using System.ComponentModel.DataAnnotations;

namespace MyCompany.Models
{
    public class Department
    {
        [Required, MinLength(2), MaxLength(8)]
        public string? Id { get; set; }

        [Required, MaxLength(30)]
        public string? Name { get; set; }
    }
}
