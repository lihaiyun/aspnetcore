using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MyCompany.Models;
using MyCompany.Services;

namespace MyCompany.Pages.Employees
{
    public class IndexModel : PageModel
    {
        private readonly EmployeeService _employeeService;

        public IndexModel(EmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        public List<Employee> EmployeeList { get; set; } = new();

        public void OnGet()
        {
            EmployeeList = _employeeService.GetAll().OrderBy(m => m.Name).ToList();
        }
    }
}
