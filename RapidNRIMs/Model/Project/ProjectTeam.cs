using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using Newtonsoft.Json;

namespace RapidNRIMs.Model.Project
{
    public class ProjectTeam
    {
        public int ProjectTeamID {get; set;}
        public int ProjectID {get; set;}
        public Guid? UserID { get; set; }
        public double? PersonalDose { get; set; }
        public double? OriginalPersonalDose { get; set; }
        public int? PersonalDoseUnitID { get; set; }
        public DateTime? PersonalDoseDate { get; set; }
    }
}