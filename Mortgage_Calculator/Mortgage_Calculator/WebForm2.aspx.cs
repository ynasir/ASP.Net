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
            IIOHelper ioHelper = new DatabaseIOHelper();

            var mortgageInfoList = new List<MortageInfo>();
            mortgageInfoList = ioHelper.GetAllMortgages();

            GridView1.DataSource = mortgageInfoList;
            GridView1.DataBind();
        }
    }
}