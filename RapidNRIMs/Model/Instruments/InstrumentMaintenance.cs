using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using Newtonsoft.Json;

namespace RapidNRIMs.Model.Instruments
{
    public class InstrumentMaintenance
    {
   
        public int InstrumentMaintenanceID { get; set; }
        public Nullable<int> InstrumentID { get; set; }
        public DateTime? InstrumentMaintenanceDate { get; set; }
        public DateTime? InstrumentMaintenanceNext { get; set; }
        public string InstrumentMaintenanceFileName { get; set; } = string.Empty;
        public string InstrumentMaintenanceFile { get; set; } = string.Empty;
        public Nullable<bool> InstrumentMaintenanceStatus { get; set; }
        public Nullable<int> SortByOrder { get; set; }
        public Nullable<bool> IsActive { get; set; }
        public string MaintenanceDetail { get; set; } = string.Empty;
        public string Note { get; set; } = string.Empty;

        [JsonIgnore]
        public Instrument instrument { get; set; }


        public void GetLookup(List<Instrument> s)
        {
            this.instrument = s.Find(i => i.InstrumentID == this.InstrumentID);
        }
    }
}