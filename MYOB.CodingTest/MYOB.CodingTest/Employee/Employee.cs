namespace MYOB.CodingTest.Employee
{
    public class Employee
    {
        public string Name { get; }
        public decimal AnnualSalary { get; }

        public Employee(string name, decimal annualSalary)
        {
            Name = name;
            AnnualSalary = annualSalary;
        }
    }
}
