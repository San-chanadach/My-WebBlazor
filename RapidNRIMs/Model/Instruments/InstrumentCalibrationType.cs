using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using Newtonsoft.Json;

namespace RapidNRIMs.Model.Instruments
{
    public class InstrumentCalibrationType
    {
        public int CalibrationTypeID {get; set;}
        [Required(ErrorMessage = "The TypeDescription field is required")]
        public string CalibrationTypeDescription {get; set;} = "";
        public int SortByOrder {get; set;}
        public bool IsActive {get; set;}
    }
}