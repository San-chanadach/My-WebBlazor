using RapidNRIMs.Model.Cores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RapidNRIMs.Model.Radiations
{
    public class RadiationSourceAgency : BaseModel
    {
        public int RadiationSourceAgencyID { get; set; }
        public string RadiationSourceAgencyName { get; set; } = string.Empty;
        public string RadiationSourceAgencyAddress { get; set; } = string.Empty;
        public string RadiationSourceAgencyTel { get; set; } = string.Empty;
        public string RadiationSourceAgencyEmail { get; set; } = string.Empty;
        public string RadiationSourceAgencyDescription { get; set; } = string.Empty;
        public int? SortByOrder { get; set; }
        public bool? IsActive { get; set; }
    }
}
