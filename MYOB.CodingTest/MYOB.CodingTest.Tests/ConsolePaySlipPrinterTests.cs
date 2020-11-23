using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using NUnit.Framework;

namespace MYOB.CodingTest.Tests
{
    public class ConsolePaySlipPrinterTests
    {
        [Test]
        public void PrintPaySlip_NullPaySlip_ThrowsException()
        {
            var paySlipConsolePrinter = new ConsolePaySlipPrinter();
            Assert.Throws<ArgumentNullException>(() => paySlipConsolePrinter.PrintPaySlip(null));
        }

        [Test]
        public void PrintPaySlip_ValidPaySlip_PrintsOutput()
        {
            using (var sw = new StringWriter())
            {
                var paySlipConsolePrinter = new ConsolePaySlipPrinter();
                Console.SetOut(sw);
                paySlipConsolePrinter.PrintPaySlip(new PaySlip.PaySlip()
                {
                    EmployeeName = "Bruce Wayne",
                    GrossMonthlyIncome = 20000,
                    MonthlyIncomeTax = 8000,
                });

                var result = sw.ToString().Trim();
                Assert.AreEqual("Monthly Payslip for: Bruce Wayne\r\nGross Monthly Income: $20000\r\nMonthly Income Tax: $8000\r\nNet Monthly Income: $12000", result);
            }
        }
    }
}
