using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using Newtonsoft.Json;

namespace RapidNRIMs.Model.Instruments
{
    public class Maintenance
    {
        public int MaintenanceID {get; set;}
        public int MaintenanceNumber {get; set;}
        public int MaintenanceTypeID {get; set;}
        public DateTime MaintenanceDate {get; set;} = DateTime.Now;
        public string MaintenanceDescription {get; set;} = "";
        public int MaintenanceFileID {get; set;}
        public int SortByOrder {get; set;}
        public bool IsActive {get; set;}
    }
}