using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;

namespace BWW.Pages.CarLoan
{
    public class CalculatorModel : PageModel
    {
        [BindProperty]
        [Display(Name = "Car Price")]
        public decimal CarPrice { get; set; }

        [BindProperty]
        public decimal COE { get; set; }

        [BindProperty]
        [Display(Name = "Down Payment")]
        public decimal DownPayment { get; set; }

        public List<Instalment> InstalmentList { get; set; } = new();

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
