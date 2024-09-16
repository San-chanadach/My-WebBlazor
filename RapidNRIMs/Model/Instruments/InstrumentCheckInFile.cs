using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using Newtonsoft.Json;

namespace RapidNRIMs.Model.Instruments
{
    public class InstrumentCheckInFile
    {
        public int CheckInFileID {get; set;}
        [Required(ErrorMessage = "The CheckInFilePath field is required")]
        public string CheckInFilePath {get; set;} = "";
        [Required(ErrorMessage = "The CheckInDate field is required")]
        public DateTime CheckInFileCreateDate {get; set;} = DateTime.Now;
        [Required(ErrorMessage = "The CheckInDescription field is required")]
        public string CheckInFileDescription {get; set;} = "";
        public bool SortByOrder {get; set;}
    }
}