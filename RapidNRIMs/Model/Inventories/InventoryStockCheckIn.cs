using RapidNRIMs.Model.Authenications;
using RapidNRIMs.Model.Cores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace RapidNRIMs.Model.Inventories
{
    public class InventoryStockCheckIn
    {
        public int InventoryStockCheckInID { get; set; }
        public string InventoryStockNumber { get; set; } = string.Empty;
        public string InventoryENName { get; set; } = string.Empty;
        public Nullable<DateTime> InventoryStockCheckIntDate { get; set; } = DateTime.Now;
        public Nullable<Guid> InventoryStockCheckInBy { get; set; }
        public bool IsStaff { get; set; }
        public Guid? ByUserID { get; set; }


        [JsonIgnore]
        public InventoryStock InventoryStock { get; set; }

        public void GetLookUp(List<InventoryStock> listInventoryStock)
        {
            this.InventoryStock = listInventoryStock.Find(i => i.InventoryStockNumber == this.InventoryStockNumber);
        }

        [JsonIgnore]
        public Account account { get; set; }

        public void GetLookUp(List<Account> listAccount)
        {
            this.account = listAccount.Find(u => u.UserID == InventoryStockCheckInBy);
        }
    }
}
