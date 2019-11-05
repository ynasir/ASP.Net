using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Mortgage_Calculator
{
    public class MortgageHelper
    {
        private double principal;
        private double interestRate;
        private double durationYears;

        public MortgageHelper(double _principal, double _interestRate, double _durationYears)
        {
            principal = _principal;
            interestRate = _interestRate;
            durationYears = _durationYears;
        }

        public double ComputeMothlyPayment()
        {
            double monthly = 0;
            double top = principal * interestRate / 1200.00;
            double bottom = 1 - Math.Pow(1.0 + interestRate / 1200.0, -12.0 * durationYears);

            monthly = top / bottom;
            monthly = Math.Round(monthly, 2);

            return monthly;
        }
    }
}