using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using Newtonsoft.Json;
using RapidNRIMs.Model.Cores;

namespace RapidNRIMs.Model.Inventories
{
    public class InventoryLocation : BaseModel
    {
        public int InventoryLocationID {get; set;}
       // [Required(ErrorMessage = "The InventoryLocationName field is required")]
        public string InventoryLocationName { get; set; } = string.Empty;
       // [Required(ErrorMessage = "TheLocationDescription field is required")]
        public string InventoryLocationDescription { get; set; } = string.Empty;
        public int? SortByOrder { get; set; }
        public bool? IsActive { get; set; }
    }
}