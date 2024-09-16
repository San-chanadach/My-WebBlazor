using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace RapidNRIMs.Model.Authenications
{
  public  class UserPermission
    {
        public int userPermissionID { get; set; }
        public Guid UserID { get; set; }

        public int permissionID { get; set; }

        [JsonIgnore]
        public Permission permission { get; set; }
      
        public bool permissionC { get; set; }
        public bool permissionU { get; set; }
        public bool permissionV { get; set; }
        public bool permissionD { get; set; }
        public bool permissionE { get; set; }

        public void Getlookup(List<Permission> p)
        {
            this.permission = p.Find(i => i.permissionID == this.permissionID);
        }
    }
}
