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
    public class InventoryStockType : BaseModel
    {
        public int InventoryStockTypeID { get; set; }
        [Required(ErrorMessage = "The StockTypeName field is required")]
        public string InventoryStockTypeName { get; set; } = string.Empty;
         [Required(ErrorMessage = "The StockTypeDescription field is required")]
        public string InventoryStockTypeDescription { get; set; } = string.Empty;
        public int? SortByOrder { get; set; }
        public bool? IsActive { get; set; }
    }
}