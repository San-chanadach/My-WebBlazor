using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;

namespace RapidNRIMs.Model.Securitys
{
    public class Resource
    {
        //public LanguageModels[] Consolidated_weather {get; set;}
        public int resourceID {get; set;}
        public int localeID { get; set; }
        public int resourceKey { get; set; }
        public string resourceName { get; set; } = " ";
    }
}