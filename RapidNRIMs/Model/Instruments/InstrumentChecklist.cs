using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RapidNRIMs.Model.Instruments
{
    public class InstrumentChecklist
    {
        public int InstrumentChecklistID { get; set; }
        public Nullable<int> InstrumentModelID { get; set; }
        public string InstrumentChecklistName { get; set; } = string.Empty;
        public string InstrumentChecklistDescription { get; set; } = string.Empty;
        public Nullable<int> InstrumentChecklistType { get; set; }
        public Nullable<int> InstrumentChecklistSortByOrder { get; set; }
        public Nullable<bool> IsActive { get; set; }

        [JsonIgnore]
        public InstrumentModel Model { get; set; }
      
        public void GetLookup (List<InstrumentModel> models)
        {
            this.Model = models.Find(m => m.InstrumentModelID == this.InstrumentModelID);   
        }
    }
}
