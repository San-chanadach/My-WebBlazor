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
    public class InventoryBrand : BaseModel
    {
        public int InventoryBrandID {get; set;}
        //[Required(ErrorMessage = "The BrandName field is required")]
        public string InventoryBrandName { get; set; } = string.Empty;
        //[Required(ErrorMessage = "The BrandDescription field is required")]
        public string InventoryBrandDescription {get; set;} = string.Empty;
        public int? SortByOrder { get; set; }
        public bool? IsActive { get; set; }

        
    }
}