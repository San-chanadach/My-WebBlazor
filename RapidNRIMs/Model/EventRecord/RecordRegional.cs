using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using Newtonsoft.Json;

namespace RapidNRIMs.Model.EventRecord
{
    public class RecordRegional
    {
        public int? Regional_ID { get; set;}
        public int? RegionalNumber { get; set;} 
        public string RegionalTHName { get; set;} = string.Empty;
        public string RegionalENName { get; set;} = string.Empty;
        
        public List<RecordEventProvince> recordEventProvinces { get; set;}

        public void SetProvinces(List<RecordEventProvince> l) {
            recordEventProvinces = l.FindAll(i => i.ProvinceGeographyID == this.RegionalNumber);
        }
    }
}