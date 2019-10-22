using Mortgage_Calculator;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Web;

namespace Mortgage_Calculator
{
    public class LogHelper : IIOHelper
    {
        public List<MortageInfo> GetAllMortgages()
        {
            string filename = GetServerMapPath();


            int mortgageString = 0, principal = 1, interest = 2, years = 3, monthlypayment = 4;
            var mortgageList = new List<MortageInfo>();

            try
            { 
                foreach (var line in File.ReadAllLines(filename))
                {
                    string[] items = line.Split(';');

                    var mortgageInfo = new MortageInfo();

                    mortgageInfo.MortgageString = items[mortgageString];
                    mortgageInfo.Principal = double.Parse(items[principal]);
                    mortgageInfo.Interest = double.Parse(items[interest]);
                    mortgageInfo.NoOfYears = double.Parse(items[years]);
                    mortgageInfo.MonthlyPayment = double.Parse(items[monthlypayment]);

                    mortgageList.Add(mortgageInfo);
                }
            }
            catch (IOException ex)
            {
                Console.WriteLine(ex.Message);
            }

            return mortgageList;
        }

        public void AddMortgage(string data, double principal, double interest, double years, double monthlypayment)
        {
            string filename = GetServerMapPath();

            string message = $"{data};{principal};{interest};{years};{monthlypayment};";

            try
            { 
                File.AppendAllText(filename, message + "\n");
            }
            catch (IOException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public void ClearMortgages()
        {
            string filename = GetServerMapPath();

            try
            { 
                 File.WriteAllText(filename, String.Empty);
            }
            catch (IOException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public string GetServerMapPath()
        {

            string filepath = ConfigurationManager.AppSettings["PathToMortgageFile"];
            return HttpContext.Current.Server.MapPath(filepath);
        }

        public string GetConfigurationPath()
        {
            return ConfigurationManager.AppSettings["PathToMortgageFile"];
        }
    }
}