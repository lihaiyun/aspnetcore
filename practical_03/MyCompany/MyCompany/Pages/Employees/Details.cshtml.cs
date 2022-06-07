using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MyCompany.Models;
using MyCompany.Services;

namespace MyCompany.Pages.Employees
{
    public class DetailsModel : PageModel
    {
        private readonly EmployeeService _employeeService;
        private readonly DepartmentService _departmentService;

        public DetailsModel(EmployeeService employeeService, DepartmentService departmentService)
        {
            _employeeService = employeeService;
            _departmentService = departmentService;
        }

        public Employee MyEmployee { get; set; } = new();

        public void OnGet(string id)
        {
            Employee? employee = _employeeService.GetEmployeeById(id);
            if (employee != null)
            {
                MyEmployee = employee;

                Department? department = _departmentService.GetDepartmentById(employee.DepartmentId);
                if (department != null)
                {
                    MyEmployee.Department = department;
                }
            }
        }
    }
}
