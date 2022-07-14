namespace BWW.Models
{
    public class Instalment
    {
        public decimal LoanAmt { get; set; }

        public int Term { get; set; }

        public decimal Rate { get; set; }

        public decimal InstalmentAmt { get; set; }
    }
}
