using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Configuration;
using RapidNRIMs.Model.Authenications;
using RapidNRIMs.Model.Securitys;
using RapidNRIMs.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace RapidNRIMs.Pages.ComponentBased.IndexDashboardBased
{
    public class OperationalStaffDashboardBase : ComponentBase
    {

        protected List<Scheduler> schedulerlist = new List<Scheduler>();
        protected List<ScheduleType> scheduleTypes = new List<ScheduleType>();
        protected List<Account> accounts = new List<Account>();

        /// <summary>
        /// วันที่ 1-31 ของเดือน/ปีปัจจุบัน
        /// </summary>
        //DateTime startTable = new DateTime(DateTime.Today.Year, DateTime.Today.Month, 1);
        //DateTime endTable = new DateTime(DateTime.Today.Year, DateTime.Today.Month, DateTime.DaysInMonth(DateTime.Today.Year, DateTime.Today.Month));
        
        protected DateTime startTable = new DateTime(2021, 12, 13);
        protected DateTime endTable = new DateTime(2021, 12, 17);

        [Inject]
        protected AppData AppData { get; set; }
        [Inject]
        protected HttpClient httpClient { get; set; }
        [Inject]
        protected IConfiguration configuration { get; set; }


        protected override async Task OnInitializedAsync()
        {
            accounts = await httpClient.GetFromJsonAsync<List<Account>>($"{configuration["aurl"]}/api/GetAccount");
            scheduleTypes = await httpClient.GetFromJsonAsync<List<ScheduleType>>($"{configuration["aurl"]}/api/GetScheduleType");
            schedulerlist = await httpClient.GetFromJsonAsync<List<Scheduler>>($"{configuration["aurl"]}/api/GetOperationalStaff");
            foreach (var i in schedulerlist)
            {
                i.GetLookup(accounts, scheduleTypes);
            }
        }
    }
}
