using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using Newtonsoft.Json;
using RapidNRIMs.Model.Cores;

namespace RapidNRIMs.Model.Instruments
{
    public class InstrumentAgency : BaseModel
    {
        public int? InstrumentAgencyID {get; set;}
        public string InstrumentAgencyName { get; set; } = string.Empty;
        public string InstrumentAgencyAddress {get; set;} = string.Empty;
        public string InstrumentAgencyTel {get; set;} = string.Empty;
        public string InstrumentAgencyEmail {get; set;} = string.Empty;
        public string InstrumentAgencyDescription {get; set;} = string.Empty;
        public int? SortByOrder { get; set; }
        public bool? IsActive { get; set; }

        [JsonIgnore]
        public bool IsCheckSelect { get; set; }


    }
}