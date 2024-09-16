using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RapidNRIMs.Model.EventRecord
{
   public  class SubDistrict
    {
        public int? subDistrictID { get; set; }
        public string subDistrictCode { get; set; } = string.Empty;
        public string subDistrictTHName { get; set; } = string.Empty;
        public string subDistrictENName { get; set; } = string.Empty;
        public int? subDistrictDistrictID { get; set; } 
        
    }
}
