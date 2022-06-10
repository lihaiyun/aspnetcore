using MyCompany.Models;

namespace MyCompany.Services
{
    public class DepartmentService
    {
        private static List<Department> AllDepartments = new()
        {
            new Department{ DepartmentId = "FIN", Name = "Finance"},
            new Department{ DepartmentId = "HR", Name = "Human Resource"},
            new Department{ DepartmentId = "IT", Name = "Information Technology"},
            new Department{ DepartmentId = "SAL", Name = "Sales"}
        };

        public List<Department> GetAll()
        {
            return AllDepartments.OrderBy(d => d.Name).ToList();
        }

        public Department? GetDepartmentById(string id)
        {
            Department? department = AllDepartments.FirstOrDefault(x => x.DepartmentId.Equals(id));
            return department;
        }
    }
}
