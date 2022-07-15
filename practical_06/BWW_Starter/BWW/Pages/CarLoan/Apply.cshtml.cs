using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BWW.Pages.CarLoan
{
    public class ApplyModel : PageModel
    {
        [BindProperty]
        public LoanApplication MyApplication { get; set; } = new();

        public void OnGet()
        {
        }

        public IActionResult OnPost()
        {
            if (ModelState.IsValid)
            {
            }
            return Page();
        }
    }
}
