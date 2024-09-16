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
    public class InstrumentUnit : BaseModel
    {
        public int InstrumentUnitID {get; set;}
        [Required(ErrorMessage = "The UnitName field is required")]
        public string InstrumentUnitName {get; set;} = "";
        [Required(ErrorMessage = "The UnitDescription field is required")]
        public string InstrumentUnitDescription {get; set;} = string.Empty;
        public int? SortByOrder {get; set;}
        public bool? IsActive {get; set;}
    }
}