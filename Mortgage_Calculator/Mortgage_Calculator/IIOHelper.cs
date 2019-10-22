using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mortgage_Calculator
{
    public interface IIOHelper
    {
        List<MortageInfo> GetAllMortgages();
        void AddMortgage(string formattedMortgageString, double principal, double interest, double years, double monthlypayment);
        void ClearMortgages();
    }
}
