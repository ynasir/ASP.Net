using System;
using System.Collections.Generic;
using System.Web.UI;

namespace Mortgage_Calculator
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        private double _prinicipal;
        private double _years;
        private double _rate;
        private double _monthlypayment;

        private bool inputValid;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                PopulatInterestRateDropdown();
                rbtn15yrs.Checked = true;
                txt_other.Enabled = false;
            }
        }

        public double ComputeMonthlyPayment(double principal, double years, double rate)
        {
            double monthly = 0;
            double top = principal * rate / 1200.00;
            double bottom = 1 - Math.Pow(1.0 + rate / 1200.0, -12.0 * years);

            monthly = top / bottom;
            return monthly;
        }

        private void PopulatInterestRateDropdown()
        {
            List<double> interests = new List<double>() { 1, 1.25, 1.5, 1.75,
                2, 2.25, 2.5, 2.75,
            3, 3.25, 3.5, 3.75,
            4, 4.25, 4.5, 4.75,
            5, 5.25, 5.5, 5.75,
            6, 6.25, 6.5, 6.75,
            7, 7.25, 7.5, 7.75,
            8, 8.25, 8.5, 8.75,
            9, 9.25, 9.5, 9.75, 10};

            foreach (var interest in interests)
            {
                DropDownList1.Items.Add(interest.ToString());
            }
        }

        public void ValidateInput()
        {
            inputValid = true;

            if (string.IsNullOrEmpty(txt_Principal.Text) || !Double.TryParse(txt_Principal.Text, out _prinicipal))
            {
                Result.Text = "Enter an appropriate value for principal amount";
                inputValid = false;
            }
            else
            {
                Double.TryParse(txt_Principal.Text, out _prinicipal);
            }

            if (rbtn15yrs.Checked == true)
                _years = 15;
            else if (rbtn30yrs.Checked == true)
                _years = 30;
            else if (rbtnother.Checked == true)
                if (string.IsNullOrEmpty(txt_other.Text) || !Double.TryParse(txt_other.Text, out _years))
                {
                    Result.Text = "Enter an appropriate value for loan duration";
                    inputValid = false;
                }
                else
                {
                    Double.TryParse(txt_other.Text, out _years);
                }

            Double.TryParse(DropDownList1.SelectedValue, out _rate);
        }

        protected void OtherRadioChecked(object sender, EventArgs e)
        {
            txt_other.Enabled = true;
        }

        protected void OtherNotChecked(object sender, EventArgs e)
        {
            txt_other.Text = string.Empty;
            txt_other.Enabled = false;
        }

        protected void btn_calculate_Click(object sender, EventArgs e)
        {
            ValidateInput();

            if (inputValid)
            {
                try
                {
                    _monthlypayment = ComputeMonthlyPayment(_prinicipal, _years, _rate);
                    _monthlypayment = Math.Round(_monthlypayment, 2);

                    LogData();
                    Result.Text = "The monthly payment is: $" + _monthlypayment.ToString();
                }
                catch (Exception ex)
                {
                    Result.Text = "Fatal exception occured:\n" + ex.Message;
                }
            }
        }

        private void LogData()
        {   
            string outputtext = $"With a principal of ${_prinicipal}, duration of {_years} years and an interest rate of {_rate}%, the monthly loan payment amount is ${_monthlypayment}";

            IIOHelper ioHelper = new LogHelper();

            ioHelper.AddMortgage(outputtext, _prinicipal, _rate, _years, _monthlypayment);
        }
    }
}