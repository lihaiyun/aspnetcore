using BWW.Models;
using BWW.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BWW.Pages.CarLoan
{
    public class ApplyModel : PageModel
    {
        [BindProperty]
        public LoanApplication MyApplication { get; set; } = new();

        public string MyMsg { get; set; } = string.Empty;

        private readonly LoanService _loanService;

        public ApplyModel(LoanService loanService)
        {
            _loanService = loanService;
        }

        public void OnGet(decimal loanAmt, int term)
        {
            MyApplication.LoanAmt = loanAmt;
            MyApplication.Term = term;

            MyApplication.Name = "Haiyun";
            MyApplication.NRIC = "S1234567A";
            MyApplication.Contact = "65501622";
            MyApplication.Salary = 5000;
        }

        public IActionResult OnPost()
        {
            if (ModelState.IsValid)
            {
                bool result = _loanService.SubmitLoanApplication(MyApplication);
                if (result)
                {
                    MyMsg = "Your loan application is submitted for bank processing!";
                }
                else
                {
                    MyMsg = "Your loan application is not successful, please correct input error.";
                    MyMsg += " If problem persists, please contact system administrator!";
                }
            }
            return Page();
        }
    }
}
