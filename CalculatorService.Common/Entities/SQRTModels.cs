using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculatorService.Common.Entities
{
    public class SQRTModel : IOperation
    {
        public int Number { get; set; }

        public string GetCalculation()
        {
            string sCalc = string.Empty;
            sCalc = string.Format("sqrt({0}) =", Number);

            return sCalc;
        }

        public string GetOperation()
        {
            return "sqrt";
        }
    }

    public class SQRTResultModel : IOperationResult
    {
        public int Square { get; set; }

        public string GetResult()
        {
            return Square.ToString();
        }
    }
}
