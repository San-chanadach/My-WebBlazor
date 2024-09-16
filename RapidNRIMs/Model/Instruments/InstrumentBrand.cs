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
    public class InstrumentBrand : BaseModel
    {
        public int? InstrumentBrandID { get; set; }
        //[Required(ErrorMessage = "The NameBrand field is required")]
        public string InstrumentBrandName { get; set; } = string.Empty;
        public string InstrumentBrandDescription { get; set; } = string.Empty;
        public int? SortByOrder { get; set; }
        public bool? IsActive { get; set; }
        
        public List<InstrumentModel> model { get; set; }

        public void Getlookup(List<InstrumentModel> models)
        {
            this.model = models.FindAll(i => i.InstrumentBrandID == this.InstrumentBrandID);
        }

    }
}