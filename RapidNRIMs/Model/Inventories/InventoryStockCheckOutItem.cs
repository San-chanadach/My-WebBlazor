using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using Newtonsoft.Json;

namespace RapidNRIMs.Model.Inventories
{
    public class InventoryStockCheckOutItem
    {
        public int InventoryStockCheckOutItemID { get; set; }
        public int InventoryStockCheckOutID { get; set; }
        public string InventoryStockNumber { get; set; }
        public int InventoryStockID { get; set; }
        public Nullable<int> InventoryStockQuantity { get; set; } = 0;

        [JsonIgnore]
        public InventoryStock InventoryStock { get; set; } = new InventoryStock();

        [JsonIgnore]
        public InventoryStockCheckOut inventoryStockCheckOut { get; set; }

        public void GetLookup(List<InventoryStockCheckOut> stockCheckOuts)
        {
            this.inventoryStockCheckOut = stockCheckOuts.Find(i => i.InventoryStockCheckOutID == this.InventoryStockCheckOutID);
        }

    }
}