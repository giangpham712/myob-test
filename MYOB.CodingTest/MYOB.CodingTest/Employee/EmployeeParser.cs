using System.Text.RegularExpressions;

namespace MYOB.CodingTest.Employee
{
    public class EmployeeParser : IEmployeeParser
    {
        private static string _pattern = "^(\"[\\w\\s]+\"|[\\w]+)[ ]*([1-9][0-9]+)$";

        public Employee ParseEmployee(string input)
        {
            if (string.IsNullOrWhiteSpace(input))
                throw new EmployeeParseException(input, "Invalid employee input");

            var regexMatch = Regex.Match(input, _pattern);
            if (!regexMatch.Success)
            {
                throw new EmployeeParseException(input, "Invalid employee input");
            }

            var name = regexMatch.Groups[1].Value.Trim(new [] { '"' });
            var annualSalary = int.Parse(regexMatch.Groups[2].Value);

            return new Employee(name, annualSalary);
        }
    }
}
