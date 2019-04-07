using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculatorService.Common.Entities
{
    public class DivModel : IOperation
    {
        public int Dividend { get; set; }
        public int Divisor { get; set; }

        public string GetCalculation()
        {
            string sCalc = string.Empty;
            sCalc = string.Format("{0} / {1} =", Dividend, Divisor);

            return sCalc;
        }

        public string GetOperation()
        {
            return "Div";
        }
    }

    public class DivResultModel : IOperationResult
    {
        public int Quotinent { get; set; }
        public int Remainder { get; set; }

        public string GetResult()
        {
            return Quotinent.ToString();
        }
    }
}
