using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using Newtonsoft.Json;

namespace RapidNRIMs.Model.Radiations
{
    public class RadiationSourceCheckOut
    {
        public int RadiationSourceCheckOutID { get; set; }
        [Required(ErrorMessage = "The  SourceNumber field is required")]
        public string RadiationSourceNumber { get; set; }
        [Range(1,2000, ErrorMessage = "The SourceAction field is required")]
        public Nullable<int> RadiationSourceCheckOutAction { get; set; } = 0;
        [Required(ErrorMessage = "The SourceGiveTo field is required")]
        public Nullable<Guid> RadiationSourceCheckOutGiveTo { get; set; }
        [Required(ErrorMessage = "The SourceReturnDate field is required")]
        public Nullable<DateTime> RadiationSourceCheckOutReturnDate { get; set; }
        [Required(ErrorMessage = "The CheckOutDate field is required")]
        public Nullable<DateTime> RadiationSourceCheckOutDate { get; set; }

        public string RadiationSourceCheckOutNote { get; set; }

        public string RadiationSourceCheckOutImageData { get; set; } = string.Empty;
        public string RadiationSourceCheckOutFile { get; set; }
        
        public bool RadiationSourceCheckOutStatus { get; set; }

        public bool IsStaff { get; set; }

        public Guid? ByUserID { get; set; }
    }
}