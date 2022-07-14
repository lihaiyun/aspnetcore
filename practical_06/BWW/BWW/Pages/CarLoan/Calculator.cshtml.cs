using BWW.Models;
using BWW.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BWW.Pages.CarLoan
{
    public class CalculatorModel : PageModel
    {
        [BindProperty]
        public decimal CarPrice { get; set; }

        [BindProperty]
        public decimal COE { get; set; }

        [BindProperty]
        public decimal DownPayment { get; set; }

        public List<Instalment> InstalmentList { get; set; } = new();

        private readonly LoanService _loanService;

        public CalculatorModel(LoanService loanService)
        {
            _loanService = loanService;
        }

        public void OnGet()
        {
            // Test
            CarPrice = 80000;
            COE = 50000;
            DownPayment = 20000;
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (ModelState.IsValid)
            {
                decimal loanAmt = CarPrice + COE - DownPayment;
                if (loanAmt <= 0)
                {
                    string msg = "Please check your inputs. The enquired loan amount should be more than 0.";
                    TempData["FlashMessage.Type"] = "danger";
                    TempData["FlashMessage.Text"] = msg;

                    InstalmentList = new();
                    return Page();
                }
                else
                {
                    InstalmentList = await _loanService.GetInstalments(loanAmt);
                }
            }
            return Page();
        }
    }
}