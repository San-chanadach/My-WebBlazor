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
    public class RadiationSourceCheckOutAction : BaseModel
    {
        public int RadiationSourceCheckOutActionID { get; set; }
        public string RadiationSourceCheckOutActionTHName { get; set; } = string.Empty;
        public string RadiationSourceCheckOutActionENName { get; set; } = string.Empty;
        public int? SortByOrder { get; set; }
        public bool? IsActive { get; set; }
    }
}