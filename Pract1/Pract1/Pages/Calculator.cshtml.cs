using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Pract1.Pages
{
    public class CalculatorModel : PageModel
    {
        [BindProperty]
        public decimal Num1 { get; set; }

        [BindProperty]
        public decimal Num2 { get; set; }

        [BindProperty]
        public string? Operator { get; set; }

        public List<string> OperatorList { get; set; } = new() { "+", "-", "x", "/" };

        public string? ResultStr { get; set; }

        public void OnGet()
        {
        }

        public IActionResult OnPost()
        {
            if (string.IsNullOrEmpty(Operator))
            {
                ResultStr = string.Empty;
            }
            else if (Operator.Equals("+"))
            {
                ResultStr = Convert.ToString(Num1 + Num2);
            }
            else if (Operator.Equals("-"))
            {
                ResultStr = Convert.ToString(Num1 - Num2);
            }
            else if (Operator.Equals("x"))
            {
                ResultStr = Convert.ToString(Num1 * Num2);
            }
            else if (Operator.Equals("/"))
            {
                ResultStr = (Num2 == 0) ? "NA" : Convert.ToString(Num1 / Num2);
            }
            else
            {
                ResultStr = string.Empty;
            }

            return Page();
        }
    }
}
