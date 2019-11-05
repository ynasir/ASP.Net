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
        // GET: Loan
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index([Bind(Include = "Principal,InterestRate,DurationYears")] MortgageInfo mortgageInfo)
        {
            if (ModelState.IsValid)
            {
                double monthlyPayment = new MortgageHelper(mortgageInfo.Principal, mortgageInfo.InterestRate,
                    mortgageInfo.DurationYears).ComputeMothlyPayment();

                ViewBag.Message = $"With a principal of ${mortgageInfo.Principal}, duration of {mortgageInfo.DurationYears} years and an interest rate of {mortgageInfo.InterestRate}%, the monthly loan payment amount is ${monthlyPayment}";


                return View("Details");
            }
            else
            {
                return View("Index", mortgageInfo);
            }
        }
    }
}