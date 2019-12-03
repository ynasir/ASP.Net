namespace Mortgage_Calculator.Models
{
    public class MortageInfo
    {
        public double Principal { get; set; }

        public double InterestRate { get; set; }

        public double DurationYears { get; set; }

        public double MonthlyPayment { get; set; }

        public string MortgageString { get; set; }
    }
}