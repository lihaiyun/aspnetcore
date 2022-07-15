using BWW.Models;
using BWW.Services;
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
                    try
                    {
                        InstalmentList = await _loanService.GetInstalments(loanAmt);
                    }
                    catch(Exception)
                    {
                        string msg = "The service is not available. Please try again later.";
                        TempData["FlashMessage.Type"] = "danger";
                        TempData["FlashMessage.Text"] = msg;
                    }
                }
            }
            return Page();
        }
    }
}
