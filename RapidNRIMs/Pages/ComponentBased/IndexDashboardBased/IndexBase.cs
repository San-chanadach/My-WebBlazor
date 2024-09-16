using Blazored.LocalStorage;
using Blazored.Toast.Services;
using BlazorStrap;
using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Configuration;
using Microsoft.JSInterop;
using RapidNRIMs.Model.Instruments;
using RapidNRIMs.Model.Inventories;
using RapidNRIMs.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using static System.Net.WebRequestMethods;

namespace RapidNRIMs.Pages.ComponentBased.IndexDashboardBased
{
    public class IndexBase : ComponentBase
    {

        /// <summary>
        /// List Instrument
        /// </summary>
        protected List<InstrumentCalibration> CalDue = new List<InstrumentCalibration>();
        protected List<InstrumentMaintenance> MaDue = new List<InstrumentMaintenance>();
        protected List<InstrumentCheckOut> instrumentCheckOutsList = new List<InstrumentCheckOut>();
        protected List<InventoryStockCheckOut> inventoryStockCheckOuts = new List<InventoryStockCheckOut>();
        protected List<InventoryStockCheckOutItemLastYear> inventoryStockCheckOutItemLastYears = new List<InventoryStockCheckOutItemLastYear>();

        [Inject]
        protected AppData AppData { get; set; }
        [Inject]
        protected NavigationManager NavigationManager { get; set; }
        [Inject]
        protected IJSRuntime jsRuntime { get; set; }
        [Inject]
        protected IToastService ToastService { get; set; }
        [Inject]
        protected HttpClient? Http { get; set; }
        [Inject]
        protected IConfiguration config { get; set; }


        [Parameter]
        public string ProjectID { get; set; }



        /// <summary>
        /// void OnInitialized
        /// </summary>
        protected  override async Task OnInitializedAsync()
        {
            
            CalDue = AppData.DueCal;
            MaDue = AppData.DueMa;
            if (AppData.UserID == null)
            {

                //((IJSInProcessRuntime)jsRuntime).InvokeVoid("clearURL");
                NavigationManager.NavigateTo("/index");

            }

            instrumentCheckOutsList = await Http.GetFromJsonAsync<List<InstrumentCheckOut>>($"{config["nurl"]}/api/GetInstrumentCheckOut");

            inventoryStockCheckOutItemLastYears = await Http.GetFromJsonAsync<List<InventoryStockCheckOutItemLastYear>>($"{config["nurl"]}/api/GetInventoryCheckOutLastYear");
            // jsRuntime.InvokeAsync<object>("ScrollButtonTop");

            //((IJSInProcessRuntime)jsRuntime).InvokeVoid("clearURL");



        }

        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            if (firstRender)
            {
                
                await jsRuntime.InvokeVoidAsync("clearURL");
                //await jsRuntime.InvokeVoidAsync("scrollToBottom");
                //await jsRuntime.InvokeAsync<object>("exampleTables", "#example");
            }


            if (ProjectID != "" && ProjectID != null)
            {
                await jsRuntime.InvokeVoidAsync("scrollToCardTwo");
            }
            
            
            

        }
    }
}
