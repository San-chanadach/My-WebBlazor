using RapidNRIMs.Model.Cores;
using RapidNRIMs.Model.Instruments;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace RapidNRIMs.Model.Instruments
{
    public class ModelInstrumentChecklistNumber
    {
        public int InstrumentChecklistNumberID { get; set; }
        public string InstrumentChecklistNumber { get; set; }
        public string InstrumentNumber { get; set; }   
        public Nullable<bool> IsActive { get; set; }
        public int CheckLitTypeID { get; set; }


        
    }
}
