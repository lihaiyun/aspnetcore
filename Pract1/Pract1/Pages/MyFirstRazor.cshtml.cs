using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Pract1.Pages
{
    public class MyFirstRazorModel : PageModel
    {
        [BindProperty]
        public string? Name { get; set; }

        public string Greeting = string.Empty;

        public void OnGet()
        {
        }

        public IActionResult OnPost()
        {
            Greeting = string.Format("Welcome {0}!", string.IsNullOrWhiteSpace(Name) ? "Guest" : Name);

            return Page();
        }
    }
}
