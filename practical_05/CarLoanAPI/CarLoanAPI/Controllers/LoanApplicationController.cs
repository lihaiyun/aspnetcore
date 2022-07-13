using CarLoanAPI.Models;
using CarLoanAPI.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarLoanAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoanApplicationController : ControllerBase
    {
        private readonly LoanApplicationService _loanApplicationService;

        public LoanApplicationController(LoanApplicationService loanApplicationService)
        {
            _loanApplicationService = loanApplicationService;
        }

        // POST:api/LoanApplication
        [HttpPost]
        public IActionResult AddLoanApplication(LoanApplication loanApplication)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                _loanApplicationService.AddLoanApplication(loanApplication);
            }
            catch (Exception)
            {
                return BadRequest("Technical Error");
            }

            return Ok();
        }
    }
}
