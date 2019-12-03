using System.Collections.Generic;

namespace Mortgage_Calculator.Models
{
    public class MortgageInfoDataAccess : IIOHelper
    {
        DatabaseIOHelper DatabaseIOHelper = new DatabaseIOHelper();

        public MortageInfo AddMortgage(MortgageModelInfo mortgageModelInfo)
        {
            MortageInfo mortgageInfo = new MortageInfo();
            mortgageInfo.Principal = mortgageModelInfo.Principal;
            mortgageInfo.InterestRate = mortgageModelInfo.InterestRate;
            mortgageInfo.DurationYears = mortgageModelInfo.DurationYears;
            mortgageInfo.MonthlyPayment = new MortgageHelper(mortgageModelInfo.Principal, mortgageModelInfo.InterestRate,
               mortgageModelInfo.DurationYears).ComputeMothlyPayment();

            mortgageInfo.MortgageString = $"With a principal of ${mortgageInfo.Principal}, duration of {mortgageInfo.DurationYears} years and an interest rate of {mortgageInfo.InterestRate}%, the monthly loan payment amount is ${mortgageInfo.MonthlyPayment}";

            AddMortgage(mortgageInfo.MortgageString, mortgageInfo.Principal, mortgageInfo.InterestRate,
                mortgageInfo.DurationYears, mortgageInfo.MonthlyPayment);

            return mortgageInfo;
        }

        public void AddMortgage(string formattedMortgageString, double principal, double interest, double years, double monthlypayment)
        {
            DatabaseIOHelper.AddMortgage(formattedMortgageString, principal, interest, years, monthlypayment);
        }

        public void ClearMortgages()
        {
            DatabaseIOHelper.ClearMortgages();
        }

        public List<MortageInfo> GetAllMortgages()
        {
            return DatabaseIOHelper.GetAllMortgages();
        }
    }
}