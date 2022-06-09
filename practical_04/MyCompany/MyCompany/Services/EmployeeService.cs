using MyCompany.Models;

namespace MyCompany.Services
{
    public class EmployeeService
    {
        private static List<Employee> AllEmployees = new()
        {
            new Employee {Id = "MAYT", NRIC = "S1111111D", Name = "May Tan",Gender = "F",
                BirthDate = DateTime.Parse("11/11/1980"), Salary = 5000, DepartmentId = "IT"},
            new Employee {Id = "JOHL", NRIC = "S1212121A", Name = "John Lim",Gender = "M",
                BirthDate = DateTime.Parse("01/11/1981"), Salary = 3000, DepartmentId = "HR" },
            new Employee {Id = "JOAT", NRIC = "S1313131B", Name = "Joann Tan",Gender = "F",
                BirthDate = DateTime.Parse("11/11/1990"), Salary = 4000 , DepartmentId = "FIN"},
            new Employee {Id = "PETA", NRIC = "S1234567D", Name = "Peter Ang",Gender = "M",
                BirthDate = DateTime.Parse("01/11/1991"), Salary = 5000, DepartmentId = "SAL" },
         };

        public List<Employee> GetAll()
        {
            return AllEmployees.OrderBy(m => m.Name).ToList();
        }

        public Employee? GetEmployeeById(string id)
        {
            Employee? employee = AllEmployees.FirstOrDefault(x => x.Id.Equals(id));
            return employee;
        }

        public void AddEmployee(Employee employee)
        {
            AllEmployees.Add(employee);
        }
    }
}
