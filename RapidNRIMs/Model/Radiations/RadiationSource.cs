using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using Newtonsoft.Json;
using RapidNRIMs.Model.Cores;

namespace RapidNRIMs.Model.Radiations
{
    public class RadiationSource
    {
        public int RadiationSourceID { get; set; }

        public string RadiationSourceNumber { get; set; } = "";
        // [Required(ErrorMessage = "The SourceSerial field is required")]
        public string RadiationSourceSerial { get; set; } = "";
        //[Required(ErrorMessage = "The SourceNuclide field is required")]
        public string RadiationSourceNuclide { get; set; } = string.Empty;

        public string RadiationSourceTHName { get; set; } = "";

        public string RadiationSourceENName { get; set; } = "";

        public string RadiationSourceActivityDetail { get; set; } = string.Empty;
        public int? RadioActivityUnitID { get; set; } = 1;
        public string RadiationSourceDoseRate { get; set; } = string.Empty;
        public int? RadiationDoseUnitID { get; set; } = 1;
        public Nullable<int> RadiationSourceTypeID { get; set; } 
        public Nullable<int> RadiationSourceAgencyID { get; set; } 
        public Nullable<int> RadiationSourceLocation { get; set; } = 0;
        public Nullable<DateTime> RadiationSourceManufacturedDate { get; set; }
        public Nullable<DateTime> RadiationSourcePurchaseDate { get; set; }

        public Nullable<int> RadiationSourceHalflife { get; set; } = 0;
        public Nullable<decimal> Halflife { get; set; }
        public Nullable<decimal> InitialActivity { get; set; }
        public Nullable<decimal> CurrentActivity { get; set; }
        public int? NucliedID { get; set; } = 0;
        public double? NHalflife { get; set; } = 0;
        public Nullable<int> RadiationSourceQuantity { get; set; } = 1;

        public Nullable<decimal> RadiationSourcePrice { get; set; } = 0;
        public Nullable<Guid> RadiationSourceUserID { get; set; }
        public string RadiationSourceFileName { get; set; } = string.Empty;
        public string RadiationSourceFile { get; set; } = string.Empty;
        public string RadiationSourcePictureDefault { get; set; } = string.Empty;
        public string RadiationSourcePictureLeft { get; set; } = string.Empty;
        public string RadiationSourcePictureRight { get; set; } = string.Empty;
        public Nullable<int> RadiationSourceStatusID { get; set; }
        public string RadiationSourceDetail { get; set; } = string.Empty;
        public Nullable<bool> IsActive { get; set; } 
       
        public Nullable<DateTime> RadiationSourceDiscardDate { get; set; }
        public Nullable<Guid> RadiationSourceDiscardBy { get; set; }
        
        public string RadiationSourceReason { get; set; }

        [JsonIgnore]
        public RadiationSourceUnit radiationSourceUnit { get; set; }

        [JsonIgnore]
        public List<RadiationSourceResposibleUser> Resposible { get; set; } = new List<RadiationSourceResposibleUser>();

        [JsonIgnore]
        public RadiationSourceStatus sourceStatus { get; set; }

        [JsonIgnore]
        public RadiationSourceType sourceTypes { get; set; }

        [JsonIgnore]
        public RadiationSourceUnit sourceUnit { get; set; }

        public void GetLookup(List<RadiationSourceType> types ,List<RadiationSourceStatus>status, List<RadiationSourceUnit> units)
        {
            this.sourceTypes = types.Find(x => x.RadiationSourceTypeID == this.RadiationSourceTypeID);
            this.sourceStatus = status.Find(s => s.RadiationSourceStatusID == this.RadiationSourceStatusID);
            this.sourceUnit = units.Find(x => x.RadiationSourceUnitID == this.RadioActivityUnitID);
        }
    }
}