using Mortgage_Calculator.Models;
using System.Collections.Generic;
using System.Web.Http;

namespace Mortgage_Calculator.Controllers
{
    public class LoanAPIController : ApiController
    {
        IIOHelper iOHelper = new MortgageInfoDataAccess();

        // GET: api/LoanAPI/getMonthlyPayment
        [HttpGet, ActionName("getMonthlyPayment")]
        public MortageInfo GetMonthlyPayment(MortgageModelInfo mortgageModelInfo)
        {
            MortgageInfoDataAccess mortgageInfoDataAccess = (MortgageInfoDataAccess)iOHelper;

            return mortgageInfoDataAccess.AddMortgage(mortgageModelInfo);
        }

        // GET: api/LoanAPI/getMortgagesList
        [HttpGet, ActionName("getMortgagesList")]
        public List<MortageInfo> GetMortgagesList()
        {
            MortgageInfoDataAccess mortgageInfoDataAccess = (MortgageInfoDataAccess)iOHelper;

            return mortgageInfoDataAccess.GetAllMortgages();
        }

        // DELETE: api/LoanAPI/deleteMortgages
        [HttpDelete, ActionName("deleteMortgages")]
        public void DeleteMortgages()
        {
            MortgageInfoDataAccess mortgageInfoDataAccess = (MortgageInfoDataAccess)iOHelper;
            mortgageInfoDataAccess.ClearMortgages();
        }
    }
}
