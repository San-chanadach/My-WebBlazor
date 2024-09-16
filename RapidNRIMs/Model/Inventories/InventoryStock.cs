using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using Newtonsoft.Json;

namespace RapidNRIMs.Model.Inventories
{
    public class InventoryStock
    {
        public int InventoryStockID { get; set; }
        public string InventoryNumber { get; set; } = string.Empty;
        public string InventoryStockNumber { get; set; } = string.Empty;
        public Nullable<int> InventoryStockLocationID { get; set; }
        public Nullable<int> InventoryStockStockTypeID { get; set; }
        public Nullable<DateTime> InventoryStockPurchaseDate { get; set; }
        public Nullable<int> InventoryStockQuantity { get; set; }

        public Nullable<Decimal> InventoryStockPrice { get; set; }
        public Nullable<DateTime> InventoryStockExpireDate { get; set; }
        public Nullable<Guid> InventoryStockDiscardBy { get; set; } = new Guid("00000000-0000-0000-0000-000000000000");
        public Nullable<DateTime> InventoryStockDiscardDate { get; set; }

        public string InventoryStockReason { get; set; } = string.Empty;
        public Nullable<bool> IsActive { get; set; }
        public Nullable<int> FirstStockQuantity { get; set; }

        public string InventoryStockFile { get; set; } = string.Empty;
        public string InventoryStockPictureDefault { get; set; } = string.Empty;
        public string InventoryStockPictureLeft { get; set; } = string.Empty;
        public string InventoryStockPictureRight { get; set; } = string.Empty;

        [JsonIgnore]
        public Inventory inventory = new Inventory();
        public InventoryLocation StockLocation = new InventoryLocation();
        public InventoryStockType StockType = new InventoryStockType();

        public void GetLookUp( List<Inventory> inventories, List<InventoryLocation> locations ,List<InventoryStockType> stockTypes) 
        {
            this.inventory = inventories.Find(i => i.InventoryNumber == this.InventoryNumber);
            this.StockLocation = locations.Find(i => i.InventoryLocationID == this.InventoryStockLocationID);
            this.StockType = stockTypes.Find(i => i.InventoryStockTypeID == this.InventoryStockStockTypeID);
        }

        public void GetLookUp(List<Inventory> inventories)
        {
            this.inventory = inventories.Find(i => i.InventoryNumber == this.InventoryNumber);
        }

    }
}