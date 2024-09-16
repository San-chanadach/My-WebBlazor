using RapidNRIMs.Model.Cores;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace RapidNRIMs.Model.Instruments
{
    public class InstrumentChecklistResult : BaseModel
    {
        public int InstrumentChecklistResultID { get; set; }
        public int? InstrumentCheckllistID { get; set; }
        public int? InstrumentChecklistNumberID { get; set; }
        public bool? InstrumentChecklistResultChecked { get; set; }

        public string InstrumentChecklistImageData { get; set; } = string.Empty;

        public string InstrumentChecklistImage { get; set; } = string.Empty;

        public string InstrumentChecklistComment { get; set; } = string.Empty;

        [JsonIgnore]

        public InstrumentChecklist checklist { get; set; }
        [JsonIgnore]
        public bool? FailChecked { get; set; } 

    }
    public class InstrumentChecklistNumber {
         public int InstrumentChecklistNumberID { get; set; }
    }
}
