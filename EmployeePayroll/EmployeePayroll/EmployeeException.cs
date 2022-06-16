﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeePayroll
{
    public class EmployeeException : Exception
    {
        ExceptionType exceptionType;
        public enum ExceptionType
        {
            Connection_Failed, Details_Not_In_Correct_Format, Salary_Not_Update
        }
        public EmployeeException(ExceptionType exceptionType, string message) : base(message)
        {
            this.exceptionType = exceptionType;
        }
    }
}