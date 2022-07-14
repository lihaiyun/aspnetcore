using CarLoanAPI.Models;

namespace CarLoanAPI.Services
{
    public class LoanRateService
    {
        private readonly MyDbContext _context;

        public LoanRateService(MyDbContext context)
        {
            _context = context;
        }

        public List<Instalment> GetInstalments(decimal loanAmt)
        {
            List<Instalment> instalmentList = new();

            List<LoanRate> loanRateList = _context.LoanRates.ToList();
            foreach (LoanRate loanRate in loanRateList)
            {
                Instalment instalment = new Instalment(loanAmt, loanRate);
                instalmentList.Add(instalment);
            }

            return instalmentList;
        }
    }
}
