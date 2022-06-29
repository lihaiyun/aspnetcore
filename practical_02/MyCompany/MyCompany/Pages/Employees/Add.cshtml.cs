using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MyCompany.Models;

namespace MyCompany.Pages.Employees
{
    public class AddModel : PageModel
    {
        [BindProperty]
        public Employee MyEmployee { get; set; } = new();

        public static List<Department> DepartmentList { get; set; } = new() 
        {
            new Department{ DepartmentId = "FIN", Name = "Finance"},
            new Department{ DepartmentId = "HR", Name = "Human Resource"},
            new Department{ DepartmentId = "IT", Name = "Information Technology"},
            new Department{ DepartmentId = "SAL", Name = "Sales"}
        };

        public void OnGet()
        {
            // Test Data
            //MyEmployee.EmployeeId = "MAYT";
            //MyEmployee.NRIC = "S1111111D";
            //MyEmployee.Name = "May Tan";
            //MyEmployee.Gender = "F";
            //MyEmployee.DepartmentId = "IT";
        }

        public IActionResult OnPost()
        {
            if (ModelState.IsValid)
            {
                TempData["FlashMessage.Type"] = "success";
                TempData["FlashMessage.Text"] = string.Format("Employee {0} is added", MyEmployee.Name);
                return Redirect("/Employees");
            }
            return Page();
        }
    }
}
