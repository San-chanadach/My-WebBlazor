using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RapidNRIMs.Model.Reports
{
    public class ReportModel
    {
        public string EventNumber { get; set; }

        public string InstrumentNumber { get; set; }

        public string InventoryNumber { get; set; }

        public DateTime Date { get; set; }

        public DateTime To { get; set; }

        public string SubEvent { get; set; }

        public Dictionary<string, string> parameter { get; set; } = new Dictionary<string, string>();
        public string Reportpath { get; set; } = "";

        public string ReportName { get; set; }
    }
}
