using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RapidNRIMs.Model.EventRecord
{
    public class RecordSearchParameter
    {
        public string EventName { get; set; }
        public string EventNumber { get; set; }
        public string Location { get; set; }
        public int EventTypeID { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string UserID { get; set; }

    }
}
