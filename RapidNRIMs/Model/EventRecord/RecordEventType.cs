using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using Newtonsoft.Json;
using RapidNRIMs.Model.Cores;

namespace RapidNRIMs.Model.EventRecord
{
    public class RecordEventType : BaseModel
    {
        public int EventTypeID {get; set;}
        public string EventTypeTHName { get; set; } = string.Empty;
        public string EventTypeENName {get; set;} = string.Empty;
        public int? SortByOrder { get; set; }
        public bool? IsActive {get; set;}
    }
}