using Blazored.LocalStorage;
using Blazored.Toast.Services;
using Microsoft.AspNetCore.Components;
using PSC.Blazor.Components.Chartjs;
using PSC.Blazor.Components.Chartjs.Models.Common;
using PSC.Blazor.Components.Chartjs.Models.Line;
using RapidNRIMs.Model.EventRecord;
using RapidNRIMs.Model.Instruments;
using RapidNRIMs.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace RapidNRIMs.Pages.ComponentBased.IndexDashboardBased
{
    public class CardDashboardBase : ComponentBase
    {
        protected bool IsAllReturned = true;
        protected bool IsAllNonReturned = false;
        protected bool IsReadyInstrument = false;

        protected List<InstrumentCheckOut> instrumentCheckOutList = new List<InstrumentCheckOut>();
        protected List<InstrumentCheckOut> instrumentCheckOutListReturned => instrumentCheckOutList.Where(i => (i.InstrumentCheckOutStatus == 0 || i.InstrumentCheckOutStatus == (IsAllReturned ? 0 : 1))).ToList();
        protected List<InstrumentCheckOut> instrumentCheckOutListNonReturned => instrumentCheckOutList.Where(i => (i.InstrumentCheckOutStatus == 1 || i.InstrumentCheckOutStatus == (IsAllNonReturned ? 0 : 1))).ToList();
        protected List<InstrumentListView> instrumentListViews = new List<InstrumentListView>();
        protected List<InstrumentListView> instrumentListViewsReady => instrumentListViews.Where(i => (i.InstrumentStatusID == 1 || i.InstrumentStatusID == (IsReadyInstrument ? 0 : 1))).ToList();

        protected List<RecordProject> recordProjectList = new List<RecordProject>();
        protected List<RecordEvent> recordEvents = new List<RecordEvent>();

        protected List<InstrumentLocation> instrumentLocations = new List<InstrumentLocation>();
        protected List<InstrumentBrand> instrumentBrands = new List<InstrumentBrand>();
        protected List<InstrumentModel> instrumentModels = new List<InstrumentModel>();
        protected List<InstrumentAgency> instrumentAgencys = new List<InstrumentAgency>();
        protected List<InstrumentType> instrumentTypes = new List<InstrumentType>();
        protected List<InstrumentStatus> instrumentStatus = new List<InstrumentStatus>();
       // protected List<Instrument> instruments = new List<Instrument>();


        [Inject]
        protected AppData AppData { get; set; }
        [Inject]
        protected IToastService ToastService { get; set; }
        [Inject]
        protected HttpClient Http { get; set; }
        [Inject]
        protected ILocalStorageService _localStorageService { get; set; }
        [Inject]
        protected NavigationManager _navigationManager { get; set; }
        [Inject]
        protected IConfiguration config{ get; set; }
        [Inject]
        protected IMasterDataInstrument _masterDataInstrument { get; set; }
        [Inject]
        protected IMasterDataPhase2 _masterDataPhase2 { get; set; }
        [Inject]
        protected IMasterData _masterData{ get; set; }



        protected override async Task OnInitializedAsync()
        {
            try
            {
                instrumentCheckOutList = await Http.GetFromJsonAsync<List<InstrumentCheckOut>>($"{config["nurl"]}/api/GetInstrumentCheckOut");
                foreach (var item in instrumentCheckOutList)
                {
                    item.GetLookUp(AppData.instrumentsList);
                }

                instrumentListViews = await _masterDataInstrument.GetAllInstrumentMasterDataAsync<InstrumentListView>("GetInstrumentListView");
                foreach (var i in instrumentListViews)
                {
                    i.GetLookup(instrumentBrands, instrumentModels, instrumentAgencys, instrumentStatus, instrumentLocations);
                }

                //instruments = await _masterData.GetMasterDataAsync<Instrument>("Instrument");

                StateHasChanged();
            }
            catch (Exception e)
            {
                ToastService.ShowError($"Error: {e.Message}");
            }

           

        }
        
       
       


    }
}
