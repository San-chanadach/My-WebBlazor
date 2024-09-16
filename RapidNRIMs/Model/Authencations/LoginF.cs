using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using Newtonsoft.Json;

namespace RapidNRIMs.Model.Authenications
{
    public class LoginF
    {
        public Nullable<Guid> UserID { get; set; } = null;
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
    }


}