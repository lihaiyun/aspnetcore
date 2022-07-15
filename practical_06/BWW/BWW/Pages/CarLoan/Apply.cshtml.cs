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

        private readonly LoanService _loanService;

        public ApplyModel(LoanService loanService)
        {
            _loanService = loanService;
        }

        public void OnGet(decimal loanAmt, int term)
        {
            MyApplication.LoanAmt = loanAmt;
            MyApplication.Term = term;

            // Test
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
                if (!result)
                {
                    string msg = "Your loan application is not successful. Please try again later.";
                    TempData["FlashMessage.Type"] = "danger";
                    TempData["FlashMessage.Text"] = msg;
                    return Page();
                }
                else
                {
                    string msg = "Your loan application has been submitted for bank processing.";
                    TempData["FlashMessage.Type"] = "success";
                    TempData["FlashMessage.Text"] = msg;
                    return Redirect("/CarLoan/Calculator");
                }
            }
            return Page();
        }
    }
}
