using Blazored.Toast.Services;
using BlazorStrap;
using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Configuration;
using Microsoft.JSInterop;
using RapidNRIMs.Model.Authenications;
using RapidNRIMs.Model.EventRecord;
using RapidNRIMs.Model.Project;
using RapidNRIMs.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace RapidNRIMs.Pages.ComponentBased.IndexDashboardBased
{
    public class ShowDetailEventResultBase : ComponentBase
    {
        /// <summary>
        /// List Record
        /// </summary>
        protected List<EventResult> eventResults = new List<EventResult>();
        protected List<RecordEventUnit> recordEventUnits = new List<RecordEventUnit>();
        protected List<Account> accounts = new List<Account>();
        protected List<ProjectEventRecord> projectEventRecords = new List<ProjectEventRecord>();
        protected List<RecordProject> recordProjects = new List<RecordProject>();    

        protected List<RecordEvent> recordEvents = new List<RecordEvent>();
        protected List<RecordEventProvince> recordEventProvinces = new List<RecordEventProvince>();
        protected List<RecordEventDistrict> recordEventDistricts = new List<RecordEventDistrict>();
        protected List<SubDistrict> subDistricts = new List<SubDistrict>();
        protected List<ProjectPersonalDose> projectPersonalDoses = new List<ProjectPersonalDose>();
        protected List<EventPersonalDose> eventPersonalDoses = new List<EventPersonalDose>();
        protected List<EventSumPersonalDose> eventSumPersonalDoses = new List<EventSumPersonalDose>();  

        [Inject]
        protected AppData AppData { get; set; }
        [Inject]
        protected HttpClient Http { get; set; }
        [Inject]
        protected IJSRuntime jsRuntime { get; set; }
        [Inject]
        protected IConfiguration configuration { get; set; }
        [Inject]
        protected IMasterData masterData { get; set; }
        [Inject]
        protected IToastService ToastService { get; set; }

        [Parameter]
        public string EventResultID { get; set; }

        [Parameter]
        public string ProjectID { get; set; }

        protected bool hasData = false;

        protected bool hasDataPersonalDose = false; 

        /// <summary>
        /// Task OnInitializedAsync
        /// </summary>
        /// <returns></returns>
        protected override async Task OnInitializedAsync()
        {

            // await Task.Delay(300); // 3000 milliseconds = 3 seconds
            try
            {
                recordEventUnits = AppData.recordEventUnits;

                accounts = await Http.GetFromJsonAsync<List<Account>>($"{configuration["aurl"]}/api/GetAccount");

                projectEventRecords = await Http.GetFromJsonAsync<List<ProjectEventRecord>>($"{configuration["nurl"]}/api/GetProjectEventRecord");

                eventResults = await masterData.GetMasterDataAsync<EventResult>("EventResultAll");

                recordEventProvinces = AppData.Provinces;
                recordEventDistricts = AppData.Districts;
                subDistricts = AppData.subDistricts;

                recordEvents = await Http.GetFromJsonAsync<List<RecordEvent>>($"{configuration["nurl"]}/api/GetEventRecord");

                //projectPersonalDoses = await Http.GetFromJsonAsync<List<ProjectPersonalDose>>($"{configuration["nurl"]}/api/GetProjectPersonalDose");

                recordProjects = AppData.recordProjects;

                eventPersonalDoses = await Http.GetFromJsonAsync<List<EventPersonalDose>>($"{configuration["nurl"]}/api/GetEventPersonalDose");

                eventSumPersonalDoses = await Http.GetFromJsonAsync<List<EventSumPersonalDose>>($"{configuration["nurl"]}/api/GetEventSumPersonalDose/{int.Parse(ProjectID)}");

            }
            catch (Exception e)
            {
                ToastService.ShowError($"ERR: {e.Message}");
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

    }
}
