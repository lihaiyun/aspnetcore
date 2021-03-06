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

        public IActionResult OnGet(string id)
        {
            Employee? employee = _employeeService.GetEmployeeById(id);
            if (employee != null)
            {
                MyEmployee = employee;
                MyEmployee.Department = _departmentService.GetDepartmentById(employee.DepartmentId);
                return Page();
            }
            else
            {
                TempData["FlashMessage.Type"] = "danger";
                TempData["FlashMessage.Text"] = string.Format("Employee ID {0} not found", id);
                return Redirect("/Employees");
            }
        }
    }
}
