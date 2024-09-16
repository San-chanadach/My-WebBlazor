using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using Newtonsoft.Json;

namespace RapidNRIMs.Model.Authenications
{
    public class AccountLogin
    {
        public string UserName { get; set; } = "";
        public string PassWord { get; set; } = "";
        public string Email { get; set; } = "";
    }
}