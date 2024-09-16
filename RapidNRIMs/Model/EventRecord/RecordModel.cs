using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;

namespace RapidNRIMs.Model.EventRecord
{
    public class RecordModel
    {
        public int Id { get; set; }
        [Required, StringLength(20, ErrorMessage = "Please use only 20 Character.")]
        public string EventName { get; set; }
        [Required]
        public string EventNumber { get; set; } = "SSS";
        [Range(1,2)]
        public int EventType { get; set; }
        [Required]
        public DateTime StartDate { get; set; }
        [Required] 
        public DateTime EndDate { get; set; }
        [Required] 
        public string Object {get; set;}
        [Range(1,2)]
        public int Leader{ get; set; }
        [Range(1,2)]
        public int Team {get; set;}
        [Required]
        public string Instrument {get; set;}
        [Required]
        public string Inventory {get; set;}
        [Required]
        public string Detail {get; set;}
        [Required]
        public string Address {get; set;}
        [Required]
        public string City {get; set;}
        [Required]
        public string Province {get; set;}
        [Required]
        public string Country {get; set;}
        [Required]
        public string ZipCode {get; set;}
        [Required]
        public string Location{ get; set; }
        public string SubEventNumber {get; set;} = "Default Name";
        public int SpirId {get; set;} =  44;
        public int SpirPack {get; set;} = 45;
        public int Telepole {get; set;} = 45;
        public int AssingedTeam {get; set;} = 45;
        public string Picture {get; set;} = "Default Name";
        public DateTime Date {get; set;} = DateTime.Now;    
        public TimeSpan Time {get; set;} = new TimeSpan(10,2,30);
    
    }
}