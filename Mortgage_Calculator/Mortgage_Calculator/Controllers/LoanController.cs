using Mortgage_Calculator.Models;
using System.Collections.Generic;
using System.Web.Mvc;

namespace Mortgage_Calculator.Controllers
{
    public class LoanController : Controller
    {
        IIOHelper iOHelper = new DatabaseIOHelper();
        LoanAPIController loanAPIController = new LoanAPIController();

        // GET: Loan
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index([Bind(Include = "Principal,InterestRate,DurationYears")] MortgageModelInfo mortgageModelInfo)
        {
            if (ModelState.IsValid)
            {
                var mortgageInfo = loanAPIController.GetMonthlyPayment(mortgageModelInfo);

                ViewBag.Message = mortgageInfo.MortgageString;

                return View("Details", mortgageInfo);
            }
            else
            {
                return View("Index", mortgageModelInfo);
            }
        }

        public ActionResult List()
        {
            List<MortageInfo> mortgageInfos = loanAPIController.GetMortgagesList();

            return View("List", mortgageInfos);
        }

        public ActionResult Delete()
        {
            return View("Delete");
        }

        [HttpPost]
        public ActionResult DeletePost()
        {
            loanAPIController.DeleteMortgages();

            ViewBag.Message = "Mortgage data has been cleared succesfully";

            return View("Delete");
        }
    }
}