using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using Newtonsoft.Json;

namespace RapidNRIMs.Model.Radiations
{
    public class RadiationSourceCheckIn
    {
        public int RadiationSourceCheckInID { get; set; }
        [Required(ErrorMessage = "The  SourceNumber field is required")]
        public string RadiationSourceNumber { get; set; } = string.Empty;
        public Nullable<int> RadiationSourceCheckOutID { get; set; }
        [Range(1, 2000, ErrorMessage = "The Location field is required")]
        public Nullable<int> RadiationSourceCheckInLocation { get; set; } = 0;
        [Required(ErrorMessage = "The ReturnDater field is required")]
        public Nullable<DateTime> RadiationSourceCheckInReturnDate { get; set; }
        [Required(ErrorMessage = "The Picture field is required")]
        public string RadiationSourceCheckInFile { get; set; }
        public string RadiationSourceCheckInImageData { get; set; } = string.Empty;
        public Nullable<Guid> RadiationSourceCheckInGiveTo { get; set; }
        public string RadiationSourceCheckInNote { get; set; }
        public bool IsStaff { get; set; }
        public Guid? ByUserID { get; set; }

        [JsonIgnore]
        public RadiationSource radiationSource { get; set; }

        public void GetLookUp(List<RadiationSource> listRadiationSource)
        {
            this.radiationSource = listRadiationSource.Find(i => i.RadiationSourceNumber == this.RadiationSourceNumber);
        }

    }
}
