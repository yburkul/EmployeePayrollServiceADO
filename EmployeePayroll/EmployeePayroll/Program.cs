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
                Console.WriteLine("3: Add Employee Data");
                Console.WriteLine("4: Update the Employee Salary");
                Console.WriteLine("5: Remove the Employee Data");
                Console.WriteLine("6: Get Emplyee Data In Date Range");
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
                    case 3:
                        Employee emp = new Employee();
                        Console.WriteLine("Enter The Name");
                        string name = Console.ReadLine();
                        emp.Name = name;
                        Console.WriteLine("Enter a Gender");
                        string gender = Console.ReadLine();
                        emp.Gender = gender;
                        Console.WriteLine("Enter Phone number");
                        double Phone = Convert.ToInt64(Console.ReadLine());
                        emp.PhoneNumber = Phone;
                        Console.WriteLine("Enter a Address");
                        string address = Console.ReadLine();
                        emp.Address = address;
                        Console.WriteLine(" Emplyoee Join Date");
                        string date = Console.ReadLine();
                        emp.StartDate = Convert.ToDateTime(date);
                        Console.WriteLine("Enter a Department");
                        string department = Console.ReadLine();
                        emp.Department = department;
                        Console.WriteLine("Enter a Basic Pay");
                        double basicpay = Convert.ToInt64(Console.ReadLine());
                        emp.BasicPay = basicpay;
                        Console.WriteLine("Enter a Deduction");
                        int Deduction = int.Parse(Console.ReadLine());
                        emp.Deduction = Deduction;
                        Console.WriteLine("Enter a Taxable Pay");
                        int taxablepay = int.Parse(Console.ReadLine());
                        emp.TaxablePay = taxablepay;
                        Console.WriteLine("Enter a Income Tax");
                        int incometax = int.Parse(Console.ReadLine());
                        emp.IncomeTax = incometax;
                        Console.WriteLine("Enter a NetPay");
                        int netpay = int.Parse(Console.ReadLine());
                        emp.NetPay = netpay;
                        employeeDetails.InsertEmployeeData(emp);
                        break;
                    case 4:
                        Employee employee = new Employee();
                        Console.WriteLine("Enter Id");
                        int id = int.Parse(Console.ReadLine());
                        employee.ID = id;
                        Console.WriteLine("Enter Name");
                        string Name = Console.ReadLine();
                        employee.Name = Name;
                        Console.WriteLine("Enter a Basic Pay");
                        double basic = Convert.ToInt64(Console.ReadLine());
                        employee.BasicPay = basic;
                        employeeDetails.UpdateEmployeeSalary(employee);
                        break;
                    case 5:
                        Employee delete = new Employee();
                        Console.WriteLine("Enter a ID For Delete The Contact");
                        int EmpId = int.Parse(Console.ReadLine());
                        delete.ID = EmpId;
                        employeeDetails.RemoveEmployeeData(delete);
                        break;
                    case 6:
                        var fromDate = Convert.ToDateTime("2022-01-01");
                        var ToDate = Convert.ToDateTime("2022-04-01");
                        employeeDetails.GetEmplyeeDataInDateRange(fromDate, ToDate);
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