using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculatorService.Common.Entities
{
    public class JournalQuery
    {
        public string Id { get; set; }
    }

    public class JournalQueryOperation
    {
        public string Operation { get; set; }
        public string Calculation { get; set; }
        public string Date { get; set; }
    }

    public class JournalQueryOperationList
    {
        public List<JournalQueryOperation> Operations { get; set; }
    }

}
