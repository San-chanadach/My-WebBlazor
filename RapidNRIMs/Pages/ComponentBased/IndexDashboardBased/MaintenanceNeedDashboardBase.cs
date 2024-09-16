using Microsoft.AspNetCore.Components;
using PSC.Blazor.Components.Chartjs;
using PSC.Blazor.Components.Chartjs.Models.Common;
using PSC.Blazor.Components.Chartjs.Models.Line;
using RapidNRIMs.Services;
using System.Collections.Generic;
using System.Linq;

namespace RapidNRIMs.Pages.ComponentBased.IndexDashboardBased
{
    public class MaintenanceNeedDashboardBase : ComponentBase
    {
        [Inject]
        protected AppData AppData { get; set; }

        /// <summary>
        /// Task OnInitializedAsync
        /// </summary>
        /// <returns></returns>
        protected override void OnInitialized()
        {

            var result = AppData.DueMa.OrderByDescending(x => x.InstrumentMaintenanceNext).ToList();
            AppData.DueMa = result;


        }
    }
}
