using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mortgage_Calculator.Models;

namespace Mortgage_Calculator
{
    interface IIOHelper
    {
        List<MortageInfo> GetAllMortgages();
        void AddMortgage(string formattedMortgageString, double principal, double interest, double years, double monthlypayment);
        void ClearMortgages();
    }
}

