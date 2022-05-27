using System.ComponentModel.DataAnnotations;

namespace Pract2.Models
{
    public class Department
    {
        [Required, MinLength(2), MaxLength(8)]
        public string? Id { get; set; }

        [Required, MaxLength(30)]
        public string? Name { get; set; }

        public static List<Department> GetList()
        {
            List<Department> list = new()
            {
                new Department{ Id = "FIN", Name = "Finance"},
                new Department{ Id = "HR", Name = "Human Resource"},
                new Department{ Id = "IT", Name = "Information Technology"},
                new Department{ Id = "SAL", Name = "Sales"}
            };
            return list;
        }
    }
}
