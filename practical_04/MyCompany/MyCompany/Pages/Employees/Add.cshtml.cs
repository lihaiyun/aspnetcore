using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MyCompany.Models;
using MyCompany.Services;

namespace MyCompany.Pages.Employees
{
    public class AddModel : PageModel
    {
        private readonly EmployeeService _employeeService;
        private readonly DepartmentService _departmentService;

        public AddModel(EmployeeService employeeService, DepartmentService departmentService)
        {
            _employeeService = employeeService;
            _departmentService = departmentService;
        }

        [BindProperty]
        public Employee MyEmployee { get; set; } = new();

        public static List<Department> DepartmentList { get; set; } = new();

        public void OnGet()
        {
            // Test Data
            //MyEmployee.EmployeeId = "MAYT";
            //MyEmployee.NRIC = "S1111111D";
            //MyEmployee.Name = "May Tan";
            //MyEmployee.Gender = "F";
            //MyEmployee.DepartmentId = "IT";
            //MyEmployee.Salary = 5000;

            DepartmentList = _departmentService.GetAll();
        }

        public IActionResult OnPost()
        {
            if (ModelState.IsValid)
            {
                Employee? employee = _employeeService.GetEmployeeById(MyEmployee.EmployeeId);
                if (employee != null)
                {
                    TempData["FlashMessage.Type"] = "danger";
                    TempData["FlashMessage.Text"] = string.Format("Employee ID {0} alreay exists", MyEmployee.EmployeeId);
                    return Page();
                }

                _employeeService.AddEmployee(MyEmployee);
                TempData["FlashMessage.Type"] = "success";
                TempData["FlashMessage.Text"] = string.Format("Employee {0} is added", MyEmployee.Name);
                return Redirect("/Employees");
            }
            return Page();
        }
    }
}
