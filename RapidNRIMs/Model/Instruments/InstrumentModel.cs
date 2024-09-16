using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using Newtonsoft.Json;
using RapidNRIMs.Model.Cores;

namespace RapidNRIMs.Model.Instruments
{
    public class InstrumentModel : BaseModel
    {
        public int InstrumentModelID {get; set;}
        public string InstrumentModelName {get; set;}
        public Nullable<int> InstrumentBrandID { get; set; } 
        public string InstrumentModelDescription {get; set;} 
        public Nullable<int> SortByOrder { get; set; }
        public Nullable<bool> IsActive { get; set; }

        [JsonIgnore]
        public InstrumentBrand Brand { get; set; }

        public void Getlookup(List<InstrumentBrand> listBrand)
        {
            this.Brand = listBrand.Find(i => i.InstrumentBrandID == this.InstrumentBrandID);
        }
    }
}