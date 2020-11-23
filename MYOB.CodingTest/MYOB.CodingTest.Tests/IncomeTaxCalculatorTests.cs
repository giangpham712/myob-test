using System;
using System.Collections.Generic;
using System.Text;
using Moq;
using MYOB.CodingTest.Tax;
using NUnit.Framework;
using NUnit.Framework.Interfaces;

namespace MYOB.CodingTest.Tests
{
    public class IncomeTaxCalculatorTests
    {
        [Test]
        public void CalculateTax_NullTaxBrackets_ThrowsException()
        {
            Assert.Throws<ArgumentNullException>(() => new IncomeTaxCalculator(null));
        }

        [Test]
        public void CalculateTax_NoTaxBrackets_ReturnsZero()
        {
            var incomeTaxCalculator = new IncomeTaxCalculator();
            var incomeTax = incomeTaxCalculator.CalculateTax(100000);

            Assert.AreEqual(0, incomeTax);
        }

        static IEnumerable<TestCaseData> TaxBracketsSets
        {
            get
            {
                yield return new TestCaseData(new List<IncomeTaxBracket>
                {
                    new IncomeTaxBracket(0, 0, 20000),
                    new IncomeTaxBracket(0.1M, 20001, 40000),
                    new IncomeTaxBracket(0.2M, 40001, 80000),
                    new IncomeTaxBracket(0.3M, 80001, 180000),
                    new IncomeTaxBracket(0.4M, 180001, int.MaxValue),
                }, 20000, 0M);

                yield return new TestCaseData(new List<IncomeTaxBracket>
                {
                    new IncomeTaxBracket(0, 0, 20000),
                    new IncomeTaxBracket(0.1M, 20001, 40000),
                    new IncomeTaxBracket(0.2M, 40001, 80000),
                    new IncomeTaxBracket(0.3M, 80001, 180000),
                    new IncomeTaxBracket(0.4M, 180001, int.MaxValue),
                }, 60000, 6000M);

                yield return new TestCaseData(new List<IncomeTaxBracket>
                {
                    new IncomeTaxBracket(0, 0, 30000),
                    new IncomeTaxBracket(0.1M, 30001, 45000),
                    new IncomeTaxBracket(0.2M, 45001, 75000),
                    new IncomeTaxBracket(0.3M, 75001, 160000),
                    new IncomeTaxBracket(0.4M, 160001, int.MaxValue),
                }, 110000, 18000M);
            }
        }

        [TestCaseSource(nameof(TaxBracketsSets))]
        public void CalculateTax_MultipleTaxBrackets_ReturnIncomeTax(List<IncomeTaxBracket> taxBrackets, int annualIncome, decimal expectedIncomeTax)
        {
            var incomeTaxCalculator = new IncomeTaxCalculator(taxBrackets);
            var incomeTax = incomeTaxCalculator.CalculateTax(annualIncome);
            Assert.AreEqual(expectedIncomeTax, incomeTax);
        }
    }
}
