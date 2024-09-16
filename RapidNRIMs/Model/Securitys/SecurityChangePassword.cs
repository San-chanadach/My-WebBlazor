using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RapidNRIMs.Model.Securitys
{
    public class SecurityChangePassword
    {
        
        public string OldPassword { get; set; }
        [Required(ErrorMessage = "The NewPassword field is required")]
        [StringLength(100, ErrorMessage = "password must least 6 characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string NewPassword { get; set; }
        [Required(ErrorMessage = "The ConfirmNewPassword field is required")]
        [StringLength(100, ErrorMessage = "password must least 6 characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string ConfirmNewPassword { get; set; }
    }
}
