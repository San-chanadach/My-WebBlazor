using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RapidNRIMs.Model.Reports
{
    class ReportP
    {

        public Dictionary<string, string> parameter { get; set; } = new Dictionary<string, string>();
        public string Reportpath { get; set; } = "";

        public string ReportName { get; set; }
    }
}
