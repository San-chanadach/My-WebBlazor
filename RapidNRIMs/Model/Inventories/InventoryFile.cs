using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using Newtonsoft.Json;

namespace RapidNRIMs.Model.Inventories
{
    public class InventoryFile
    {
        public int InventoryFileID {get; set;}
        [Required(ErrorMessage = "The FilePath field is required")]
        public string InventoryFilePath {get; set;} = "";
        [Required(ErrorMessage = "The CreateDate field is required")]
        public DateTime CreateDate {get; set;} = DateTime.Now;
        [Required(ErrorMessage = "The Detail field is required")]
        public string Detail {get; set;} = "";
        public bool SortByOrder {get; set;}
        public bool IsActive {get; set;}
    }
}