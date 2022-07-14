using CarLoanAPI.Models;
using CarLoanAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace CarLoanAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InstalmentController : ControllerBase
    {
        private readonly InstalmentService _instalmentService;

        public InstalmentController(InstalmentService instalmentService)
        {
            _instalmentService = instalmentService;
        }

        // GET: api/Instalment/50000
        [HttpGet("{loanAmt}")]
        public ActionResult<List<Instalment>> GetInstalment(decimal loanAmt)
        {
            try
            {
                List<Instalment> list = _instalmentService.GetInstalments(loanAmt);
                return Ok(list);
            }
            catch (Exception)
            {
                return BadRequest("Technical Error");
            }
        }
    }
}
