using Mortgage_Calculator.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Mortgage_Calculator.Controllers
{
    public class LoanController : Controller
    {
        IIOHelper iOHelper = new DatabaseIOHelper();

        // GET: Loan
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index([Bind(Include = "Principal,InterestRate,DurationYears")] MortgageModelInfo mortgageInfo)
        {
            if (ModelState.IsValid)
            {
                double monthlyPayment = new MortgageHelper(mortgageInfo.Principal, mortgageInfo.InterestRate,
                    mortgageInfo.DurationYears).ComputeMothlyPayment();

                string formattedString = $"With a principal of ${mortgageInfo.Principal}, duration of {mortgageInfo.DurationYears} years and an interest rate of {mortgageInfo.InterestRate}%, the monthly loan payment amount is ${monthlyPayment}";

                ViewBag.Message = formattedString;
                iOHelper.AddMortgage(formattedString, mortgageInfo.Principal, mortgageInfo.InterestRate,
                    mortgageInfo.DurationYears, monthlyPayment);

                return View("Details");
            }
            else
            {
                return View("Index", mortgageInfo);
            }
        }

        public ActionResult List()
        {
            List<MortageInfo> mortgageInfos = iOHelper.GetAllMortgages();


            return View("List", mortgageInfos);
        }

        public ActionResult Delete()
        {
            return View("Delete");
        }

        [HttpPost]
        public ActionResult DeletePost()
        {
            iOHelper.ClearMortgages();

            ViewBag.Message = "Mortgage data has been cleared succesfully";

            return View("Delete");
        }
    }
}