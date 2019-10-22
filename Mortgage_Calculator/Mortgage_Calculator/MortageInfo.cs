using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Mortgage_Calculator
{
    public class MortageInfo
    {
        public string MortgageString { get; set; }

        public double Principal { get; set; }

        public double Interest { get; set; }

        public double NoOfYears { get; set; }

        public double MonthlyPayment { get; set; }
    }
}