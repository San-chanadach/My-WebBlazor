using Newtonsoft.Json;
using RapidNRIMs.Model.Cores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RapidNRIMs.Model.Inventories
{
    public class InventoryStockCheckInItem
    {
        public int InventoryStockCheckInItemID { get; set; }
        public int InventoryStockCheckInID { get; set; }
        public string InventoryStockNumber { get; set; } = string.Empty;
        public int? InventoryStockQuantity { get; set; }
   

        [JsonIgnore]
        public InventoryStock InventoryStock { get; set; } = new InventoryStock();
       
    }
}
