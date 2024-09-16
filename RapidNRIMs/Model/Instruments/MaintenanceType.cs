using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using Newtonsoft.Json;

namespace RapidNRIMs.Model.Instruments
{
    public class MaintenanceType
    {
        public int MaintenanceTypeID {get; set;}
        public string MaintenanceDescription {get; set;} = "";
        public int SortByOrder {get; set;}
        public bool IsActive {get; set;}
    }
}