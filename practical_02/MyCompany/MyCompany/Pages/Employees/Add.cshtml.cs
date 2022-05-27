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
            BirthDate = new DateTime(DateTime.Now.Year - 18, 1, 1),
            Salary = 3000
        };

        public List<Department> DepartmentList { get; set; } = Department.GetList();

        public void OnGet()
        {
        }

        public IActionResult OnPost()
        {
            return Page();
        }
    }
}
