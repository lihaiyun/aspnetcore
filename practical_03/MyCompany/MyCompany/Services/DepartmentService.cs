using MyCompany.Models;

namespace MyCompany.Services
{
    public class DepartmentService
    {
        private List<Department> AllDepartments = new()
        {
            new Department{ Id = "FIN", Name = "Finance"},
            new Department{ Id = "HR", Name = "Human Resource"},
            new Department{ Id = "IT", Name = "Information Technology"},
            new Department{ Id = "SAL", Name = "Sales"}
        };

        public List<Department> GetAll()
        {
            return AllDepartments;
        }

        public Department? GetDepartmentById(string id)
        {
            Department? department = AllDepartments.FirstOrDefault(x => x.Id.Equals(id));
            return department;
        }
    }
}
