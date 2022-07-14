namespace CarLoanAPI.Models
{
    public class Instalment
    {
        public decimal LoanAmt { get; set; }

        public int Term { get; set; }

        public decimal Rate { get; set; }

        public decimal InstalmentAmt { get; set; }

        public Instalment(decimal loanAmt, LoanRate loanRate)
        {
            LoanAmt = loanAmt;
            Term = loanRate.Term;
            Rate = loanRate.Rate;
            InstalmentAmt = CalculateInstalment(LoanAmt, Term, Rate);
        }

        private static decimal CalculateInstalment(decimal loanAmt, int term, decimal rate)
        {
            double accrual = (double)loanAmt * Math.Pow(1 + (double)rate / 100 / 12, term * 12);
            double instalment = accrual / (term * 12);
            return (decimal)Math.Round(instalment, 1);
        }
    }
}
