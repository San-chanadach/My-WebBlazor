using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RapidNRIMs.Model.Inventories
{
    public class MinStock
    {
        public int InventoryID { get; set; }
        public string InventoryNumber { get; set; }
        public string THName { get; set; }
        public int minStock { get; set; }
        public bool IsNotif { get; set; }
        public int total_count { get; set; }
        public int? Quantity { get; set; }

        [JsonIgnore]
        public Inventory Inventory { get; set; }
    }
}
