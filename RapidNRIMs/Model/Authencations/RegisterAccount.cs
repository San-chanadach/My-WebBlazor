using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using Newtonsoft.Json;

namespace RapidNRIMs.Model.Authenications
{
    public class RegisterAccount
    {
        [Required]
        public string UserName { get; set; }
        [Required(ErrorMessage = "The FirstName field is required")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "The LastName field is required")]
        public string LastName { get; set; }
        [Required(ErrorMessage = "The Email field is required")]
        [EmailAddress(ErrorMessage = "The Email field is not a valid e-mail address.")]
        public string Email { get; set; }
        [Required(ErrorMessage = "The Password field is required")]
        [StringLength(100, ErrorMessage = "password must least 6 characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string PasswordHash { get; set; }
        [Required(ErrorMessage = "The ConfrimPassword field is required")]
        [StringLength(100, ErrorMessage = "password must least 6 characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string ConfrimPassword { get; set; }
        public Guid userID { get; set; }
       
    }
}