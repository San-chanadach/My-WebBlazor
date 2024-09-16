using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using Newtonsoft.Json;
using RapidNRIMs.Model.Cores;
using RapidNRIMs.Model.Instruments;

namespace RapidNRIMs.Model.Instruments
{
    public class InstrumentCalibration : BaseModel
    {
        public int InstrumentCalibrationID { get; set; }
        public int? InstrumentID { get; set; }
        public DateTime? InstrumentCalibrationDate { get; set; }
        public DateTime? InstrumentCalibrationNext { get; set; }
        public string InstrumentCalibrationFileName { get; set; } = string.Empty;
        public string InstrumentCalibrationFile { get; set; } = string.Empty;
      
        public Nullable<bool> InstrumentCalibrationStatus { get; set; }
        public Nullable<int> SortByOrder { get; set; }
        public Nullable<bool> IsActive { get; set; }
        public string Note { get; set; } = string.Empty;

        [JsonIgnore]
        public Instrument instrument { get; set; }



        public void GetLookup(List<Instrument> s)
        {
            this.instrument = s.Find(i => i.InstrumentID == this.InstrumentID);
        }
    }
}