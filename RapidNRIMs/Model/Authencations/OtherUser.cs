using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RapidNRIMs.Model.Authenications
{
    public class OtherUser
    {
        public Guid  UserID { get; set; }
        [Required(ErrorMessage = "The Name field is required")]
        public string UserName { get; set; }
        [Required(ErrorMessage = "The Department field is required")]
        public string Department { get; set; }
        [Required(ErrorMessage = "The PhoneNumber field is required")]
        public string PhoneNumber { get; set; }
        public string? Email { get; set; }
    }
}
