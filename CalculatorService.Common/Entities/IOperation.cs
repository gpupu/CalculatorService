using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CalculatorService.Common.Entities
{
    public interface IOperation
    {
        string GetOperation();

        string GetCalculation();
    }

    public interface IOperationResult
    {
        string GetResult();
    }
}