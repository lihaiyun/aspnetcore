using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MyCompany.Models;
using MyCompany.Services;

namespace MyCompany.Pages.Employees
{
    public class AddModel : PageModel
    {
        private readonly DepartmentService _departmentService;

        public AddModel(DepartmentService departmentService)
        {
            _departmentService = departmentService;
        }

        [BindProperty]
        public Employee MyEmployee { get; set; } = new Employee()
        {
            // Test Data
            Id = "LIHY",
            NRIC = "S1234567A",
            Name = "Haiyun",
            Gender = "F",
            DepartmentId = "IT",
            BirthDate = new DateTime(DateTime.Now.Year - 18, 1, 1),
            Salary = 3000
        };

        public List<Department> DepartmentList { get; set; }

        public void OnGet()
        {
            DepartmentList = _departmentService.GetAll();
        }

        public IActionResult OnPost()
        {
            TempData["FlashMessage.Type"] = "success";
            TempData["FlashMessage.Text"] = string.Format("Employee {0} is added", MyEmployee.Name);
            return Redirect("/Employees");
        }
    }
}
