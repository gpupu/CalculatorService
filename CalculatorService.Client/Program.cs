using NClap.Metadata;
using NClap.Repl;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static CalculatorService.Client.Operations;

namespace CalculatorService.Client
{
    class Program
    {
        static void Main(string[] args)
        {
            // The code provided will print ‘Hello World’ to the console.
            // Press Ctrl+F5 (or go to Debug > Start Without Debugging) to run your app.
            //Console.WriteLine("Hello World!");

            //string sResult = Operations.Add(new Common.Entities.AddModel() { Addens = new int[]{2,4,5 } });
            //Console.WriteLine(sResult);

            //Console.ReadKey();

            // Go to http://aka.ms/dotnet-get-started-console to continue learning how to build a console app! 

            RunInteractiveShell();
        }


        private static void RunInteractiveShell()
        {
            Console.WriteLine("Entering loop...");
            PrintMenu();

            var loop = new Loop(typeof(CalcCommandsType));
            loop.Execute();

            Console.WriteLine("Exited loop...");
        }

        private static void PrintMenu()
        {

            // TODO

            foreach (var item in Enum.GetValues(typeof(CalcCommandsType)))
            {
                var type = typeof(CalcCommandsType);
                var memInfo = type.GetMember(item.ToString());
                var attributes = memInfo[0].GetCustomAttributes(typeof(DescriptionAttribute), false);
                var description = ((DescriptionAttribute)attributes[0]).Description;
                Console.WriteLine(string.Format("{0}.- {1} {2}",(int)item, item, description));
            }
        }
    }
}
