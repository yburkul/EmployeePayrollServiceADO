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
        public bool InsertEmployeeData(Employee employee)
        {
            try
            {
                using (sqlconnection)
                {
                    SqlCommand sqlCommand = new SqlCommand("InsertEmployeeDetails", sqlconnection);
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.AddWithValue("@ID", employee.ID);
                    sqlCommand.Parameters.AddWithValue("@Name", employee.Name);
                    sqlCommand.Parameters.AddWithValue("@Gender", employee.Gender);
                    sqlCommand.Parameters.AddWithValue("@PhoneNumber", employee.PhoneNumber);
                    sqlCommand.Parameters.AddWithValue("@Address", employee.Address);
                    sqlCommand.Parameters.AddWithValue("@StartDate", employee.StartDate);
                    sqlCommand.Parameters.AddWithValue("@Department", employee.Department);
                    sqlCommand.Parameters.AddWithValue("@BasicPay", employee.BasicPay);
                    sqlCommand.Parameters.AddWithValue("@Deduction", employee.Deduction);
                    sqlCommand.Parameters.AddWithValue("@TaxablePay", employee.TaxablePay);
                    sqlCommand.Parameters.AddWithValue("@IncomeTax", employee.IncomeTax);
                    sqlCommand.Parameters.AddWithValue("@NetPay", employee.NetPay);
                    var returnParameter = sqlCommand.Parameters.Add("@new_identity", SqlDbType.Int);
                    returnParameter.Direction = ParameterDirection.ReturnValue;
                    Console.WriteLine(employee.ID + "," + employee.Name + "," + employee.Gender + "," + employee.PhoneNumber + "," + employee.Address + ","
                            + employee.StartDate + "," + employee.Department + "," + employee.BasicPay + "," + employee.Deduction + "," + employee.TaxablePay + "," + employee.IncomeTax + "," + employee.NetPay);
                    sqlconnection.Open();

                    var result = sqlCommand.ExecuteNonQuery();
                    sqlconnection.Close();
                    if (result != 0)
                    {
                        return true;
                    }
                    return false;
                    sqlconnection.Close();
                }
                sqlconnection.Close();
            }
            catch (EmployeeException)
            {
                throw new EmployeeException(EmployeeException.ExceptionType.Details_Not_In_Correct_Format, "Details is not in correct format");
            }
        }
        public bool UpdateEmployeeSalary(Employee employee)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    SqlCommand command = new SqlCommand("UpdateEmployeeDetails", connection);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@ID", employee.ID);
                    command.Parameters.AddWithValue("@Name", employee.Name);
                    command.Parameters.AddWithValue("@BasicPay", employee.BasicPay);
                    connection.Open();
                    var result = command.ExecuteNonQuery();
                    connection.Close();
                    if (result != 0)
                    {
                        return true;
                    }
                    return false;
                }
            }
            catch (EmployeeException)
            {
                throw new EmployeeException(EmployeeException.ExceptionType.Salary_Not_Update, "Emplyoee Salary Not Updated");
            }
        }
    }
}