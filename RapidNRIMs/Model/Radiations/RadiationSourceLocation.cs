using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using Newtonsoft.Json;
using RapidNRIMs.Model.Cores;

namespace RapidNRIMs.Model.Radiations
{
    public class RadiationSourceLocation : BaseModel
    {
        public int RadiationSourceLocationID { get; set; }
        public string RadiationSourceLocationTHName { get; set; } = string.Empty;
        public string RadiationSourceLocationENName { get; set; } = string.Empty;
        public int? SortByOrder { get; set; }
        public bool? IsActive { get; set; }
    }
}