using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using Newtonsoft.Json;

namespace RapidNRIMs.Model.EventRecord
{
    public class RecordEventTeam
    {
        public int EventTeamID {get; set;}
        public Guid? UserID { get; set; } 
        public int? EventID {get; set;}
    }
}