using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using Newtonsoft.Json;
using RapidNRIMs.Model.Cores;

namespace RapidNRIMs.Model.EventRecord
{
    public class RecordProject : BaseModel
    {
        public int ProjectID { get; set; } 
        public string ProjectNumber { get; set; } = string.Empty;
        public string ProjectName { get; set; } = string.Empty; 
        public int? ProjectType { get; set; }
        public DateTime? ProjectRegisteredDate { get; set; }
        public int? ProjectRegional { get; set; }
        public string ProjectInformerName { get; set; } = string.Empty;
        public DateTime ProjectStartDate { get; set; } = DateTime.Today;
        public DateTime ProjectEndDate { get; set; } = DateTime.Today;
        public Guid? ProjectRegisteredBy { get; set; }
        public Guid? ProjectUpdatedBy { get; set; }
        public DateTime? ProjectUpdatedDate { get; set; }
        public string ProjectRecommend { get; set; } = string.Empty;    
        public int? ProjectInsStatusID { get; set; } 
        public int? ProjectInvsStatusID { get; set; }
        public bool? IsActive { get; set; }
        public int? SortByOrder { get; set; }


    }
}