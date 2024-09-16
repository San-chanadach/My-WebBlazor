using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using Newtonsoft.Json;

namespace RapidNRIMs.Model.Instruments
{
    public class MaintenanceFile
    {
        public int MaintenanceFileID {get; set;}
        public string MaintenanceFileSerial {get; set;} = "";
        public string MaintenanceFilePath {get; set;} = "";
        public DateTime MaintenanceFileCreateDate {get; set;} = DateTime.Now;
        public string MaintenanceFileDescription {get; set;} = "";
        public int SortByOrder {get; set;}
    }
}