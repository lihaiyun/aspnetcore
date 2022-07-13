using CarLoanAPI.Models;

namespace CarLoanAPI.Services
{
    public class LoanApplicationService
    {
        private readonly MyDbContext _context;

        public LoanApplicationService(MyDbContext context)
        {
            _context = context;
        }

        public void AddLoanApplication(LoanApplication loanApplication)
        {
            _context.LoanApplications.Add(loanApplication);
            _context.SaveChanges();
        }
    }
}
