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
    public class InventoryAgency : BaseModel
    {
        public int InventoryAgencyID { get; set; }
        //[Required(ErrorMessage = "The AgencyName field is required")]
        public string InventoryAgencyName { get; set; } = string.Empty;
        //[Required(ErrorMessage = "The AgencyAddress field is required")]
        public string InventoryAgencyAddress { get; set; } = string.Empty;
        //[Required(ErrorMessage = "The AgencyTel field is required")]
        public string InventoryAgencyTel { get; set; } = string.Empty;
       // [Required(ErrorMessage = "The AgencyEmail field is required")]
        //[EmailAddress(ErrorMessage = "The Email field is not a valid e-mail address.")]
        public string InventoryAgencyEmail { get; set; } = string.Empty;
        //[Required(ErrorMessage = "The AgencyDescription field is required")]
        public string InventoryAgencyDescription { get; set; } = string.Empty;
        public int? SortByOrder { get; set; }
        public bool? IsActive { get; set; }
    }
}