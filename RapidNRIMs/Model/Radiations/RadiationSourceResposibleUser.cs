using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using Newtonsoft.Json;

namespace RapidNRIMs.Model.Radiations
{
    public class RadiationSourceResposibleUser
    {
        public int radiationSourceResposibleUserID { get; set; }
        public int? radiationSourceID { get; set; }
        public Guid? UserID { get; set; }
        public string resposibleUserName { get; set; }

    }
}