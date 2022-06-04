using MyCompany.Models;

namespace MyCompany.Services
{
    public class DepartmentService
    {
        private List<Department> DepartmentList = new()
        {
            new Department{ Id = "FIN", Name = "Finance"},
            new Department{ Id = "HR", Name = "Human Resource"},
            new Department{ Id = "IT", Name = "Information Technology"},
            new Department{ Id = "SAL", Name = "Sales"}
        };

        public List<Department> GetAll()
        {
            return DepartmentList;
        }
    }
}
