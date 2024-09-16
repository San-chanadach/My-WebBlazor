using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using Newtonsoft.Json;

namespace RapidNRIMs.Model.Instruments
{
    public class InstrumentCheckOut
    {
        public int InstrumentCheckOutID { get; set; }
        public string InstrumentNumber { get; set; } = string.Empty;
        public Nullable<int> InstrumentCheckOutAction { get; set; } = 0;
        public Nullable<Guid> InstrumentCheckOutGiveTo { get; set; }
        public Nullable<DateTime> InstrumentCheckOutReturnDate { get; set; }
        public Nullable<DateTime> InstrumentCheckOutDate { get; set; }

        public string InstrumentCheckOutNote { get; set; } = string.Empty;
        public string InstrumentCheckOutImagedata { get; set; } = string.Empty;
        public string InstrumentCheckOutFile { get; set; } = string.Empty;
        public Nullable<int> InstrumentCheckOutStatus { get; set; }
        public string InstrumentCheckOutComment { get; set; } = string.Empty;
        public bool IsStaff { get; set; }
        public Guid? ByUserID { get; set; }

        public int Month { get; set; }
        public int Year { get; set; }

        [JsonIgnore]
        public Instrument instrument { get; set; }
        

        public void GetLookUp(List<Instrument> listInstrument)
        {
            this.instrument = listInstrument.Find(i => i.InstrumentNumber == this.InstrumentNumber);
        }

        
    }
}