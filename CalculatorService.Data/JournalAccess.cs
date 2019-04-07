using CalculatorService.Common.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculatorService.Data
{
    public static class JournalAccess
    {

        public static void SetJournal(string sTrackingId, IOperation oOperacion, IOperationResult oResult)
        {
            using (JournalContext dbConText = new JournalContext())
            {
                Journal oJournal = new Journal()
                {
                    TrackingId = sTrackingId,
                    Calculation = string.Format("{0}{1}", oOperacion.GetCalculation(), oResult.GetResult()),
                    Operation = oOperacion.GetOperation(),
                    Date = DateTime.Now
                };

                dbConText.Journal.Add(oJournal);
                dbConText.SaveChanges();
            }
        }

        public static JournalQueryOperationList GetJournal(string sTrackingID)
        {
            List<Journal> lstJournals;
            JournalQueryOperationList queryResult;
            JournalQueryOperation operationAux;

            using (JournalContext dbConText = new JournalContext())
            {

                lstJournals = dbConText.Journal.Where(j => j.TrackingId.Equals(sTrackingID)).ToList();
                queryResult = new JournalQueryOperationList();
                queryResult.Operations = new List<JournalQueryOperation>();

                foreach (Journal journal in lstJournals)
                {
                    operationAux = new JournalQueryOperation()
                    {
                        Operation = journal.Operation,
                        Calculation = journal.Calculation,
                        Date = journal.Date.ToString()
                    };

                    queryResult.Operations.Add(operationAux);
                }
            }

            return queryResult;
        }

    }
}
