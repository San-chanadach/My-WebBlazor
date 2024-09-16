using RapidNRIMs.Model.Cores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RapidNRIMs.Model.Instruments
{
    public class InstrumentChecklistType : BaseModel
    {
        public int? InstrumentCheckListTypeID { get; set; }
        public string InstrumentCheckListTypeName { get; set; } = string.Empty;
        public string InstrumentCheckListTypeDescription { get; set; } = string.Empty;
        public int? SortByOrder { get; set; }
        public bool? IsActive { get; set; }

    }
}
