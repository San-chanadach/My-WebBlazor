using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;

namespace RapidNRIMs.Model.Authenications
{
    public class UserAccount
    {
        public Guid UserID { get; set; }
        public string UserName { get; set; }
        public string PasswordHash { get; set; }
        public Nullable<int> Title { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Nullable<int> PositionID { get; set; }
        public string PositionName { get; set; }
        public string Email { get; set; }
        public string Fax { get; set; }
        public string PhoneNumber { get; set; }
        public Nullable<int> DepartmentID { get; set; }
        public Nullable<bool> IsActive { get; set; }
        public string Address { get; set; }
        public Nullable<int> ProvinceID { get; set; }
        public Nullable<int> DistrictID { get; set; }
        public Nullable<int> SubDistrictID { get; set; }
        public Nullable<int> ZipCode { get; set; }
    }
}