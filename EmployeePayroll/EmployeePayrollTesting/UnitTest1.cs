using EmployeePayroll;
using NUnit.Framework;
using System;

namespace EmployeePayrollTesting
{
    public class Tests
    {
        EmployeeDetails employeeDetails;
        Employee employee;
        [SetUp]
        public void Setup()
        {
            employeeDetails = new EmployeeDetails();
            employee = new Employee();
        }
        /// <summary>
        /// TC 1 - Add Employee Payroll Data Add in to a DataBase
        /// </summary>
        [Test]
        public void Given_EmployeePayrollData_Add_InToDataBase()
        {
            bool expected = true;
            employee.Name = "Karan";
            employee.StartDate = Convert.ToDateTime("2022-06-10");
            employee.Gender = "M";
            employee.PhoneNumber = 7073330033;
            employee.Address = "Mumbai";
            employee.Department = "IT";
            employee.BasicPay = 50000;
            employee.Deduction = 1000;
            employee.TaxablePay = 1000;
            employee.IncomeTax = 1000;
            employee.NetPay = 47000;
            bool result = employeeDetails.InsertEmployeeData(employee);
            Assert.AreEqual(expected, result);
        }
        /// <summary>
        /// TC 2 - Update the Salary of Emplyoee
        /// </summary>
        [Test]
        public void UpdateEmployeeSalary_ShouldReturn_True_AfterUpdate()
        {
            bool expected = true;
            employee.ID = 29;
            employee.Name = "Terisa";
            employee.BasicPay = 3000000;
            bool result = employeeDetails.UpdateEmployeeSalary(employee);
            Assert.AreEqual(expected, result);
        }
        /// <summary>
        /// TC 3 - Remove The Employee Data 
        /// </summary>
        [Test]
        public void Given_ID_ToRemoveEmployeeData()
        {
            bool expected = true;
            employee.ID = 26;
            bool result = employeeDetails.RemoveEmployeeData(employee);
            Assert.AreEqual(expected,result);   
        }
    }
}