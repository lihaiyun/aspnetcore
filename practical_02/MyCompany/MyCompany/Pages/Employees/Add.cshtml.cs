using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MyCompany.Models;

namespace MyCompany.Pages.Employees
{
    public class AddModel : PageModel
    {
        [BindProperty]
        public Employee MyEmployee { get; set; } = new Employee()
        {
            // Test Data
            //Id = "lihy",
            //NRIC = "S1234567A",
            //Name = "Haiyun",
            //Gender = "F",
            //DeptId = "IT",
            BirthDate = new DateTime(DateTime.Now.Year - 18, 1, 1),
            Salary = 3000
        };

        public List<Department> DepartmentList { get; set; } = Department.GetList();

        public void OnGet()
        {
        }

        public IActionResult OnPost()
        {
            TempData["FlashMessage.Type"] = "success";
            TempData["FlashMessage.Text"] = string.Format("Employee {0} is added", MyEmployee.Name);
            return Redirect("/Employees");
        }
    }
}
