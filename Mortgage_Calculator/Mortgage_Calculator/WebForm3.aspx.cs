using System;

namespace Mortgage_Calculator
{
    public partial class WebForm3 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btn_clear_Click(object sender, EventArgs e)
        {
            IIOHelper ioHelper = new LogHelper();
            ioHelper.ClearMortgages();
        }
    }
}