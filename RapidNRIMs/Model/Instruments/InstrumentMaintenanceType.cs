using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using Newtonsoft.Json;

namespace RapidNRIMs.Model.Instruments
{
    public class InstrumentMaintenanceType
    {
        public int maintenanceTypeID {get; set;}
        public string maintenanceDescription {get; set;}
        public int sortByOrder {get; set;}
        public bool isActive {get; set;}
    }
}