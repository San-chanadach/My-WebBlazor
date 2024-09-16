using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using Newtonsoft.Json;

namespace RapidNRIMs.Model.Instruments
{
    public class InstrumentFile
    {
        public int InstrumentFileID {get; set;}
        [Required(ErrorMessage = "The FilePath field is required")]
        public string InstrumentFilePath {get; set;} = "";
        [Required(ErrorMessage = "The FileDescription field is required")]
        public string InstrumentFileDescription {get; set;} = "";
        public int SortByOrder {get; set;}
    }
}