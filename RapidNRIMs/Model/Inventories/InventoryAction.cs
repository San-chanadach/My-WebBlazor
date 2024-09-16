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
    public class InventoryAction : BaseModel
    {
        public int InventoryActionID { get; set; }
        public string InventoryActionName { get; set; } = string.Empty;
        public string InventoryActionDescription { get; set; } = string.Empty;
        public int? SortByOrder { get; set; }
        public bool? IsActive { get; set; }
    }
}