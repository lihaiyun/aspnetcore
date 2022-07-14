using CarLoanAPI.Models;
using CarLoanAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace CarLoanAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InstalmentController : ControllerBase
    {
        private readonly LoanRateService _loanRateService;

        public InstalmentController(LoanRateService loanRateService)
        {
            _loanRateService = loanRateService;
        }

        // GET: api/Instalment/50000
        [HttpGet("{loanAmt}")]
        public ActionResult<List<Instalment>> GetInstalment(decimal loanAmt)
        {
            try
            {
                List<Instalment> list = _loanRateService.GetInstalments(loanAmt);
                return Ok(list);
            }
            catch (Exception)
            {
                return BadRequest("Technical Error");
            }
        }
    }
}
