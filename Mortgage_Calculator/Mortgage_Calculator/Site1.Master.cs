using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Mortgage_Calculator
{
    public partial class Site1 : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Unnamed_Tick(object sender, EventArgs e)
        {
            TimeofDay.Text = DateTime.Now.ToLocalTime().ToString();
        }
    }
}