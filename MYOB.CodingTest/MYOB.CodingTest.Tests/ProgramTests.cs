using System;
using System.IO;
using NUnit.Framework;

namespace MYOB.CodingTest.Tests
{
    public class ProgramTests
    {
        [Test]
        public void Main_InputWithMissingAnnualSalary_ThrowsException()
        {
            Assert.Throws<ArgumentException>(() => Program.Main(new string[] { "Giang Pham" }));
        }

        [Test]
        public void Main_InputWithInvalidAnnualSalary_ThrowsException()
        {
            Assert.Throws<FormatException>(() => Program.Main(new string[] { "Giang Pham", "123ABC" }));
        }

        [Test]
        public void Main_ValidInput_PrintsPaySlipOutput()
        {
            using (var sw = new StringWriter())
            {
                Console.SetOut(sw);
                Program.Main(new [] { "Giang Pham", "60000" });

                var result = sw.ToString().Trim();
                Assert.AreEqual(
                    "Monthly Payslip for: Giang Pham\r\nGross Monthly Income: $5000\r\nMonthly Income Tax: $500\r\nNet Monthly Income: $4500",
                    result);
            }
        }
    }
}
