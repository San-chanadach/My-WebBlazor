using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using Newtonsoft.Json;

namespace RapidNRIMs.Model.Radiations
{
    public class RadiationSourceStatus
    {
        public int? RadiationSourceStatusID { get; set; }
        public string RadiationSourceStatusTHName { get; set; } = string.Empty;
        public string RadiationSourceStatusENName { get; set; } = string.Empty;
        public string ColorTag { get; set; } = string.Empty;
    }
}