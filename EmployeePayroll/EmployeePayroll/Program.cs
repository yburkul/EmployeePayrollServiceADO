using System;

namespace EmployeePayroll
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Welcome in Employee Payroll Service");
            EmployeeDetails employeeDetails = new EmployeeDetails();    
            int option = 0;
            do
            {
                Console.WriteLine("1: Establish Connection");
                Console.WriteLine("2: Close Connection");
                Console.WriteLine("0: Exit");
                option = int.Parse(Console.ReadLine());
                switch (option)
                {
                    case 1:
                        employeeDetails.EstablishConnection();
                        break;
                    case 2:
                        employeeDetails.CloseConnection();
                        break;                   
                    case 0:
                        Console.WriteLine("Exit");
                        break;
                    default:
                        Console.WriteLine("Invalid Option:---Please Enter Correct Option");
                        break;
                }
            }
            while (option != 0);
        }
    }
}