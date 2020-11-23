namespace MYOB.CodingTest.Tax
{
    public interface ITaxCalculator
    {
        decimal CalculateTax(decimal annualIncome);
    }
}