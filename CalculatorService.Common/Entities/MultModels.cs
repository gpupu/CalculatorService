using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculatorService.Common.Entities
{
    public class MultModel : IOperation
    {
        public int[] Factors { get; set; }

        public MultModel() { }

        public MultModel(int[] mult)
        {
            //string[] aAddens = addens.Split(',');

            //Addens = aAddens.Select(a => Convert.ToInt32(a)).ToArray();
            this.Factors = mult;
        }

        public string GetCalculation()
        {
            string sCalc = string.Empty;

            foreach (int sum in Factors)
            {
                sCalc += string.Format("{0} * ", sum);
            }

            sCalc = sCalc.Substring(0, sCalc.Length - 2);
            sCalc += "= ";

            return sCalc;
        }

        public string GetOperation()
        {
            return "Mult";
        }
    }


    public class MultResultModel : IOperationResult
    {
        public int Product { get; set; }

        public string GetResult()
        {
            return Product.ToString();
        }
    }
}
