using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RapidNRIMs.Model.EventRecord
{
    public class EventResult
    {
        public int eventResultID { get; set; } = 0;
        public int eventID { get; set; } = 0;

        public string eventResultDescription { get; set; } = string.Empty;
     
        public string eventResultImageName{ get; set; } = string.Empty;

        public string eventResultImageData { get; set; } = string.Empty;

        public string eventResultImageFile{ get; set; } = string.Empty;

        public string eventResultInstrumentNumber{ get; set; } = string.Empty;

        public DateTime? eventResultDate { get; set; }
      
        public string result { get; set; } = string.Empty;
        [Required, Range(1,200)]
        public int? eventResultUnit { get; set; }
      
        public Guid? eventResultBy{ get; set; }
        public int? SupportTeam { get; set; }
        public string RadiationNuclide { get; set; } = string.Empty;
        public string Backgroud { get; set; } = string.Empty;
        public Nullable<int> BackgroudUnit { get; set; }
        public string MeterDistance { get; set; } = string.Empty;
        public Nullable<int> MeterDistanceUnit { get; set; }
        public string FeetDistance { get; set; } = string.Empty;
        public Nullable<int> FeetDistanceUnit { get; set; }
        public string DoseAccumulation { get; set; } = string.Empty;
        public Nullable<int> DoseAccumulationUnit { get; set; }
        public string Hour { get; set; } = string.Empty;
        public DateTime? StartWorkingHour { get; set; }
        public DateTime? EndWorkingHour { get; set; }
    }
}
