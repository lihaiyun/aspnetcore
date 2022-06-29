using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace MyApplication.Pages
{
    public class GreetingModel : PageModel
    {
        [BindProperty]
        public string Name { get; set; } = string.Empty;

        public string Greeting { get; set; } = string.Empty;

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
