using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using Newtonsoft.Json;

namespace RapidNRIMs.Model.Instruments
{
    public class InstrumentMeasurement
    {
        public int InstrumentMeasurementID {get; set;}
        [Range(1,2000, ErrorMessage = "The InstrumentID field is required")]
        public int InstrumentID {get; set;}
        [Required(ErrorMessage = "The Date field is required")]
        public DateTime InstrumentMeasurementDATE {get; set;} = DateTime.Now;
        [Range(1,2000, ErrorMessage = "The Unit field is required")]
        public int InstrumentUnitID {get; set;}
        [Range(1,2000, ErrorMessage = "The InstrumentValues field is required")]
        public decimal InstrumentValues {get; set;}
        [Range(1,2000, ErrorMessage = "The Device field is required")]
        public int InstrumentDeviceID {get; set;}
        [Required(ErrorMessage = "The DeviceIP field is required")]
        public string InstrumentDeviceIP {get; set;} = "";

    }
}