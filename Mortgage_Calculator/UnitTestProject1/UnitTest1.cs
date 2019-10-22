using Microsoft.VisualStudio.TestTools.UnitTesting;
using Mortgage_Calculator;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {

        [TestMethod]
        public void Test_ComputemothlyPayment()
        {
            var webform = new WebForm1();

            double monthlyPayment = webform.ComputeMonthlyPayment(1000, 3, 2.5);
            monthlyPayment = Math.Round(monthlyPayment, 2);

            Assert.AreEqual(monthlyPayment, 28.86);
        }

        [TestMethod]
        public void Test_Add_IOFile()
        {    
            var testLogHelper = new TestLogHelper();

            string text = $"With a principal of $1000, duration of 2 years and an interest rate of 3%, the monthly loan payment amount is $42.98";

            testLogHelper.AddMortgage(text, 1000, 3, 2, 4000);

            string expectedtext = File.ReadLines(testLogHelper.GetFilePath()).Last().Split(';')[0];

            Assert.AreEqual(expectedtext, text);
            testLogHelper.ClearMortgages();
        }

        [TestMethod]
        public void Test_Clear_IOFile()
        {
            var testLogHelper = new TestLogHelper();

            testLogHelper.ClearMortgages();

            string filepath = testLogHelper.GetFilePath();

            Assert.AreEqual(new FileInfo(filepath).Length, 0);
        }

        [TestMethod]
        public void Test_ListData_IOFile()
        {
            var testLogHelper = new TestLogHelper();
            testLogHelper.ClearMortgages();

            string actualtext1 = $"With a principal of $1000, duration of 2 years and an interest rate of 3%, the monthly loan payment amount is $42.98";
            string actualtext2 = $"With a principal of $1500, duration of 3 years and an interest rate of 3.5%, the monthly loan payment amount is $43.95";

            testLogHelper.AddMortgage(actualtext1, 1000, 3, 2, 4000);
            testLogHelper.AddMortgage(actualtext2, 1000, 3, 2, 4000);

           List<MortageInfo> testlogList = testLogHelper.GetAllMortgages();

            Assert.AreEqual(testlogList[0].MortgageString, actualtext1);
            Assert.AreEqual(testlogList[1].MortgageString, actualtext2);

            testLogHelper.ClearMortgages();
        }
    }
}
