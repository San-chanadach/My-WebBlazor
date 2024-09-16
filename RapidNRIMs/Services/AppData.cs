using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;

using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using RapidNRIMs.Model.EventRecord;
using RapidNRIMs.Model.Authenications;
using RapidNRIMs.Model.Instruments;
using RapidNRIMs.Model.Inventories;
using RapidNRIMs.Model.Radiations;
using RapidNRIMs.Model.Logo;

namespace RapidNRIMs.Services
{
    public class AppData
    {


        public string[,] LangResource = new string[2, 2000];
        //public int[,] Calibration = new int[1, 2000];
        public string[] locale = { "us", "th" };

        public int LanguageID { get; set; }

        public List<Locale> locales = new();

        public int CurrentInstrumentID { get; set; }
        public int CurrentUserID { get; set; }
        public Nullable<Guid> UserID { get; set; }
        //public int calibrationID {get; set;}

        public List<UserPermission> CurrentPermission { get; set; }

        public List<Permission> permissionList = new();

        public List<InstrumentCalibration> DueCal = new List<InstrumentCalibration>();
        public List<InstrumentMaintenance> DueMa = new List<InstrumentMaintenance>();
        public List<MinStock> mins = new List<MinStock>();
        public List<Instrument> instrumentsList = new List<Instrument>();
        public List<InstrumentListView> instrumentsListView = new List<InstrumentListView>();
        public List<InstrumentCheckOut> instrumentCheckOutsList = new List<InstrumentCheckOut>();

        /*
         * Static Data LookUp
         * 
         */
        public List<RecordEvent> recordEvents = new List<RecordEvent>();

        public List<EventResult> eventResults = new List<EventResult>();

        public List<RecordEventType> recordEventTypes = new List<RecordEventType>();

        public List<RecordProject> recordProjects = new List<RecordProject>();

        public List<RecordProjectType> recordProjectTypes = new List<RecordProjectType>();

        public List<RecordEventProvince> Provinces = new List<RecordEventProvince>();

        public List<RecordEventDistrict> Districts = new List<RecordEventDistrict>();

        public List<SubDistrict> subDistricts = new List<SubDistrict>();

        public List<RecordRegional> recordRegionals = new List<RecordRegional>();

        public List<RecordEventUnit> recordEventUnits = new List<RecordEventUnit>();

        //***************************************************************************

        /*
         * Instrument Lookup
         */

        public List<InstrumentType> instrumentTypes = new List<InstrumentType>();
        public List<Instrument> instruments = new List<Instrument>();
        public List<InstrumentListView> instrumentListViews = new List<InstrumentListView>();
        public List<InstrumentCatagory> instrumentCatagories = new List<InstrumentCatagory>();
        public List<InstrumentBrand> instrumentBrands = new List<InstrumentBrand>();
        public List<InstrumentAgency> instrumentAgencies = new List<InstrumentAgency>();
        public List<InstrumentModel> instrumentModels = new List<InstrumentModel>();
        public List<InstrumentLocation> instrumentLocations = new List<InstrumentLocation>();
        public List<InstrumentAction> instrumentAction = new List<InstrumentAction>();
        public List<InstrumentStatus> instrumentStatus = new List<InstrumentStatus>();
        public List<InstrumentChecklistType> instrumentChecklistTypes = new List<InstrumentChecklistType>();
        public List<InstrumentUnit> instrumentUnits = new List<InstrumentUnit>();

        //***************************************************************************
        /*
        * Consumable Lookup
        */

        public List<Inventory> inventorys = new List<Inventory>();
        public List<InventoryStockCheckOut> inventoryStockCheckOuts = new List<InventoryStockCheckOut>();
        public List<InventoryStock> inventoryStocks = new List<InventoryStock>();
        public List<InventoryAgency> inventoryAgencys = new List<InventoryAgency>();
        public List<InventoryBrand> inventoryBrands = new List<InventoryBrand>();
        public List<InventoryStockType> inventoryStockTypes = new List<InventoryStockType>();
        public List<InventoryLocation> inventoryLocations = new List<InventoryLocation>();
        public List<InventoryAction> inventoryActions = new List<InventoryAction>();

        //***************************************************************************
        /*
        * RadiationSource Lookup
        */

        public List<RadiationSource> radiationSources = new List<RadiationSource>();
        public List<RadiationSourceCheckOutAction> radiationSourceCheckOutActions = new List<RadiationSourceCheckOutAction>();
        public List<RadiationSourceLocation> radiationSourceLocations = new List<RadiationSourceLocation>();
        public List<RadiationSourceType> radiationSourceTypes = new List<RadiationSourceType>();
        public List<RadioActivityUnit> radioActivityUnits = new List<RadioActivityUnit>();
        public List<RadiationDoseUnit> radiationDoseUnits = new List<RadiationDoseUnit>();
        public List<RadiationSourceUnit> radiationSourceUnits = new List<RadiationSourceUnit>();
        public List<RadiationSourceAgency> radiationSourceAgencies = new List<RadiationSourceAgency>();
        public List<RadiationSourceStatus> radiationSourceStatuses = new List<RadiationSourceStatus>();


        public List<ImageLogo> imageLogos = new List<ImageLogo>();  


        //***************************************************************************
        /*
        * Record Lookup
        */


        public string Translate(string EnglishWord)
        {
            string Translated = "";
            for (int i = 0; i < LangResource.Length; i++)
            {
                if (EnglishWord == LangResource[0, i])
                { Translated = LangResource[LanguageID, i]; }
            }
            return Translated;
        }

        public void SetPermission(List<UserPermission> c)
        {
            this.CurrentPermission = c;
        }

        public void SetNoti(List<InstrumentCalibration> c, List<InstrumentMaintenance> m, List<Instrument> ins)
        {
            instruments = ins;
            DueCal = c;
            DueMa = m;
            foreach (var i in DueCal)
            {
                i.GetLookup(ins);
            }
            foreach (var i in DueMa)
            {
                i.GetLookup(ins);
            }
        }

        public void SetLookUpLocation(List<RecordEventProvince> p, List<RecordEventDistrict> d, List<SubDistrict> sd)
        {
            // recordEventTypes = await RecordEventTypeService.GetRecordEventTypes();
            // recordEventProvinces = await RecordEventProvinceService.GetRecordEventProvinces();
            // recordEventDistricts = await RecordEventDistrictService.GetRecordEventDistricts();
            Provinces = p;
            Districts = d;
            subDistricts = sd; //await Http.GetFromJsonAsync<List<SubDistrict>>("https://ppunix.ga:4001/api/GetSubDistrict");

            foreach (var i in Districts)
            {
                i.SetSubDistricts(subDistricts);
            }

            foreach (var i in Provinces)
            {
                i.SetDistricts(Districts);
            }

        }


    }
}