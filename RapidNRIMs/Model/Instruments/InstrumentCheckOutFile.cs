using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using Newtonsoft.Json;

namespace RapidNRIMs.Model.Instruments
{
    public class InstrumentCheckOutFile
    {
        public int CheckOutFileID {get; set;}
        [Required(ErrorMessage = "The CheckOutFilePath field is required")]
        public string CheckOutFilePath {get; set;} = "";
        [Required(ErrorMessage = "The CheckOutDate field is required")]
        public DateTime CheckOutFileCreateDate {get; set;} = DateTime.Now;
        [Required(ErrorMessage = "The CheckOutDescription field is required")]
        public string CheckOutFileDescription {get; set;} = "";
        public bool SortByOrder {get; set;}
    }
}