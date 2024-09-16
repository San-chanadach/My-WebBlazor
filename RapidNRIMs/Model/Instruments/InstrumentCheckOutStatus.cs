using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using Newtonsoft.Json;

namespace RapidNRIMs.Model.Instruments
{
    public class InstrumentCheckOutStatus
    {
        public int CheckOutStatusID {get; set;}
        [Required(ErrorMessage = "The CheckOutStatusName field is required")]
        public string CheckOutStatusName {get; set;} = "";
        [Required(ErrorMessage = "The CheckOutStatusDetail field is required")]
        public string CheckOutStatusDetail {get; set;} = "";
        public bool IsActive {get; set;}
    }
}