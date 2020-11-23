using System;
using MYOB.CodingTest.Tax;
using NUnit.Framework;

namespace MYOB.CodingTest.Tests
{
    public class IncomeTaxBracketTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void IncomeTaxBracket_UpperLessThanLower_ThrowsException()
        {
            Assert.Throws<ArgumentException>(() => new IncomeTaxBracket(0.15M, 50000, 40000));
        }

        [Test]
        public void CalculateTax_IncomeLessThanLower_ReturnsZero()
        {
            var bracket = new IncomeTaxBracket(0.3M, 80001, 180000);
            var annualIncome = 70000;
            var expectedTax = 0;
            Assert.AreEqual(expectedTax, bracket.CalculateTax(annualIncome));
        }

        [Test]
        public void CalculateTax_IncomeGreaterThanLowerLessThanUpper_ReturnsTax()
        {
            var bracket = new IncomeTaxBracket(0.2M, 40001, upper:80000);
            var annualIncome = 60000;
            var expectedTax = 4000;
            Assert.AreEqual(expectedTax, bracket.CalculateTax(annualIncome));
        }

        [TestCase(0.3, 80001, 180000, 100000, 6000)]
        [TestCase(0.19, 40001, 80000, 40001, 0.19)]
        public void CalculateTax_IncomeGreaterThanUpper_ReturnsTax(decimal bracketRate, int bracketLower, int bracketUpper, decimal annualIncome, decimal expectedTax)
        {
            var bracket = new IncomeTaxBracket(bracketRate, bracketLower, upper: bracketUpper);
            Assert.AreEqual(expectedTax, bracket.CalculateTax(annualIncome));
        }
    }
}