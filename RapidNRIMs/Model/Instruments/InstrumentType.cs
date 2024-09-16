using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using Newtonsoft.Json;
using RapidNRIMs.Model.Cores;

namespace RapidNRIMs.Model.Instruments
{
    public class InstrumentType : BaseModel
    {
       public int InstrumentTypeID { get; set; }
        [Required(ErrorMessage = "The NameType field is required")]
        public string InstrumentTypeName { get; set; } = string.Empty;
        [Required(ErrorMessage = "The Description field is required")]
        public string InstrumentTypeDescription { get; set; } = string.Empty;
        public int? SortByOrder { get; set; }
        public bool? IsActive { get; set; }
    }
}