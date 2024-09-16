using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using Newtonsoft.Json;

namespace RapidNRIMs.Model.Instruments
{
    public class InstrumentResposibleUser
    {
        public int instrumentResposibleUserID { get; set; }
        public int? instrumentID { get; set; }
        public Guid? UserID { get; set; }
        public string resposibleUserName { get; set; }

    }
}