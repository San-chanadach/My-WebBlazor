using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using Newtonsoft.Json;

namespace RapidNRIMs.Model.Instruments
{
    public class InstrumentCalibrationFile
    {
        public int CalibrationFileID {get; set;}
        [Required(ErrorMessage = "The FileSerial field is required")]
        public string CalibrationFileSerial {get; set;} = "";
        [Required(ErrorMessage = "The FIlePath field is required")]
        public string CalibrationFIlePath {get; set;} = "";
        [Required(ErrorMessage = "The FileCreateDate field is required")]
        public DateTime CalibrationFileCreateDate {get; set;} = DateTime.Now;
        [Required(ErrorMessage = "The FileDescription field is required")]
        public string CalibrationFileDescription {get; set;} = "";
        public int SortByOrder {get; set;}
    }
}