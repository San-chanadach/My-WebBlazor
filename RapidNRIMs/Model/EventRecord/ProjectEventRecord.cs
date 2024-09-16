using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RapidNRIMs.Model.EventRecord
{
    public class ProjectEventRecord
    {
        public int ProjectEventID { get; set; }
        public int? ProjectID { get; set; }
        public int? EventID { get; set; }
        public string EventNumber { get; set; }
    }
}
