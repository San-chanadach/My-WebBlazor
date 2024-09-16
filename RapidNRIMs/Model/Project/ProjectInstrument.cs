using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RapidNRIMs.Model.Project
{
    public class ProjectInstrument
    {
        public int ProjectInstrumentID  {get;set; }
        public int? ProjectID {get;set; }

        public int? InstrumentID { get; set; }

        public string InstrumentNumber { get; set; } = string.Empty;
    }
   
}

