using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CalculatorService.Common.Entities
{
    public class SubModel : IOperation
    {
        public int Minuend { get; set; }
        public int Subtrahend { get; set; }

        public SubModel() { }

        public SubModel(int Minuend, int Subtrahend)
        {
            this.Minuend = Minuend;
            this.Subtrahend = Subtrahend;
        }

        public string GetCalculation()
        {
            string sCalc = string.Empty;
            sCalc = string.Format("{0} - {1} =", Minuend, (Subtrahend * (-1)).ToString());

            return sCalc;
        }

        public string GetOperation()
        {
            return "Sub";
        }
    }

    public class SubResultModel : IOperationResult
    {
        public int Difference { get; set; }

        public string GetResult()
        {
            return Difference.ToString();
        }
    }
}