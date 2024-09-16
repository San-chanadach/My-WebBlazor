using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RapidNRIMs.Model.Project
{
   public class ProjectSupportTeam
    {
        public int ProjectSupportTeamID { get; set; }
        public int? ProjectID { get; set; }
        
        public string Name { get; set; } = "";
        
        public string Position { get; set; } = "";
        
        public string Department { get; set; } = "";
        
        public string PhoneNumber { get; set; } = "";

        public string? Email { get; set; }
        public int? Order { get; set; } = 1;
        public int? OrderProject { get; set; } = 1;
        public double? PersonalDose { get; set; }
        public double? OriginalPersonalDose { get; set; }
        public int? PersonalDoseUnitID { get; set; }
        public DateTime? PersonalDoseDate { get; set; }

    }
}
