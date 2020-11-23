using System;
using System.Collections.Generic;

namespace MYOB.CodingTest.Tax
{
    public class IncomeTaxCalculator : ITaxCalculator
    {
        private readonly List<IncomeTaxBracket> _taxBrackets;

        public IncomeTaxCalculator()
        {
            _taxBrackets = new List<IncomeTaxBracket>();
        }

        public IncomeTaxCalculator(List<IncomeTaxBracket> taxBrackets)
        {
            if (taxBrackets == null)
            {
                throw new ArgumentNullException(nameof(taxBrackets));
            }

            _taxBrackets = taxBrackets;
        }

        public decimal CalculateTax(decimal annualIncome)
        {
            var incomeTax = 0.0M;
            foreach (var bracket in _taxBrackets)
            {
                incomeTax += bracket.CalculateTax(annualIncome);
            }

            return incomeTax;
        }
    }
}
