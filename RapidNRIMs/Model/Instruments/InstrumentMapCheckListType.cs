using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RapidNRIMs.Model.Instruments
{
    public class InstrumentMapCheckListType
    {
        public int InstrumentMapCheckListTypeID { get; set; }
        public int? InstrumentID { get; set; }
        public int? InstrumentCheckListTypeID { get; set; }
        public bool IsCheck { get; set; } = false;
        [JsonIgnore]
        public InstrumentChecklistType checkListType { get; set; }
    }
}
