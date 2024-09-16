using RapidNRIMs.Model.Cores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace RapidNRIMs.Model.Radiations
{
    public class RadiationDoseUnit : BaseModel
    {
        public int RadiationDoseUnitID { get; set; }
        public string RadiationDoseUnitName { get; set; } = string.Empty;
        public string RadiationDoseUnitSymbol { get; set; } = string.Empty;
        public int? SortByOrder { get; set; }
        public bool? IsActive { get; set; }
    }
}
