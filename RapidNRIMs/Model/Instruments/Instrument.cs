using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using Newtonsoft.Json;
using RapidNRIMs.Model.Cores;

namespace RapidNRIMs.Model.Instruments
{
    public class Instrument : BaseModel
    {
        public Nullable<int> InstrumentID { get; set; }
        public string InstrumentNumber { get; set; } = string.Empty;
        public string InstrumentAssetNumber { get; set; } = string.Empty;
        public string InstrumentSerialNumber { get; set; } = string.Empty;
        public string InstrumentTHName { get; set; } = string.Empty;
        public string InstrumentENName { get; set; } = string.Empty;
        public Nullable<int> InstrumentCatagoryID { get; set; } 
        public Nullable<int> InstrumentTypeID { get; set; } 
        public Nullable<int> InstrumentUnitID { get; set; }
        public Nullable<int> InstrumentModelID { get; set; } 
        public Nullable<int> InstrumentBrandID { get; set; } 
        public Nullable<int> InstrumentAgencyID { get; set; }
        public Nullable<Decimal> InstrumentPrice { get; set; }
        public Nullable<Guid> InstrumentUserID { get; set; }
        public Nullable<DateTime> InstrumentRegisterDate { get; set; } 
        public Nullable<int> InstrumentLocationID { get; set; }
        public string InstrumentDescription { get; set; } = string.Empty;
        public string InstrumentFileName { get; set; } = string.Empty; 
        public string InstrumentFile { get; set; } = string.Empty;
        public string InstrumentPictureDefault { get; set; } = string.Empty;
        public string InstrumentPictureLeft { get; set; } = string.Empty;
        public string InstrumentPictureRight { get; set; } = string.Empty;
        public Nullable<bool> InstrumentWeekly { get; set; }
        public Nullable<bool> InstrumentMonthly { get; set; }
        public Nullable<bool> InstrumentYearly { get; set; }
        public Nullable<int> InstrumentStatusID { get; set; }
        public Nullable<Guid> InstrumentDiscardByID { get; set; } = new Guid("00000000-0000-0000-0000-000000000000");
        public Nullable<DateTime> InstrumentDiscardDate { get; set; }
        public string InstrumentReason { get; set; } = string.Empty;
        public Nullable<bool> IsActive { get; set; }
        //public int InstrumentCalibrationID { get; set; }
    

        [JsonIgnore]
        public InstrumentBrand Brand { get; set; }
        [JsonIgnore]
        public InstrumentModel Model { get; set; }
        [JsonIgnore]
        public InstrumentAgency Agency { get; set; }
        [JsonIgnore]
        public InstrumentStatus Status { get; set; }
        [JsonIgnore]
        public InstrumentLocation Location { get; set; }
        [JsonIgnore]
        public List<InstrumentMapCheckListType> InstrumentCheckType { get; set; }=new List<InstrumentMapCheckListType>();
        [JsonIgnore]
        public List<InstrumentResposibleUser> Resposible { get; set; } = new List<InstrumentResposibleUser>();

        public void GetLookup(List<InstrumentBrand> brands, List<InstrumentModel> models, List<InstrumentAgency> agencys ,List<InstrumentStatus> status)
        {
            this.Brand = brands.Find(i => i.InstrumentBrandID == this.InstrumentBrandID);
            this.Model = models.Find(m => m.InstrumentModelID == this.InstrumentModelID);
            this.Agency = agencys.Find(a => a.InstrumentAgencyID == this.InstrumentAgencyID);
            this.Status = status.Find(s => s.InstrumentStatusID == this.InstrumentStatusID);
        }

        public void GetLookup(List<InstrumentBrand> brands, List<InstrumentModel> models, List<InstrumentAgency> agencys, List<InstrumentStatus> status , List<InstrumentLocation> locations)
        {
            this.Brand = brands.Find(i => i.InstrumentBrandID == this.InstrumentBrandID);
            this.Model = models.Find(m => m.InstrumentModelID == this.InstrumentModelID);
            this.Agency = agencys.Find(a => a.InstrumentAgencyID == this.InstrumentAgencyID);
            this.Status = status.Find(s => s.InstrumentStatusID == this.InstrumentStatusID);
            this.Location = locations.Find(l => l.InstrumentLocationID == this.InstrumentLocationID);
        }

        public void GetLookup(List<InstrumentBrand> brands, List<InstrumentModel> models, List<InstrumentAgency> agencys, List<InstrumentStatus> status, List<InstrumentLocation> locations , List<InstrumentMapCheckListType> instrumentCheckType)
        {
            this.Brand = brands.Find(i => i.InstrumentBrandID == this.InstrumentBrandID);
            this.Model = models.Find(m => m.InstrumentModelID == this.InstrumentModelID);
            this.Agency = agencys.Find(a => a.InstrumentAgencyID == this.InstrumentAgencyID);
            this.Status = status.Find(s => s.InstrumentStatusID == this.InstrumentStatusID);
            this.Location = locations.Find(l => l.InstrumentLocationID == this.InstrumentLocationID);
            this.InstrumentCheckType = instrumentCheckType.Where(c => c.InstrumentID == this.InstrumentID).ToList();
        }
    }
}
