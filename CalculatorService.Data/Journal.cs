using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Data.Linq.Mapping;
using System.Data.SQLite;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculatorService.Data
{
    [Table(Name = "Journal")]
    public class Journal
    {
        [Column(Name = "ID", IsDbGenerated = true, IsPrimaryKey = true, DbType = "INTEGER")]
        [Key]
        public int ID { get; set; }

        [Column(Name = "TrackingId", DbType = "VARCHAR")]
        public string TrackingId { get; set; }

        [Column(Name = "Operation", DbType = "VARCHAR")]
        public string Operation { get; set; }

        [Column(Name = "Calculation", DbType = "VARCHAR")]
        public string Calculation { get; set; }

        [Column(Name = "Date", DbType = "TEXT")]
        public DateTime Date { get; set; }
    }
}
