using System;
using System.Collections.Generic;
using System.Text;
using Moq;
using MYOB.CodingTest.Employee;
using MYOB.CodingTest.Tax;
using NUnit.Framework;

namespace MYOB.CodingTest.Tests
{
    public class PaySlipGeneratorTests
    {
        [Test]
        public void GeneratePaySlip_ValidInput_PrintsPaySlip()
        {
            var taxCalculator = new Mock<ITaxCalculator>();
            taxCalculator.Setup(c => c.CalculateTax(120000))
                .Returns(35000);

            var paySlipPrinter = new Mock<IPaySlipPrinter>();

            var employee = new Employee.Employee("Giang Pham", 120000);
            var paySlipGenerator = new PaySlipGenerator(paySlipPrinter.Object, taxCalculator.Object);
            paySlipGenerator.GeneratePaySlip(employee);

            taxCalculator.Verify(x => x.CalculateTax(120000));

            var expectedGrossMonthlyIncome = (decimal)120000 / 12;
            var expectedMonthlyIncomeTax = (decimal)35000 / 12;
            var expectedNetMonthlyIncome = expectedGrossMonthlyIncome - expectedMonthlyIncomeTax;
            paySlipPrinter.Verify(x => x.PrintPaySlip(It.Is<PaySlip.PaySlip>(p => p.EmployeeName == "Giang Pham" && 
                                                                                  p.GrossMonthlyIncome == expectedGrossMonthlyIncome &&
                                                                                  p.MonthlyIncomeTax == expectedMonthlyIncomeTax &&
                                                                                  p.NetMonthlyIncome == expectedNetMonthlyIncome)));
        }
    }
}
