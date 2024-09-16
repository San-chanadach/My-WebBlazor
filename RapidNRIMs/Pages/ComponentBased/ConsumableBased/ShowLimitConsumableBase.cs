using Blazored.Toast.Services;
using BlazorStrap;
using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Configuration;
using Microsoft.JSInterop;
using RapidNRIMs.Model.Authenications;
using RapidNRIMs.Model.Inventories;
using RapidNRIMs.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace RapidNRIMs.Pages.ComponentBased.ConsumableBased
{
    public class ShowLimitConsumableBase : ComponentBase
    {
        protected IEnumerable<InventoryStock> inventoryStocks;
        protected List<Account> accounts = new List<Account>();
        

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

        /// <summary>
        /// Variable
        /// </summary>
        protected string RequertMessage;
        public int? ID { get; set; }

        /// <summary>
        /// OnInitializedAsync
        /// </summary>
        /// <returns></returns>
        protected override async Task OnInitializedAsync()
        {
            try
            {
                inventoryStocks = await Http.GetFromJsonAsync<List<InventoryStock>>($"{Config["nurl"]}/api/GetInventoryStock");
                foreach (var i in inventoryStocks)
                {
                    i.GetLookUp(AppData.inventorys, AppData.inventoryLocations, AppData.inventoryStockTypes);
                }
                //int numberStock = 20;
                //var result = inventoryStocks.OrderByDescending(x => x.InventoryStockID).Take(numberStock);
                //inventoryStocks = result;

                accounts = await Http.GetFromJsonAsync<List<Account>>($"{Config["aurl"]}/api/GetAccount");
 


                await jsRuntime.InvokeAsync<object>("ResponsiveDataTables");

            }
            catch (Exception e)
            {
                var val = e.Message;
                RequertMessage = val;
            }
        }

        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            if (firstRender)
            {
                await jsRuntime.InvokeVoidAsync("clearURL");
                //await jsRuntime.InvokeAsync<object>("exampleTables", "#example");
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

        protected void TrClickedAtIndex(int? id)
        {
            ID = id;

        }


        protected void Loading()
        {
            System.Threading.Thread.Sleep(300);
            // Retrieve data from the server and initialize
            // Employees property which the View will bind
        }


    }
}
