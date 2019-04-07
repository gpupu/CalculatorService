
using CalculatorService.Common.Entities;
using CalculatorService.Data;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;

namespace CalculatorService.Common
{
    public static class CommonUtils
    {

        public static string checkTrackingID(HttpRequestMessage request)
        {
            IEnumerable<string> headerValues;
            string trackingID = string.Empty;

            if (request.Headers.TryGetValues("X-Evi-Tracking-Id", out headerValues))
            {
                trackingID = headerValues.FirstOrDefault();
            }

            return trackingID;
        }

        public static void saveToJournal(string sTrackingId, IOperation oOperacion, IOperationResult oResult)
        {
            JournalAccess.SetJournal(sTrackingId, oOperacion, oResult);
        }

    }
}