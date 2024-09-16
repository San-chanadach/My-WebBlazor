using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json.Serialization;

namespace RapidNRIMs.Model.Authenications
{
    public class Permission
    {
       public int permissionID { get; set; }
       
        public string permissionTHName { get; set; }
       
        public string permissionENName { get; set; }
       
        public string subPermissionTHName { get; set; }
      
        public string subPermissionENName { get; set; }

    }
}
