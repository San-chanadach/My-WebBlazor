using Blazored.Toast.Services;
using BlazorStrap;
using Microsoft.AspNetCore.Components;
using PSC.Blazor.Components.Chartjs;
using PSC.Blazor.Components.Chartjs.Models.Common;
using PSC.Blazor.Components.Chartjs.Models.Line;
using RapidNRIMs.Data;
using RapidNRIMs.Model.Instruments;
using RapidNRIMs.Model.Inventories;
using RapidNRIMs.Services;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq;

namespace RapidNRIMs.Pages.ComponentBased.IndexDashboardBased
{
    public class LineChartBase : ComponentBase
    {
        /// <summary>
        /// Chart JS
        /// </summary>
        //protected LineConfig _lineInstrumentCheckOutConfig;
        //protected LineConfig _lineInventoryCheckOutConfig;
        protected LineChartConfig _lineInstrumentCheckOutConfig;
        protected LineChartConfig _lineInventoryCheckOutConfig;
        protected Chart _chart1;
        protected List<InventoryStockCheckOutItem> inventoryStockCheckOutItems = new List<InventoryStockCheckOutItem>();
        protected List<InstrumentCheckOut> instrumentCheckOutsList = new List<InstrumentCheckOut>();
        protected List<InventoryStockCheckOut> inventoryStockCheckOuts = new List<InventoryStockCheckOut>();
        protected List<InventoryStockCheckOutItemLastYear> inventoryStockCheckOutItemLastYears = new List<InventoryStockCheckOutItemLastYear>();
        public BSModal? Load { get; set; }

        protected static List<string> Months = new List<string>();


        protected static List<string> StockMonths = new List<string>();

        /// <summary>
        /// Inject
        /// </summary>
        [Inject]
        protected AppData AppData { get; set; }
        [Inject]
        protected HttpClient? Http { get; set; }
        [Inject]
        protected IConfiguration config { get; set; }
        [Inject]
        protected IToastService ToastService { get; set; }
        [Inject]
        protected IMasterData masterData { get; set; }


        protected async Task SetOnIniti()
        {
            instrumentCheckOutsList = await Http.GetFromJsonAsync<List<InstrumentCheckOut>>($"{config["nurl"]}/api/GetInstrumentCheckOut");

            inventoryStockCheckOuts = AppData.inventoryStockCheckOuts;

            inventoryStockCheckOutItemLastYears = await Http.GetFromJsonAsync<List<InventoryStockCheckOutItemLastYear>>($"{config["nurl"]}/api/GetInventoryCheckOutLastYear");
        }

        /// <summary>
        /// void OnInitialized
        /// </summary>
        protected override void OnInitialized()
        {
            //******************Line Instrument CheckOut Chart**********************************
            // Show the modal
            Load?.Show();

            // Simulate a delay for loading (e.g., 2 seconds)
            Task.Delay(2000);

            _lineInstrumentCheckOutConfig = new LineChartConfig()
            {
                Options = new Options()
                {
                    Responsive = true,
                    MaintainAspectRatio = false,
                    //Animations = new Animations()
                    //{
                    //    Tension = new Tension()
                    //    {
                    //        Duration = 1000,
                    //        Easing = "linear",
                    //        From = 5,
                    //        To = 4,
                    //        Loop = true
                    //    }
                    //},
                    Scales = new Dictionary<string, Axis>()
                    {
                        {
                            Scales.YAxisId, new Axis()
                            {
                                BeginAtZero = true,
                                Min = 0,
                                Max = 200
                            }


                        }
                    }
                }
            };

            CalculateInstrumentCheckOutMonthlyTotal();

            // เรียกใช้ StateHasChanged() เพื่อรีเรนเดอร์หน้าเว็บ
            StateHasChanged();

            _lineInventoryCheckOutConfig = new LineChartConfig()
            {
                Options = new Options()
                {
                    Responsive = true,
                    MaintainAspectRatio = false,
                    Scales = new Dictionary<string, Axis>()
                    {

                        {
                            Scales.YAxisId, new Axis()
                            {
                                BeginAtZero = true,
                                Min = 0,
                                Max = 200
                            }
                        }
                    }
                }
            };

            CalculateInventoryCheckOutMonthlyTotal();


            // เรียกใช้ StateHasChanged() เพื่อรีเรนเดอร์หน้าเว็บ
            StateHasChanged();

            // Hide the modal
            Load?.Hide();
        }


        protected async void CalculateInstrumentCheckOutMonthlyTotal()
        {
           
            instrumentCheckOutsList = await Http.GetFromJsonAsync<List<InstrumentCheckOut>>($"{config["nurl"]}/api/GetInstrumentCheckOut");
            foreach (var item in instrumentCheckOutsList)
            {
                item.GetLookUp(AppData.instrumentsList);
            }

            // สร้าง List ของเดือนและรายการผลรวมเช็คเอาท์ของแต่ละเดือนและปี
            var today = DateTime.Now;
            var monthsAndTotals = Enumerable.Range(0, 12)
                .Select(i =>
                {
                    var currentMonth = today.AddMonths(-i);
                    var resultTotal = instrumentCheckOutsList
                        .Count(x => x.InstrumentCheckOutDate.HasValue &&
                                    x.InstrumentCheckOutDate.Value.Year == currentMonth.Year &&
                                    x.InstrumentCheckOutDate.Value.Month == currentMonth.Month);

                    return new { Month = currentMonth.ToString("MMM"), Total = resultTotal, SortKey = currentMonth };
                })
                .OrderBy(item => item.SortKey) // เรียงลำดับตาม SortKey
                .ToList();

            // สร้าง List ของจำนวนการเช็คเอาท์ตามเดือน
            var totals = monthsAndTotals.Select(item => (decimal)item.Total).ToList();

            // กำหนดค่า Labels และ Datasets ของ _lineInstrumentCheckOutConfig
            _lineInstrumentCheckOutConfig.Data.Labels = monthsAndTotals.Select(item => item.Month).ToList();
            _lineInstrumentCheckOutConfig.Data.Datasets.Add(new LineDataset()
            {
                Label = "Instrument CheckOut",
                Data = totals,
                BorderColor = Colors.PaletteBorder1.FirstOrDefault(),
                BackgroundColor = "#20B2AA",
                Fill = false
            });

          
        }



        protected async void CalculateInventoryCheckOutMonthlyTotal()
        {

            inventoryStockCheckOuts = await Http.GetFromJsonAsync<List<InventoryStockCheckOut>>($"{config["nurl"]}/api/GetInventoryStockCheckOut");
            foreach (var item in inventoryStockCheckOuts)
            {
                item.GetLookUp(AppData.inventoryStocks);

            }

            inventoryStockCheckOutItemLastYears = await Http.GetFromJsonAsync<List<InventoryStockCheckOutItemLastYear>>($"{config["nurl"]}/api/GetInventoryCheckOutLastYear");

            // สร้าง List ของเดือนและรายการผลรวมเช็คเอาท์ของแต่ละเดือนและปี
            var today = DateTime.Now;
            var monthsAndTotals = Enumerable.Range(0, 12)
                .Select(i =>
                {
                    var currentMonth = today.AddMonths(-i);
                    var resultTotal = inventoryStockCheckOutItemLastYears
                        .Count(x => x.LastCheckOutDate.HasValue &&
                                    x.LastCheckOutDate.Value.Year == currentMonth.Year &&
                                    x.LastCheckOutDate.Value.Month == currentMonth.Month);

                    return new { Month = currentMonth.ToString("MMM"), Total = resultTotal, SortKey = currentMonth };
                })
                .OrderBy(item => item.SortKey) // เรียงลำดับตาม SortKey
                .ToList();

            // สร้าง List ของจำนวนการเช็คเอาท์ตามเดือน
            var totals = monthsAndTotals.Select(item => (decimal)item.Total).ToList();

            // กำหนดค่า Labels และ Datasets ของ _lineInstrumentCheckOutConfig
            _lineInventoryCheckOutConfig.Data.Labels = monthsAndTotals.Select(item => item.Month).ToList();
            _lineInventoryCheckOutConfig.Data.Datasets.Add(new LineDataset()
            {
                Label = "Consumable CheckOut",
                Data = totals,
                BorderColor = Colors.PaletteBorder1.FirstOrDefault(),
                BackgroundColor = "#20B2AA",
                Fill = false
            });





        }


        protected void Loading()
        {
            System.Threading.Thread.Sleep(300);
            // Retrieve data from the server and initialize
            // Employees property which the View will bind
        }


    }
}

// นับจำนวนครั้งในการเช็คเอาท์สำหรับแต่ละเดือนและปี
//var resultStockMonthlyTotal = new List<int>();
//var todayStock = DateTime.Now;

//for (int i = 11; i >= 0; i--) // เริ่มต้นจากเดือนปัจจุบันย้อนหลังไปยังเดือนมกราคม
//{
//    var currentStockMonth = todayStock.AddMonths(-i);
//    StockMonths.Add(currentStockMonth.ToString("MMM"));

//    var resultStockTotal = AppData.inventoryStockCheckOuts
//     .Count(item => item.InventoryStockCheckOutDate.HasValue &&
//                     item.InventoryStockCheckOutDate.Value.Year == currentStockMonth.Year &&
//                     item.InventoryStockCheckOutDate.Value.Month == currentStockMonth.Month);


//    resultStockMonthlyTotal.Add(resultStockTotal);
//}

//_lineInventoryCheckOutConfig.Data.Labels = StockMonths;
//_lineInventoryCheckOutConfig.Data.Datasets.Add(new LineDataset()
//{
//    Label = "Checkout",
//    Data = resultStockMonthlyTotal.Select(i => (decimal)i).ToList(), // แสดงจำนวนครั้งในการเช็คเอาท์ตามประมาณค่าที่คุณต้องการ
//    BorderColor = Colors.PaletteBorder1.FirstOrDefault(),
//    BackgroundColor = "#20B2AA",
//    Fill = false
//});