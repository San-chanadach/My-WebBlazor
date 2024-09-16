using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;

namespace RapidNRIMs.Model.Securitys
{
    public class LanguageModels
    {
        //public LanguageModels[] Consolidated_weather {get; set;}
        public int ResourceID {get; set;}
        public int ResourceKeyID {get; set;}
        public int localeID {get; set;}
        public string ResourcesName {get; set;}
        public string Value1 {get; set;}
        public string Value2 {get; set;}

    }
}