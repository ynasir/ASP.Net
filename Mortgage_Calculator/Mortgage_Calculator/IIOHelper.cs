using Mortgage_Calculator.Models;
using System.Collections.Generic;

namespace Mortgage_Calculator
{
    interface IIOHelper
    {
        List<MortageInfo> GetAllMortgages();
        void AddMortgage(string formattedMortgageString, double principal, double interest, double years, double monthlypayment);
        void ClearMortgages();
    }
}

