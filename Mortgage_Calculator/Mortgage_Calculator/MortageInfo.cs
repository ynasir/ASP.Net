using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Mortgage_Calculator
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