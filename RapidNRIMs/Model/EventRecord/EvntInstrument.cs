using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RapidNRIMs.Model.EventRecord
{
    public class EvntInstrument
    {
        public int eventInstrumentID  {get;set; }
        public int? eventID {get;set; }

        public int? instrumentID { get; set; }

        public string instrumentNumber { get; set; } = string.Empty;
    }
    public class EventResultImage
    {
        public int EventResultImageID { get; set; }
        public int EventResultID { get; set; }
        public string EventResultImageFile { get; set; }
        public bool IsSelected { get; set; } = false;
    }
}

