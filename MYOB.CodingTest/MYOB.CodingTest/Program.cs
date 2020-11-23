using System;
using System.Collections.Generic;
using MYOB.CodingTest.Employee;
using MYOB.CodingTest.Tax;

namespace MYOB.CodingTest
{
    public class Program
    {
        public static void Main(string[] args)
        {
            if (args.Length != 2)
                throw new ArgumentException("Invalid number of arguments");

            var name = args[0];
            var annualSalary = decimal.Parse(args[1]);

            var employee = new Employee.Employee(name, annualSalary);

            var taxBrackets = new List<IncomeTaxBracket>()
            {
                new IncomeTaxBracket(0, 0, 20000),
                new IncomeTaxBracket(0.1M, 20001, 40000),
                new IncomeTaxBracket(0.2M, 40001, 80000),
                new IncomeTaxBracket(0.3M, 80001, 180000),
                new IncomeTaxBracket(0.4M, 180001, decimal.MaxValue),
            };
            var taxCalculator = new IncomeTaxCalculator(taxBrackets);
            var paySlipPrinter = new ConsolePaySlipPrinter();
            
            var paySlipGenerator = new PaySlipGenerator(paySlipPrinter, taxCalculator);
            paySlipGenerator.GeneratePaySlip(employee);
        }
    }
}
