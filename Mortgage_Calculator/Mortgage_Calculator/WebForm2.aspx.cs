using System;
using System.Collections.Generic;

namespace Mortgage_Calculator
{
    public partial class WebForm2 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            BindData();
        }

        private void BindData()
        {
            IIOHelper ioHelper = new LogHelper();

            var mortgageInfoList = new List<MortageInfo>();
            mortgageInfoList = ioHelper.GetAllMortgages();

            var mortgageStringList = new List<string>();

            foreach (var mortgageInfo in mortgageInfoList)
            {
                mortgageStringList.Add(mortgageInfo.MortgageString);
            }

            GridView1.DataSource = mortgageStringList;
            GridView1.DataBind();
        }
    }
}