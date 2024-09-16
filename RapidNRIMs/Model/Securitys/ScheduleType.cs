using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using Newtonsoft.Json;

namespace RapidNRIMs.Model.Securitys
{
    public class ScheduleType
    {
        public int ScheduleTypeID { get; set; }
        public string ScheduleTypeName { get; set; }
        public string ScheduleTypeDescription { get; set; }
        public string ScheduleTypeColour { get; set; }
    }
}