using Microsoft.VisualStudio.TestTools.UnitTesting;
using Mortgage_Calculator.Controllers;
using Mortgage_Calculator.Models;
using System.Collections.Generic;

namespace Mortgage_Calculator.Tests
{
    [TestClass]
    public class APITest
    {
        [TestMethod]
        public void InitialTestOnHttpGet__ReturnsMonthlyPayment()
        {
            var mortgageModelinfo = new MortgageModelInfo();
            mortgageModelinfo.Principal = 1300;
            mortgageModelinfo.DurationYears = 2.75;
            mortgageModelinfo.InterestRate = 32;

            LoanAPIController loanAPIController = new LoanAPIController();

            MortageInfo mortgageInfo = loanAPIController.GetMonthlyPayment(mortgageModelinfo);
            Assert.AreEqual(59.73, mortgageInfo.MonthlyPayment);
        }

        [TestMethod]
        public void InitialTestOnHttpGet__ReturnsMortgageString()
        {
            var mortgageModelinfo = new MortgageModelInfo();
            mortgageModelinfo.Principal = 1300;
            mortgageModelinfo.DurationYears = 2.75;
            mortgageModelinfo.InterestRate = 32;

            LoanAPIController loanAPIController = new LoanAPIController();

            MortageInfo mortgageInfo = loanAPIController.GetMonthlyPayment(mortgageModelinfo);

            Assert.AreEqual("With a principal of $1300, duration of 2.75 years" +
                " and an interest rate of 32%," +
                " the monthly loan payment amount is $59.73", mortgageInfo.MortgageString);
        }

        [TestMethod]
        public void InitialTestOnHttpGet__ReturnsMortgagesList()
        {
            LoanAPIController loanAPIController = new LoanAPIController();
            loanAPIController.DeleteMortgages();

            var mortgagesList = new List<MortageInfo>();

            var mortgageModelinfo = new MortgageModelInfo();
            mortgageModelinfo.Principal = 1300;
            mortgageModelinfo.DurationYears = 2.75;
            mortgageModelinfo.InterestRate = 32;
            loanAPIController.GetMonthlyPayment(mortgageModelinfo);

            mortgageModelinfo.Principal = 1400;
            mortgageModelinfo.DurationYears = 4.75;
            mortgageModelinfo.InterestRate = 30;
            loanAPIController.GetMonthlyPayment(mortgageModelinfo);

            mortgagesList = loanAPIController.GetMortgagesList();

            Assert.AreEqual(2, mortgagesList.Count);
        }

        [TestMethod]
        public void InitialTestOnHttpDelete__ReturnsEmptyMortgagesList()
        {
            LoanAPIController loanAPIController = new LoanAPIController();
            loanAPIController.DeleteMortgages();

            var mortgagesList = new List<MortageInfo>();

            mortgagesList = loanAPIController.GetMortgagesList();

            Assert.AreEqual(0, mortgagesList.Count);
        }
    }
}
