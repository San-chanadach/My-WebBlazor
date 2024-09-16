using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RapidNRIMs.Model.EventRecord
{
   public class EventSupportTeam
    {
        public int EventSupportTeamID { get; set; }
        public int? EventID { get; set; }
        public int? ProjectSupportTeamID { get; set; }
        [Required(ErrorMessage = "The SupportName field is required")]

        public string Name { get; set; } = "";
        [Required(ErrorMessage = "The Position field is required")]
        public string Position { get; set; } = "";
        [Required(ErrorMessage = "The Department field is required")]
        public string Department { get; set; } = "";
        [Required(ErrorMessage = "The PhoneNumber field is required")]
        public string PhoneNumber { get; set; } = "";

        public string? Email { get; set; }
        public int? Order { get; set; } = 1;

    }
}
