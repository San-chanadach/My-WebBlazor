using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RapidNRIMs.Model.Instruments
{
    public class InstrumentSearchParameter
    {
        public string InstrumentNumber { get; set; } = null;
        public string InstrumentAssetNumber { get; set; } = null;
        public string InstrumentSerialNumber { get; set; } = null;
        public string InstrumentTHName { get; set; } = null;
        public string InstrumentENName { get; set; } = null;

        public string InstrumentTypeID { get; set; } = null;
        public string InstrumentModelID { get; set; } = null;
        public string InstrumentBrandID { get; set; } = null;
        public string InstrumentAgencyID { get; set; } = null;
        public string ResposibleUserID { get; set; } = null;
        public DateTime? InstrumentRegisterDate { get; set; } = null;
        public string InstrumentLocationID { get; set; } = null;
    }
}
