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

        [BindProperty]
        public Employee MyEmployee { get; set; } = new();

        public static List<Department> DepartmentList { get; set; } = new();

        public IActionResult OnGet(string id)
        {
            DepartmentList = _departmentService.GetAll();

            Employee? employee = _employeeService.GetEmployeeById(id);
            if (employee != null)
            {
                MyEmployee = employee;
                return Page();
            }
            else
            {
                return Redirect("/Employees");
            }
        }

        public IActionResult OnPost()
        {
            if (ModelState.IsValid)
            {
                _employeeService.UpdateEmployee(MyEmployee);
                TempData["FlashMessage.Type"] = "success";
                TempData["FlashMessage.Text"] = string.Format("Employee {0} is updated", MyEmployee.Name);
            }
            return Page();
        }
    }
}
