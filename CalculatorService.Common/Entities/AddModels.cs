using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CalculatorService.Common.Entities
{
    public class AddModel: IOperation
    {
        public int[] Addens { get; set; }

        public string GetCalculation()
        {
            string sCalc = string.Empty;

            foreach(int sum in Addens)
            {
                sCalc += string.Format("{0} + ", sum);
            }

            sCalc = sCalc.Substring(0, sCalc.Length - 2);
            sCalc += "= ";

            return sCalc;

        }

        public string GetOperation()
        {
            return "Sum";
        }
    }

    public class AddResultModel : IOperationResult
    {
        public int Sum { get; set; }

        public string GetResult()
        {
            return Sum.ToString();
        }
    }
}