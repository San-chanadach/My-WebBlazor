using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using Newtonsoft.Json;

namespace RapidNRIMs.Model.Authenications
{
    public class Account
    {
        public Guid UserID { get; set; }
        [Range(1,2000, ErrorMessage = "The Title field is required")]
        public Nullable<int> Title { get; set; }
        [Required(ErrorMessage = "The FirstName field is required")]
        public string FirstName { get; set; } = "";
        [Required(ErrorMessage = "The LastName field is required")]
        public string LastName { get; set; } = "";
        [Range(1,2000, ErrorMessage = "The Position field is required")]
        public Nullable<int> PositionID { get; set; }
        public string PositionName { get; set; }
        [Required(ErrorMessage = "The Email field is required")]
        [EmailAddress(ErrorMessage = "The Email field is not a valid e-mail address.")]
        public string Email { get; set; } = "";
        public string PhoneNumber { get; set; } = "";
        [Range(1,2000, ErrorMessage = "The Department field is required")]
        public Nullable<int> DepartmentID { get; set; }
        public bool IsActive { get; set; }
    }
}