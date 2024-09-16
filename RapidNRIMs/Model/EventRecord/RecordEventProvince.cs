using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using Newtonsoft.Json;

namespace RapidNRIMs.Model.EventRecord
{
    public class RecordEventProvince
    {
        public int? ProvinceID {get; set;}
        public string ProvinceCode {get; set;} = string.Empty;
        public string ProvinceTHName {get; set;} = string.Empty;
        public string ProvinceENName {get; set;} = string.Empty;
        public int? ProvinceGeographyID {get; set;}
        public bool? IsActive {get; set;}

        public List<RecordEventDistrict> Districts { get; set;}

        public void SetDistricts(List<RecordEventDistrict> l) {
            Districts = l.FindAll(i => i.DistrictProvinceID == this.ProvinceID);
        }
    }
}