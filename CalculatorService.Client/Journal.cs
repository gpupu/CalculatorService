using CalculatorService.Common.Entities;
using NClap.Metadata;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Configuration;

namespace CalculatorService.Client
{
    public static class Journal
    {
        public static string Query(JournalQuery oQuery)
        {
            var client = new RestClient(string.Concat(ConfigurationManager.AppSettings["ServiceURL"], "/journal/query"));
            var request = new RestRequest(Method.POST);
            request.AddHeader("cache-control", "no-cache");
            request.AddHeader("Content-Type", "application/json");
            request.AddParameter("undefined", JsonConvert.SerializeObject(oQuery), ParameterType.RequestBody);

            IRestResponse response = client.Execute(request);

            return response.Content;
        }
    }

    public class JournalCommand: Command
    {
        [PositionalArgument(ArgumentFlags.Required, Position = 0, Description = "Tracking Id")]
        public string QueryId { get; set; }

        public override Task<CommandResult> ExecuteAsync(CancellationToken cancel)
        {
            string sResult;
            try
            {
                Console.WriteLine("Retrieving Info...");

                JournalQuery oQuery = new JournalQuery() { Id = QueryId };
                sResult = Journal.Query(oQuery);

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
