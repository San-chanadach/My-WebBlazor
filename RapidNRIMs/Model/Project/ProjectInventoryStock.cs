using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RapidNRIMs.Model.Project
{
    public class ProjectInventoryStock
    {
      public int   ProjectInventoryID {get; set;}
      public int ProjectID {get; set;}

      public int ProjectStockID  { get; set; }

      public string ProjectStockNumber{ get; set; } = string.Empty;

      public int ProjectStockQuantity{ get; set; }

      public int? RemainQuantity { get; set; }
    }
}
