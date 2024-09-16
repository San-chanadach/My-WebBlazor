using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using Newtonsoft.Json;

namespace RapidNRIMs.Model.Instruments
{
    public class InstrumentAllocated
    {
        public int ID {get; set;}
        public string Format {get; set;} = "";
        public int Year {get; set;}
        public int NumberAllocated {get; set;}
        public string IsActive {get; set;}
    }
}