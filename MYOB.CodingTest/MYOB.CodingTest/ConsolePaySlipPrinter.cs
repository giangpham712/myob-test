using System;
using System.Collections.Generic;
using System.Text;

namespace MYOB.CodingTest
{
    public class ConsolePaySlipPrinter : IPaySlipPrinter
    {
        public void PrintPaySlip(PaySlip.PaySlip paySlip)
        {
            if (paySlip == null)
            {
                throw new ArgumentNullException(nameof(paySlip));
            }

            Console.WriteLine($"Monthly Payslip for: {paySlip.EmployeeName}" );
            Console.WriteLine($"Gross Monthly Income: ${paySlip.GrossMonthlyIncome:0.##}");
            Console.WriteLine($"Monthly Income Tax: ${paySlip.MonthlyIncomeTax:0.##}");
            Console.WriteLine($"Net Monthly Income: ${paySlip.NetMonthlyIncome:0.##}");
        }
    }
}
