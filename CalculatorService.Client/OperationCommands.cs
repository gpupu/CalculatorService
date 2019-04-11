using CalculatorService.Common.Entities;
using NClap.Metadata;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CalculatorService.Client
{

    public enum CalcCommandsType
    {
        [Command(typeof(AddCommand), LongName = "Add", Description = "Add")]
        Add = 1,

        [Command(typeof(SubCommand), LongName = "Sub", Description = "Sub")]
        Sub = 2,

        [Command(typeof(ExitCommand), LongName = "Exit", Description = "Exits Calculator CLI")]
        Exit= 9
    }

    public class AddCommand : Command
    {
        [PositionalArgument(ArgumentFlags.Required, Position = 0, Description = "Set of values to Add separated by comma ','")]
        public string Addins { get; set; }

        public override Task<CommandResult> ExecuteAsync(CancellationToken cancel)
        {
            string sResult;
            try
            {
                Console.WriteLine("Calculating...");

                AddModel oAdd = new AddModel(Addins);
                sResult = Operations.Add(oAdd);

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
}
