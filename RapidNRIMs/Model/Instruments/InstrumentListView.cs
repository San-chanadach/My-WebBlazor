using RapidNRIMs.Model.Cores;
using RapidNRIMs.Model.Radiations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace RapidNRIMs.Model.Instruments
{
    public class InstrumentListView
    {
        public int? InstrumentID { get; set; }
        public string InstrumentNumber { get; set; } = string.Empty;
        public string InstrumentAssetNumber { get; set; } = string.Empty;
        public string InstrumentSerialNumber { get; set; } = string.Empty;
        public string InstrumentTHName { get; set; } = string.Empty;
        public string InstrumentENName { get; set; } = string.Empty;
        public int? InstrumentCatagoryID { get; set; }
        public int? InstrumentTypeID { get; set; }
        public int? InstrumentUnitID { get; set; }
        public int? InstrumentModelID { get; set; }
        public int? InstrumentBrandID { get; set; }
        public int? InstrumentAgencyID { get; set; }
        public DateTime? InstrumentRegisterDate { get; set; }
        public int? InstrumentLocationID { get; set; }
        public int? InstrumentStatusID { get; set; }
        public bool? IsActive { get; set; }

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
        public List<InstrumentMapCheckListType> InstrumentCheckType { get; set; } = new List<InstrumentMapCheckListType>();
        [JsonIgnore]
        public List<RadiationSourceResposibleUser> Resposible { get; set; } = new List<RadiationSourceResposibleUser>();

        public void GetLookup(List<InstrumentBrand> brands, List<InstrumentModel> models, List<InstrumentAgency> agencys, List<InstrumentStatus> status)
        {
            this.Brand = brands.Find(i => i.InstrumentBrandID == this.InstrumentBrandID);
            this.Model = models.Find(m => m.InstrumentModelID == this.InstrumentModelID);
            this.Agency = agencys.Find(a => a.InstrumentAgencyID == this.InstrumentAgencyID);
            this.Status = status.Find(s => s.InstrumentStatusID == this.InstrumentStatusID);
        }

        public void GetLookup(List<InstrumentBrand> brands, List<InstrumentModel> models, List<InstrumentAgency> agencys, List<InstrumentStatus> status, List<InstrumentLocation> locations)
        {
            this.Brand = brands.Find(i => i.InstrumentBrandID == this.InstrumentBrandID);
            this.Model = models.Find(m => m.InstrumentModelID == this.InstrumentModelID);
            this.Agency = agencys.Find(a => a.InstrumentAgencyID == this.InstrumentAgencyID);
            this.Status = status.Find(s => s.InstrumentStatusID == this.InstrumentStatusID);
            this.Location = locations.Find(l => l.InstrumentLocationID == this.InstrumentLocationID);
        }

        public void GetLookup(List<InstrumentBrand> brands, List<InstrumentModel> models, List<InstrumentAgency> agencys, List<InstrumentStatus> status, List<InstrumentLocation> locations, List<InstrumentMapCheckListType> instrumentCheckType)
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
