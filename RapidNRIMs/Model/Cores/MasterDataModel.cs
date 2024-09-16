using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RapidNRIMs.Model.Cores
{
    public class MasterDataModel : BaseModel
    {
        public int? SortByOrder { get; set; }
        public bool? IsActive { get; set; }
    }
}
