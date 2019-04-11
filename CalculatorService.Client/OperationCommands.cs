using CalculatorService.Common.Entities;
using NClap.Metadata;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CalculatorService.Client
{

    public enum CalcCommandsType
    {
        [Command(typeof(AddCommand), LongName = "Add", Description = "Add Operation")]
        [Description("Expects a list of values separated by comma as argument")]
        Add = 1,

        [Command(typeof(SubCommand), LongName = "Sub", Description = "Sub Operation")]
        [Description("Expects minuend value and substrahend (both positive values)")]
        Sub = 2,

        [Command(typeof(MulCommand), LongName = "Mul", Description = "Mul Operation")]
        [Description("Expects a list of values separated by comma as argument")]
        Mul = 3,

        [Command(typeof(DivCommand), LongName = "Div", Description = "Div Operation")]
        [Description("Expects dividend and divisor values")]
        Div = 4,

        [Command(typeof(SQRTCommand), LongName = "Sqrt", Description = "Sqrt Operation")]
        [Description("Expects a value to calculate its square root")]
        Sqrt = 5,

        [Command(typeof(ExitCommand), LongName = "Exit", Description = "Exits Calculator CLI")]
        [Description("Exit this application")]
        Exit
    }

    public class AddCommand : Command
    {
        [PositionalArgument(ArgumentFlags.Required, Position = 0, Description = "Set of values to Add separated by comma ','")]
        public int[] Addins { get; set; }

        [PositionalArgument(ArgumentFlags.Optional, Position = 1, Description = "Tracking ID")]
        public string TrackingID { get; set; }


        public override Task<CommandResult> ExecuteAsync(CancellationToken cancel)
        {
            string sResult;
            try
            {
                Console.WriteLine("Calculating...");

                AddModel oAdd = new AddModel(Addins);
                sResult = Operations.Add(oAdd, TrackingID);

                Console.WriteLine(sResult);

                return Task.FromResult(CommandResult.Success);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Something wrong happend, please check arguments are valid");
                return Task.FromResult(CommandResult.UsageError);
            }
        }
    }

    public class SubCommand : Command
    {
        [PositionalArgument(ArgumentFlags.Required, Position = 0, Description = "Minuend")]
        public int iMinuend { get; set; }

        [PositionalArgument(ArgumentFlags.Required, Position = 1, Description = "Subtrahend")]
        public int iSubtrahend { get; set; }

        public override Task<CommandResult> ExecuteAsync(CancellationToken cancel)
        {
            string sResult;
            try
            {
                Console.WriteLine("Calculating...");

                SubModel oSubModel = new SubModel(iMinuend, -1*iSubtrahend);
                sResult = Operations.Sub(oSubModel);

                Console.WriteLine(sResult);

                return Task.FromResult(CommandResult.Success);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Something wrong happend, please check arguments are valid");
                return Task.FromResult(CommandResult.UsageError);
            }
        }
    }

    public class MulCommand : Command
    {
        [PositionalArgument(ArgumentFlags.Required, Position = 0, Description = "Set of values to Multiply separated by comma ','")]
        public int[] Factors { get; set; }

        public override Task<CommandResult> ExecuteAsync(CancellationToken cancel)
        {
            string sResult;
            try
            {
                Console.WriteLine("Calculating...");

                MultModel oMult = new MultModel(Factors);
                sResult = Operations.Mult(oMult);

                Console.WriteLine(sResult);

                return Task.FromResult(CommandResult.Success);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Something wrong happend, please check arguments are valid");
                return Task.FromResult(CommandResult.UsageError);
            }
        }
    }

    public class DivCommand : Command
    {
        [PositionalArgument(ArgumentFlags.Required, Position = 0, Description = "Dividend")]
        public int iDividend { get; set; }

        [PositionalArgument(ArgumentFlags.Required, Position = 1, Description = "Divisor")]
        public int iDivisor { get; set; }

        public override Task<CommandResult> ExecuteAsync(CancellationToken cancel)
        {
            string sResult;
            try
            {
                Console.WriteLine("Calculating...");

                DivModel oDivModel = new DivModel(iDividend, iDivisor);
                sResult = Operations.Div(oDivModel);

                Console.WriteLine(sResult);

                return Task.FromResult(CommandResult.Success);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Something wrong happend, please check arguments are valid");
                return Task.FromResult(CommandResult.UsageError);
            }
        }
    }

    public class SQRTCommand : Command
    {
        [PositionalArgument(ArgumentFlags.Required, Position = 0, Description = "Number to be calculated its SQRT")]
        public int Number { get; set; }

        public override Task<CommandResult> ExecuteAsync(CancellationToken cancel)
        {
            string sResult;
            try
            {
                Console.WriteLine("Calculating...");

                SQRTModel oSquare = new SQRTModel(Number);
                sResult = Operations.SQRT(oSquare);

                Console.WriteLine(sResult);

                return Task.FromResult(CommandResult.Success);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Something wrong happend, please check arguments are valid");
                return Task.FromResult(CommandResult.UsageError);
            }
        }
    }

}
