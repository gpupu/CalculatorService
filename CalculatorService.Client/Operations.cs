using CalculatorService.Common.Entities;
using NClap.Metadata;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculatorService.Client
{
    public static class Operations
    {


        public static string Add(AddModel oAdd, string sTrackingId)
        {
            var client = new RestClient("http://localhost:50236/calculator/add");
            var request = new RestRequest(Method.POST);
            setTracking(sTrackingId, request);
            request.AddHeader("cache-control", "no-cache");
            request.AddHeader("Content-Type", "application/json");
            request.AddParameter("undefined", JsonConvert.SerializeObject(oAdd), ParameterType.RequestBody);

            IRestResponse response = client.Execute(request);

            return response.Content;
        }

        public static string Sub(SubModel oSub)
        {
            var client = new RestClient("http://localhost:50236/calculator/sub");
            var request = new RestRequest(Method.POST);
            //request.AddHeader("Postman-Token", "68a46cf7-f6d6-4013-96f8-31c842ab264e");
            request.AddHeader("cache-control", "no-cache");
            request.AddHeader("Content-Type", "application/json");
            request.AddParameter("undefined", JsonConvert.SerializeObject(oSub), ParameterType.RequestBody);
            IRestResponse response = client.Execute(request);

            return response.Content;
        }

        public static string Mult(MultModel oMult)
        {
            var client = new RestClient("http://localhost:50236/calculator/mult");
            var request = new RestRequest(Method.POST);
            //request.AddHeader("Postman-Token", "8fefdbd3-9cd6-4453-8a66-6664bedc1175");
            request.AddHeader("cache-control", "no-cache");
            request.AddHeader("Content-Type", "application/json");
            request.AddParameter("undefined", JsonConvert.SerializeObject(oMult), ParameterType.RequestBody);
            //request.AddJsonBody(oAdd);

            IRestResponse response = client.Execute(request);

            return response.Content;
        }

        public static string Div(DivModel oDiv)
        {
            var client = new RestClient("http://localhost:50236/calculator/div");
            var request = new RestRequest(Method.POST);
            //request.AddHeader("Postman-Token", "68a46cf7-f6d6-4013-96f8-31c842ab264e");
            request.AddHeader("cache-control", "no-cache");
            request.AddHeader("Content-Type", "application/json");
            request.AddParameter("undefined", JsonConvert.SerializeObject(oDiv), ParameterType.RequestBody);
            IRestResponse response = client.Execute(request);

            return response.Content;
        }

        public static string SQRT(SQRTModel oSQRT)
        {
            var client = new RestClient("http://localhost:50236/calculator/sqrt");
            var request = new RestRequest(Method.POST);
            //request.AddHeader("Postman-Token", "68a46cf7-f6d6-4013-96f8-31c842ab264e");
            request.AddHeader("cache-control", "no-cache");
            request.AddHeader("Content-Type", "application/json");
            request.AddParameter("undefined", JsonConvert.SerializeObject(oSQRT), ParameterType.RequestBody);
            IRestResponse response = client.Execute(request);

            return response.Content;
        }

        private static void setTracking(string sTrackingID, RestRequest request)
        {
            if(!string.IsNullOrEmpty(sTrackingID))
            {
                request.AddHeader("X-Evi-Tracking-Id", sTrackingID);
            }
        }
    }
}
