using BWW.Models;
using BWW.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BWW.Pages.CarLoan
{
    public class CalculatorModel : PageModel
    {
        [BindProperty]
        public decimal MyCarPrice { get; set; }

        [BindProperty]
        public decimal MyCOE { get; set; }

        [BindProperty]
        public decimal MyDownPayment { get; set; }

        public decimal MyLoanAmt { get; set; }

        public string MyErrMsg { get; set; } = string.Empty;

        public List<Instalment> MyInstalmentList { get; set; } = new();

        private readonly LoanService _loanService;

        public CalculatorModel(LoanService loanService)
        {
            _loanService = loanService;
        }

        public void OnGet()
        {
            // Test
            MyCarPrice = 80000;
            MyCOE = 50000;
            MyDownPayment = 20000;
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (ModelState.IsValid)
            {
                MyLoanAmt = MyCarPrice + MyCOE - MyDownPayment;
                if (MyLoanAmt > 0)
                    MyInstalmentList = await _loanService.GetInstalments(MyLoanAmt);
                else
                    MyErrMsg = "Please correct the inputs, the enquired loan is less than 0!";
            }
            return Page();
        }
    }
}
