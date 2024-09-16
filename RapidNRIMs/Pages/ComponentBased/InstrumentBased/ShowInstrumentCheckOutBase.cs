using Blazored.Toast.Services;
using BlazorStrap;
using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Configuration;
using Microsoft.JSInterop;
using RapidNRIMs.Model.Authenications;
using RapidNRIMs.Model.Instruments;
using RapidNRIMs.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace RapidNRIMs.Pages.ComponentBased.InstrumentBased
{
    public class ShowInstrumentCheckOutBase : ComponentBase
    {
        protected bool IsAllNonReturned = false;
        protected bool IsReadyInstrument = false;

        protected IEnumerable<InstrumentListView> listInstrument;
      
        protected List<Account> accounts = new List<Account>();
        protected IEnumerable<InstrumentCheckOut> instrumentCheckOutListReturned;
        protected List<InstrumentAction> instrumentActions = new List<InstrumentAction>();
        protected List<OtherUser> other = new List<OtherUser>();

        protected List<InstrumentLocation> instrumentLocations = new List<InstrumentLocation>();
        protected List<InstrumentBrand> instrumentBrands = new List<InstrumentBrand>();
        protected List<InstrumentModel> instrumentModels = new List<InstrumentModel>();
        protected List<InstrumentAgency> instrumentAgencys = new List<InstrumentAgency>();
        protected List<InstrumentType> instrumentTypes = new List<InstrumentType>();
        protected List<InstrumentStatus> instrumentStatus = new List<InstrumentStatus>();
        protected List<InstrumentCheckOut> instrumentCheckOutList = new List<InstrumentCheckOut>();
        protected List<InstrumentCheckOut> instrumentCheckOutListNonReturned => instrumentCheckOutList.Where(i => (i.InstrumentCheckOutStatus == 1 || i.InstrumentCheckOutStatus == (IsAllNonReturned ? 0 : 1))).ToList();
        protected List<InstrumentListView> instrumentListViews = new List<InstrumentListView>();
        protected List<Instrument> instrumentListViewsReady => AppData.instrumentsList.Where(i => (i.InstrumentStatusID == 1 || i.InstrumentStatusID == (IsReadyInstrument ? 0 : 1))).ToList();

        protected BSModal Load { get; set; }

        [Inject]
        protected AppData AppData { get; set; }
        [Inject]
        protected NavigationManager NavigationManager { get; set; }
        [Inject]
        protected IJSRuntime jsRuntime { get; set; }
        [Inject]
        protected IToastService ToastService { get; set; }
        [Inject]
        protected HttpClient Http { get; set; }
        [Inject]
        protected IConfiguration Config { get; set; }
        [Inject]
        protected IMasterDataInstrument _masterDataInstrument { get; set; }

        /// <summary>
        /// Variable
        /// </summary>
        protected string RequertMessage;
        public int? ID { get; set; }
        protected ElementReference dataTableContainer;

        /// <summary>
        /// OnInitializedAsync
        /// </summary>
        /// <returns></returns>
        protected override async Task OnInitializedAsync()
        {
            try
            {
                //int numberNonReturn = 20;
                //var resultNonReturn = AppData.instrumentCheckOutsList.OrderByDescending(x => x.InstrumentCheckOutStatus == 1).Take(numberNonReturn);
                //instrumentCheckOutListNonReturned = resultNonReturn;

                //int numberReturn = 20;
                //var resultReturn = AppData.instrumentCheckOutsList.OrderByDescending(x => x.InstrumentCheckOutStatus == 0).Take(numberReturn);
                //instrumentCheckOutListReturned = resultReturn;

                accounts = await Http.GetFromJsonAsync<List<Account>>($"{Config["aurl"]}/api/GetAccount");
                other = await Http.GetFromJsonAsync<List<OtherUser>>($"{Config["nurl"]}/api/OtherUser");

                instrumentTypes = AppData.instrumentTypes;


                instrumentBrands = AppData.instrumentBrands;


                instrumentAgencys = AppData.instrumentAgencies;

                instrumentModels = AppData.instrumentModels;

                instrumentLocations = AppData.instrumentLocations;

                instrumentStatus = AppData.instrumentStatus;

                AppData.instrumentsList = await _masterDataInstrument.GetAllInstrumentMasterDataAsync<Instrument>("GetInstrumentListView");
                foreach (var i in AppData.instrumentsList)
                {
                    i.GetLookup(instrumentBrands, instrumentModels, instrumentAgencys, instrumentStatus, instrumentLocations);
                }

                instrumentCheckOutList = await Http.GetFromJsonAsync<List<InstrumentCheckOut>>($"{Config["nurl"]}/api/GetInstrumentCheckOut");
                foreach (var item in instrumentCheckOutList)
                {
                    item.GetLookUp(AppData.instrumentsList);
                }

                await jsRuntime.InvokeAsync<object>("ResponsiveDataTables");
                StateHasChanged();

                //await jsRuntime.InvokeAsync<object>("ResponsiveDataTables");

            }
            catch (Exception e)
            {
                var val = e.Message;
                RequertMessage = val;
            }
        }

        protected string GetRowBackgroundColor(int? rowId)
        {
            if (rowId.HasValue && rowId == ID)
            {
                return "selected-row"; // ส่งค่าคลาส CSS ที่จะให้แถวเปลี่ยนสี
            }
            return string.Empty; // ไม่ต้องมีการเปลี่ยนสี
        }

        public void TrClickedAtIndex(int? id)
        {
            ID = id;

        }



        protected void Loading()
        {
            System.Threading.Thread.Sleep(300);
            // Retrieve data from the server and initialize
            // Employees property which the View will bind
        }

        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            if (firstRender)
            {
                await jsRuntime.InvokeVoidAsync("clearURL");
                //await jsRuntime.InvokeAsync<object>("exampleTables", "#example");
            }
        }

    }
}
