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
    public class InventoryStockCheckOut
    {
        public int InventoryStockCheckOutID { get; set; }
        public string InventoryStockNumber { get; set; } = string.Empty;
        public Nullable<int> InventoryStockCheckOutQuantity { get; set; }
        public Nullable<int> InventoryStockCheckOutAction { get; set; }
        public Nullable<Guid> InventoryStockCheckOutGiveTo { get; set; }
        public Nullable<DateTime> InventoryStockCheckOutDate { get; set; } = DateTime.Now;
        public string InventoryStockCheckOutComment { get; set; } = string.Empty;
        public Nullable<bool> IsActive { get; set; }
        public Guid? ByUserID { get; set; }

        [JsonIgnore]
        public InventoryStock inventoryStock { get; set; }

        [JsonIgnore]
        public InventoryStockCheckOutItem InventoryStockCheckOutItem { get; set; }

        public void GetLookUp(List<InventoryStock> listInventoryStock)
        {
            this.inventoryStock = listInventoryStock.Find(i => i.InventoryStockNumber == this.InventoryStockNumber);
        }

        public void GetLookUpTo(List<InventoryStockCheckOutItem> inventoryStockCheckOutItems)
        {
            this.InventoryStockCheckOutItem = inventoryStockCheckOutItems.Find(i => i.InventoryStockCheckOutID == this.InventoryStockCheckOutID);
        }
    }
}