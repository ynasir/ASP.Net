using System;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Mortgage_Calculator.Controllers;
using Mortgage_Calculator.Models;

namespace Mortgage_Calculator.Tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void InitialTestOnHttpPost_AfterPopulatingValidData_ReturnsValidData()
        {
            var mortgageinfo = new MortgageModelInfo();
            mortgageinfo.Principal = 1000;
            mortgageinfo.DurationYears = 3;
            mortgageinfo.InterestRate = 2;

            var loanController = new LoanController();
            ViewResult result = loanController.Index(mortgageinfo) as ViewResult;
            string message = result.ViewBag.Message;

            Assert.AreEqual("With a principal of $1000, duration of 3 years and an interest rate of 2%, the monthly loan payment amount is $28.64", message);
        }

        [TestMethod]
        public void TestOnHttpPost_AfterPopulatingValidData_ReturnsValidData()
        {
            var mortgageinfo = new MortgageModelInfo();
            mortgageinfo.Principal = 1000;
            mortgageinfo.DurationYears = 2.5;
            mortgageinfo.InterestRate = 65;

            var loanController = new LoanController();
            ViewResult result = loanController.Index(mortgageinfo) as ViewResult;
            string message = result.ViewBag.Message;


            Assert.AreEqual("With a principal of $1000, duration of 2.5 years and an interest rate of 65%, the monthly loan payment amount is $68.17", message);
        }

        [TestMethod]
        public void TestMortgageHelper()
        {
            var mortgageinfo = new MortgageModelInfo();
            mortgageinfo.Principal = 1300;
            mortgageinfo.DurationYears = 2.75;
            mortgageinfo.InterestRate = 32;

            double monthlyPayment = new MortgageHelper(mortgageinfo.Principal, mortgageinfo.InterestRate,
                mortgageinfo.DurationYears).ComputeMothlyPayment();

            Assert.AreEqual(59.73, monthlyPayment);
        }
    }
}
