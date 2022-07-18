using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MyCompany.Models;

namespace MyCompany.Pages.Employees
{
    public class IndexModel : PageModel
    {
        public List<Employee> EmployeeList { get; set; } = new()
        {
            new Employee {EmployeeId = "MAYT", NRIC = "S1111111D", Name = "May Tan", Gender = "F",
                BirthDate = DateTime.Parse("11/11/1980"), Salary = 5000, DepartmentId = "IT"},
            new Employee {EmployeeId = "JOHL", NRIC = "S1212121A", Name = "John Lim", Gender = "M",
                BirthDate = DateTime.Parse("01/11/1981"), Salary = 3000, DepartmentId = "HR" },
            new Employee {EmployeeId = "JOAT", NRIC = "S1313131B", Name = "Joann Tan", Gender = "F",
                BirthDate = DateTime.Parse("11/11/1990"), Salary = 4000 , DepartmentId = "FIN"},
            new Employee {EmployeeId = "PETA", NRIC = "S1234567D", Name = "Peter Ang", Gender = "M",
                BirthDate = DateTime.Parse("01/11/1991"), Salary = 5000, DepartmentId = "SAL" },
         };

        public void OnGet()
        {
        }
    }
}
