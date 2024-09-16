using Blazored.Toast.Services;
using BlazorStrap;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using PSC.Blazor.Components.Chartjs;
using PSC.Blazor.Components.Chartjs.Models.Common;
using PSC.Blazor.Components.Chartjs.Models.Line;
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
    public class ConsumableNeedDashboardBase : ComponentBase
    {

       

        /// <summary>
        /// List Inventory
        /// </summary>
        protected List<Inventory> listInventory = new List<Inventory>();
        protected List<InventoryAgency> inventoryAgencys = new List<InventoryAgency>();
        protected List<InventoryBrand> inventoryBrands = new List<InventoryBrand>();
        protected List<InventoryStock> inventoryStocks = new List<InventoryStock>();
        protected Inventory editInventory = new Inventory();
        
        /// <summary>
        /// BSMODAL
        /// </summary>
        protected BSModal ModalInventoryEdit { get; set; }
        protected BSModal ModalResponseError { get; set; }
        protected BSModal ModalRespondSuccess { get; set; }

        protected string RequertMessage;

        [Inject]
        protected AppData AppData { get; set; }
        [Inject]
        protected IJSRuntime jsRuntime { get; set; }
        [Inject]
        protected IMasterData _masterData { get; set; }
        [Inject]
        protected HttpClient Http { get; set; }
        [Inject]
        protected IMasterDataInventory _masterDataInventory { get; set; }
        [Inject]
        protected IToastService ToastService { get; set; }
        [Inject]
        protected IConfiguration config { get; set; }


        /// <summary>
        /// void OnInitialized
        /// </summary>
        protected override void OnInitialized()
        {


            /// <summary>
            /// Innventory
            /// </summary>
            try
            {
                listInventory = AppData.inventorys;
                inventoryBrands = AppData.inventoryBrands;
                inventoryAgencys = AppData.inventoryAgencys;


                foreach (var i in listInventory)
                {
                    i.Getlookup(AppData.inventoryBrands, AppData.inventoryAgencys);
                }
            }
            catch (Exception e)
            {
                var val = e.Message;
                //RequertMessage = val;
            }

            jsRuntime.InvokeAsync<object>("exampleTables", "#example");

        }

        /// <summary>
        /// SaveEditInventory
        /// </summary>
        protected async Task SaveEditInventory()
        {
            try
            {
                var respond = await _masterDataInventory.PutInventoryMasterDataAsync("PutInventory", editInventory);
                if (!string.IsNullOrEmpty(respond.ToString()))
                {
                    await SetAsync();
                    ToastService.ShowSuccess("Update Consumasble is Success");
                }
                else
                {
                    ToastService.ShowError("Update Consumasble  is not Success");
                }
            }
            catch (Exception e)
            {
                var val = e.Message;
                ToastService.ShowError($"Update Consumasble  is Success. Code : {val.ToString()}");
            }
            ModalInventoryEdit.Hide();
        }

        /// <summary>
        /// SetAsync
        /// </summary>
        /// <returns></returns>
        public async Task SetAsync()
        {
            AppData.inventorys = await _masterData.GetMasterDataAsync<Inventory>("Inventory");
            AppData.inventoryBrands = await _masterData.GetMasterDataAsync<InventoryBrand>("InventoryBrand");
            AppData.inventoryAgencys = await _masterData.GetMasterDataAsync<InventoryAgency>("InventoryAgency");
            AppData.mins = await Http.GetFromJsonAsync<List<MinStock>>($"{config["nurl"]}/api/GetInventoryminStock");
            foreach (var i in AppData.inventorys)
            {
                i.Getlookup(AppData.inventoryBrands, AppData.inventoryAgencys);
            }

            listInventory = AppData.inventorys;
            inventoryBrands = AppData.inventoryBrands;
            inventoryAgencys = AppData.inventoryAgencys;

        }



        public void Notif(int id)
        {
            var result = listInventory.Find(i => i.InventoryID == id);
            if (!string.IsNullOrEmpty(result.ToString()))
            {
                editInventory = result;
                ModalInventoryEdit.Show();

            }

        }
    }
}
