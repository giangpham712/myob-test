using System;

namespace MYOB.CodingTest.Tax
{
    public class IncomeTaxBracket
    {
        private readonly decimal _rate;
        private readonly decimal _lower;
        private readonly decimal _upper;

        public IncomeTaxBracket(decimal rate, decimal lower, decimal upper)
        {
            if (upper <= lower)
            {
                throw new ArgumentException("Tax bracket upper must be larger than lower");
            }

            _rate = rate;
            _lower = lower;
            _upper = upper;
        }

        public decimal CalculateTax(decimal annualIncome)
        {
            if (annualIncome < _lower)
                return 0;

            var taxableIncome = Math.Min(_upper, annualIncome) - (_lower - 1);
            return taxableIncome * _rate;
        }
    }
}
