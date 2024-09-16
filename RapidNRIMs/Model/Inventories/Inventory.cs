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
    public class Inventory : BaseModel
    {
        public int InventoryID {get; set;}
        public string InventoryNumber { get; set; } = string.Empty;
        public int? InventoryBrandID { get; set; }
        public int? InventoryAgencyID { get; set; }
        public bool? IsActive {get; set;}
        public string InventoryTHName { get; set; } = string.Empty;
        public string InventoryENName { get; set; }
        public int? minStock { get; set; } = 1;
        public bool? IsNotif { get; set; } = false;

        [JsonIgnore]
        public InventoryBrand brand { get; set; }
        public InventoryAgency agency { get; set; }


        public void Getlookup(List<InventoryBrand> brands , List<InventoryAgency> agencies){
            this.brand = brands.Find(i => i.InventoryBrandID == this.InventoryBrandID);
            this.agency = agencies.Find(i => i.InventoryAgencyID == this.InventoryAgencyID);
        }
    }
}