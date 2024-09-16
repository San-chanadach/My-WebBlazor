using Microsoft.AspNetCore.Components;
using PSC.Blazor.Components.Chartjs;
using PSC.Blazor.Components.Chartjs.Models.Common;
using PSC.Blazor.Components.Chartjs.Models.Line;
using RapidNRIMs.Model.Instruments;
using RapidNRIMs.Services;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RapidNRIMs.Pages.ComponentBased.IndexDashboardBased
{
    public class PopularInstrumentCheckOutDashboardBase : ComponentBase
    {

        /// <summary>
        /// List Instrument
        /// </summary>
        protected List<InstrumentCheckOut> instrumentCheckOutList = new List<InstrumentCheckOut>();
        
        protected Dictionary<string, int> checkoutCountsByMonth = new Dictionary<string, int>();

        [Inject]
        protected AppData AppData { get; set; }
        [Inject]
        protected HttpClient Http { get; set; }
        [Inject]
        protected IConfiguration Config { get; set; }

        protected int Test { get; set; }

        /// <summary>
        /// Task OnInitializedAsync
        /// </summary>
        /// <returns></returns>
        protected override async Task OnInitializedAsync()
        {

            instrumentCheckOutList = await Http.GetFromJsonAsync<List<InstrumentCheckOut>>($"{Config["nurl"]}/api/GetInstrumentCheckOut");
            if (instrumentCheckOutList != null)
            {
                foreach (var item in instrumentCheckOutList)
                {
                    if (item != null)
                    {
                        item.GetLookUp(AppData.instrumentsList);
                    }
                }

                //// คำนวณวันที่ Today - 12 เดือน
                //DateTime twelveMonthsAgo = DateTime.Today.AddMonths(-12);

                //// กรองรายการที่มี InstrumentCheckOutDate อยู่ในระยะเวลา Today - 12 เดือน
                //var result = instrumentCheckOutList
                //    .Where(x => x != null && x.InstrumentCheckOutDate != null && x.InstrumentCheckOutDate >= twelveMonthsAgo)
                //    .OrderByDescending(x => x.InstrumentCheckOutDate)
                //    .ToList();

                //instrumentCheckOutList = result;
            }




        }

        protected void CalculateInstrumentCheckOutMonthlyTotal()
        {
            // สร้าง List ของเดือนและรายการผลรวมเช็คเอาท์ของแต่ละเดือนและปี
            var today = DateTime.Now;
            var monthsAndTotals = Enumerable.Range(0, 12)
                .Select(i =>
                {
                    var currentMonth = today.AddMonths(-i);
                    var resultTotal = AppData.instrumentCheckOutsList
                        .Count(x => x.InstrumentCheckOutDate.HasValue &&
                                    x.InstrumentCheckOutDate.Value.Year == currentMonth.Year &&
                                    x.InstrumentCheckOutDate.Value.Month == currentMonth.Month);

                    return new { Month = currentMonth.ToString("MMM"), Total = resultTotal, SortKey = currentMonth };
                })
                .OrderBy(item => item.SortKey) // เรียงลำดับตาม SortKey
                .ToList();

          




        }
    }
}
