using System;

namespace MYOB.CodingTest.Employee
{
    public class EmployeeParseException : Exception
    {
        private readonly string _input;

        public EmployeeParseException(string input, string message) : base(message)
        {
            _input = input;
        }
    }
}
