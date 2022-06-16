using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeePayroll
{
    public class EmployeeDetails
    {
        static string connectionString = @"Data Source=DESKTOP-DNLCRQ5\SQLEXPRESS;Initial Catalog=EmployeePayrollService;Integrated Security=True;";
        static SqlConnection sqlconnection = new SqlConnection(connectionString);
        public void EstablishConnection()
        {
            if (sqlconnection != null && sqlconnection.State.Equals(ConnectionState.Closed))
            {
                try
                {
                    sqlconnection.Open();
                    Console.WriteLine("Connection is ON");
                }
                catch (Exception)
                {
                    throw new EmployeeException(EmployeeException.ExceptionType.Connection_Failed, "connection failed");

                }
            }
        }
        public void CloseConnection()
        {
            if (sqlconnection != null && sqlconnection.State.Equals(ConnectionState.Open))
            {
                try
                {
                    sqlconnection.Close();
                    Console.WriteLine("Connection is OFF");
                }
                catch (Exception)
                {
                    throw new EmployeeException(EmployeeException.ExceptionType.Connection_Failed, "connection failed");
                }
            }
        } 
    }
}