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

namespace RapidNRIMs.Pages.ComponentBased.IndexDashboardBased
{
    public class PopularConsumableCheckOutDashboardBase : ComponentBase
    {

        /// <summary>
        /// List Account
        /// </summary>
        protected List<Account> accounts = new List<Account>();

        /// <summary>
        /// List Inventory
        /// </summary>
        protected List<Inventory> listInventory = new List<Inventory>();
        protected List<InventoryAgency> inventoryAgencys = new List<InventoryAgency>();
        protected List<InventoryBrand> inventoryBrands = new List<InventoryBrand>();
        protected List<InventoryStockCheckOut> inventoryStockCheckOuts = new List<InventoryStockCheckOut>();
        protected List<InventoryStock> inventoryStocks = new List<InventoryStock>();
        protected List<InventoryStockCheckOutItemLastYear> inventoryStockCheckOutItemLastYears = new List<InventoryStockCheckOutItemLastYear>();


        [Inject]
        protected AppData AppData { get; set; }
        [Inject]
        protected IJSRuntime jsRuntime { get; set; }
        [Inject]
        protected IMasterData _masterData { get; set; }
        [Inject]
        protected HttpClient Http { get; set; }
        [Inject]
        protected IConfiguration Config { get; set; }



        /// <summary>
        /// Task OnInitializedAsync
        /// </summary>
        /// <returns></returns>
        protected override async Task OnInitializedAsync()
        {

            inventoryStockCheckOuts = await Http.GetFromJsonAsync<List<InventoryStockCheckOut>>($"{Config["nurl"]}/api/GetInventoryStockCheckOut");
            foreach (var item in inventoryStockCheckOuts)
            {
                item.GetLookUp(AppData.inventoryStocks);

            }

            inventoryStockCheckOutItemLastYears = await Http.GetFromJsonAsync<List<InventoryStockCheckOutItemLastYear>>($"{Config["nurl"]}/api/GetInventoryCheckOutLastYear");



            //// คำนวณวันที่ Today - 12 เดือน
            //DateTime twelveMonthsAgo = DateTime.Today.AddMonths(-12);

            //// กรองรายการที่มี ConsumableCheckOutDate อยู่ในระยะเวลา Today - 12 เดือน
            //var result = inventoryStockCheckOuts
            //    .Where(x => x.InventoryStockCheckOutDate >= twelveMonthsAgo)
            //    .OrderByDescending(x => x.InventoryStockCheckOutDate)
            //    .ToList();

            //inventoryStockCheckOuts = result;

            

            accounts = await Http.GetFromJsonAsync<List<Account>>($"{Config["aurl"]}/api/GetAccount");
        }

    }
}
