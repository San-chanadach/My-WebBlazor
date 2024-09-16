using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RapidNRIMs.Model.EventRecord
{
    public class EventStock
    {
      public int eventInventoryID {get; set;}
      public int projectInventoryID { get; set; }
      public int eventID {get; set;}

      public int eventStockID  { get; set; }

      public string eventStockNumber{ get; set; }

      public int eventStockQuantity{ get; set; }
    }
}
