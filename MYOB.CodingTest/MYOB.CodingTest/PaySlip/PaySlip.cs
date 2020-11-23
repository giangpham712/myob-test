using System;
using System.Collections.Generic;
using System.Text;

namespace MYOB.CodingTest.PaySlip
{
    public class PaySlip
    {
        public string EmployeeName { get; set; }
        public decimal GrossMonthlyIncome { get; set; }
        public decimal MonthlyIncomeTax { get; set; }

        public decimal NetMonthlyIncome => GrossMonthlyIncome - MonthlyIncomeTax;
    }
}
