using Mortgage_Calculator.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Mortgage_Calculator
{
    public class DatabaseIOHelper : IIOHelper
    {
        private readonly string ConnectionString;

        public DatabaseIOHelper()
        {
            ConnectionString = ConfigurationManager.ConnectionStrings["NothwindConnectionString"].ConnectionString;
        }

        public void AddMortgage(string formattedMortgageString, double principal, double interest, double years, double monthlypayment)
        {
            try
            {
                using (SqlConnection sqlConnection = new SqlConnection(this.ConnectionString))
                {
                    string sqlInsertStatement = "INSERT INTO LoanDetails (Principal, InterestRate, DurationYears, MonthlyPayment, LoanDescription)" +
                         " values (@Principal, @InterestRate, @DurationYears, @MonthlyPayment, @LoanDescription)";

                    sqlConnection.Open();

                    using (SqlCommand sqlCommand = new SqlCommand(sqlInsertStatement, sqlConnection))
                    {
                        sqlCommand.Parameters.AddWithValue("@Principal", principal);
                        sqlCommand.Parameters.AddWithValue("@InterestRate", interest);
                        sqlCommand.Parameters.AddWithValue("@DurationYears", years);
                        sqlCommand.Parameters.AddWithValue("@MonthlyPayment", monthlypayment);
                        sqlCommand.Parameters.AddWithValue("@LoanDescription", formattedMortgageString);

                        int result = sqlCommand.ExecuteNonQuery();

                        if (result <= 0)
                        {
                            throw new Exception("Unable to add to database");
                        }
                    }
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void ClearMortgages()
        {
            try
            {
                using (SqlConnection sqlConnection = new SqlConnection(this.ConnectionString))
                {
                    string sqlDeleteStatement = "delete from loandetails";

                    sqlConnection.Open();

                    using (SqlCommand sqlCommand = new SqlCommand(sqlDeleteStatement, sqlConnection))
                    {
                        int result = sqlCommand.ExecuteNonQuery();

                        if (result <= 0)
                        {
                            throw new Exception("Unable to delete to database");
                        }
                    }
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<MortageInfo> GetAllMortgages()
        {
            var mortgageList = new List<MortageInfo>();

            try
            {
                using (SqlConnection sqlConnection = new SqlConnection(this.ConnectionString))
                {
                    string sqlDeleteStatement = "select * from loandetails";

                    sqlConnection.Open();

                    using (SqlCommand sqlCommand = new SqlCommand(sqlDeleteStatement, sqlConnection))
                    {
                        using (var dbReader = sqlCommand.ExecuteReader())
                        {
                            while (dbReader.Read())
                            {
                                var mortgageInfo = new MortageInfo()
                                {
                                    Principal = (double)dbReader["Principal"],
                                    InterestRate = (double)dbReader["InterestRate"],
                                    DurationYears = (double)dbReader["DurationYears"],
                                    MonthlyPayment = (double)dbReader["MonthlyPayment"],
                                    MortgageString = dbReader["LoanDescription"].ToString()
                                };

                                mortgageList.Add(mortgageInfo);
                            }
                        }
                    }
                }

                return mortgageList;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}