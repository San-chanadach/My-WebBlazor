using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using Newtonsoft.Json;

namespace RapidNRIMs.Model.Instruments
{
    public class InstrumentDiscard
    {
        public int discardID {get; set;}
        public int instrumentID {get; set;}
        public string discardByIser {get; set;}
        public string discardDate {get; set;}
        [Required(ErrorMessage = "The Reason field is required")]
        public string description {get; set;}
    }
}