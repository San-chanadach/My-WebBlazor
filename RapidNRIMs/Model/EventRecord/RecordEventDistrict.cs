using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using Newtonsoft.Json;
using RapidNRIMs.Model.Cores;

namespace RapidNRIMs.Model.EventRecord
{
    public class RecordEventDistrict : BaseModel
    {
        public int? DistrictID { get; set; }
        public string DistrictCode { get; set; } = string.Empty;
        public string DistrictTHName { get; set; } = string.Empty;
        public string DistrictENName { get; set; } = string.Empty;
        public int? DistrictProvinceID { get; set; }
        public bool? IsActive { get; set; }

       public List<SubDistrict> SubDistricts { get; set; }

        public void SetSubDistricts(List<SubDistrict> l) {
            SubDistricts = l.FindAll(i => i.subDistrictDistrictID == this.DistrictID);
        }



       
    }
       
}