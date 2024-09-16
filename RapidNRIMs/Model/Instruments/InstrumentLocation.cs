using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using Newtonsoft.Json;
using RapidNRIMs.Model.Cores;

namespace RapidNRIMs.Model.Instruments
{
    public class InstrumentLocation : BaseModel
    {
        public int InstrumentLocationID {get; set;}
        //[Required(ErrorMessage = "The LocationName field is required")]
        public string InstrumentLocationName {get; set;}
        //[Required(ErrorMessage = "The LocationName field is required")]
        public string InstrumentLocationNameENG { get; set; } 
        //[Required(ErrorMessage = "The LocationDescription field is required")]
        public string InstrumentLocationDescription {get; set;}
        public Nullable<int> SortByOrder {get; set;}
        public Nullable<bool> IsActive {get; set;}
        
    }
}