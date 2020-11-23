using System;
using System.Collections.Generic;
using System.Text;
using MYOB.CodingTest.Employee;
using MYOB.CodingTest.PaySlip;
using MYOB.CodingTest.Tax;

namespace MYOB.CodingTest
{
    public class PaySlipGenerator
    {
        private readonly IPaySlipPrinter _paySlipPrinter;
        private readonly ITaxCalculator _taxCalculator;

        public PaySlipGenerator(IPaySlipPrinter paySlipPrinter, ITaxCalculator taxCalculator)
        {
            _paySlipPrinter = paySlipPrinter;
            _taxCalculator = taxCalculator;
        }

        public void GeneratePaySlip(Employee.Employee employee)
        {
            var annualIncomeTax = _taxCalculator.CalculateTax(employee.AnnualSalary);

            var paySlip = new PaySlip.PaySlip()
            {
                EmployeeName = employee.Name,
                GrossMonthlyIncome = employee.AnnualSalary / 12,
                MonthlyIncomeTax = annualIncomeTax / 12
            };

            _paySlipPrinter.PrintPaySlip(paySlip);
        }
    }
}
