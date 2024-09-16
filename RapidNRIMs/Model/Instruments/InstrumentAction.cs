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
    public class InstrumentAction : BaseModel
    {
        public int InstrumentActionID { get; set; }
        public string InstrumentActionName { get; set; } = string.Empty;
        public string InstrumentActionDescription { get; set; } = string.Empty;
        public int? SortByOrder { get; set; }
        public bool? IsActive { get; set; }

        [JsonIgnore]
        public bool IsCheckSelect { get; set; }

    }
}