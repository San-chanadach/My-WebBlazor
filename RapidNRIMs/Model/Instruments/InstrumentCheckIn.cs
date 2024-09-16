using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using Newtonsoft.Json;

namespace RapidNRIMs.Model.Instruments
{
    public class InstrumentCheckIn
    {
        public int InstrumentCheckInID { get; set; }
        public string InstrumentNumber { get; set; } = string.Empty;  
        public Nullable<int> InstrumentCheckOutID { get; set; }
        public Nullable<int> InstrumentCheckInLocation { get; set; }
        public Nullable<DateTime> InstrumentCheckInReturnDate { get; set; }
        public Nullable<Guid> InstrumentCheckInGiveTo { get; set; }
        public string InstrumentCheckInImageData { get; set; } = string.Empty;
        public string InstrumentCheckInFile { get; set; } = string.Empty;
        public string InstrumentCheckInNote { get; set; } = string.Empty;
        public bool IsStaff { get; set; }
        public Guid? ByUserID { get; set; }

        [JsonIgnore]
        public Instrument instrument { get; set; }

        public void GetLookUp(List<Instrument> listInstrument)
        {
            this.instrument = listInstrument.Find(i => i.InstrumentNumber == this.InstrumentNumber);
        }
    }
}