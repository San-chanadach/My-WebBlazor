using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using Newtonsoft.Json;

namespace RapidNRIMs.Model.Securitys
{
    public class SourceFile
    {
        public int SourceFileID {get; set;}
        public string SourceFilePath {get; set;} = "";
        public DateTime SourceFileCreateDate {get; set;} = DateTime.Now;
        public string SourceFileDescription {get; set;} = "";
        public int SortByOrder {get; set;}
    }
}