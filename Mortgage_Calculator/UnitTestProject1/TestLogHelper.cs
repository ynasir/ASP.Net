using Mortgage_Calculator;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTestProject1
{
    public class TestLogHelper : IIOHelper
    {
        public void AddMortgage(string formattedMortgageString, double principal, double interest, double years, double monthlypayment)
        {
            string filename = GetFilePath();

            string message = $"{formattedMortgageString};{principal};{interest};{years};{monthlypayment};";

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
            string filename = GetFilePath();

            try
            { 
                File.WriteAllText(filename, String.Empty);
            }
            catch (IOException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public List<MortageInfo> GetAllMortgages()
        {
            string filename = GetFilePath();


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

        public string GetFilePath()
        {
            string str_directory = Environment.CurrentDirectory.ToString();
            string parent = System.IO.Directory.GetParent(str_directory).Parent.Parent.FullName;

            string filepath = Path.Combine(parent, @"Mortgage_Calculator\App_Data\MortgageData.txt");

            return filepath;
        }
    }
}
