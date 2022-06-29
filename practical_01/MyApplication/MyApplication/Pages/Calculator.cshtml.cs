using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace MyApplication.Pages
{
    public class CalculatorModel : PageModel
    {
        [BindProperty]
        public decimal Num1 { get; set; }

        [BindProperty]
        public decimal Num2 { get; set; }

        [BindProperty]
        public string Operator { get; set; } = string.Empty;

        public List<string> OperatorList { get; set; } = new() { "+", "-", "x", "/" };

        public string Result { get; set; } = string.Empty;

        public void OnGet()
        {
        }

        public IActionResult OnPost()
        {
            if (string.IsNullOrEmpty(Operator))
            {
                Result = string.Empty;
            }
            else if (Operator.Equals("+"))
            {
                Result = Convert.ToString(Num1 + Num2);
            }
            else if (Operator.Equals("-"))
            {
                Result = Convert.ToString(Num1 - Num2);
            }
            else if (Operator.Equals("x"))
            {
                Result = Convert.ToString(Num1 * Num2);
            }
            else if (Operator.Equals("/"))
            {
                Result = (Num2 == 0) ? "NA" : Convert.ToString(Num1 / Num2);
            }
            else
            {
                Result = string.Empty;
            }

            return Page();
        }
    }
}
