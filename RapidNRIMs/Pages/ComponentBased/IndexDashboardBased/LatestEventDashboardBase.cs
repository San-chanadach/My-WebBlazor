using BlazorStrap;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using RapidNRIMs.Model.EventRecord;
using RapidNRIMs.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace RapidNRIMs.Pages.ComponentBased.IndexDashboardBased
{
    public class LatestEventDashboardBase : ComponentBase
    {
        /// <summary>
        /// List Record
        /// </summary>
        protected List<RecordProject> recordProjects = new List<RecordProject>();
        protected List<RecordEvent> recordEvents = new List<RecordEvent>();
        protected List<EventResult> eventResults = new List<EventResult>(); 
        protected List<RecordEventType> recordEventTypes = new List<RecordEventType>();
        protected List<RecordEventProvince> recordEventProvinces = new List<RecordEventProvince>();
        protected List<RecordEventDistrict> recordEventDistricts = new List<RecordEventDistrict>();
        protected List<SubDistrict> subDistricts = new List<SubDistrict>();
        protected List<ProjectEventRecord> projectEventRecords = new List<ProjectEventRecord>();

        /// <summary>
        /// Single Record 
        /// </summary>
        public RecordProject recordProject = new RecordProject();
        public RecordEvent record = new RecordEvent();
        protected string Page { get; set; }

        protected BSModal Load { get; set; }

        [Inject]
        protected AppData AppData { get; set; }
        [Inject]
        protected HttpClient Http { get; set; }
        [Inject]
        protected IMasterDataRecord _masterDataRecord { get; set; }
        [Inject]
        protected IJSRuntime jsRuntime { get; set; }
        [Inject]
        protected IMasterData _masterData { get; set; }
        [Inject]
        protected NavigationManager _navigationManager { get; set; }
        [Inject]
        protected IConfiguration config { get; set; }


        protected override async Task OnInitializedAsync()
        {
            recordEventProvinces = AppData.Provinces;
            recordEventTypes = AppData.recordEventTypes;
            recordEventDistricts = AppData.Districts;
            subDistricts = AppData.subDistricts;
            recordProjects = AppData.recordProjects;
           
            recordEvents = await Http.GetFromJsonAsync<List<RecordEvent>>($"{config["nurl"]}/api/GetEventRecord");
            projectEventRecords = await Http.GetFromJsonAsync<List<ProjectEventRecord>>($"{config["nurl"]}/api/GetProjectEventRecord");

            Load.Show();
            await Task.Run(Loading);
            var result = recordEvents.OrderByDescending(x => x.EventID).ToList();
            record = result.First();
            eventResults = await _masterDataRecord.GetEventResult<EventResult>("EventResult", record.EventID);
            int numberEventResult = 5;
            var resultEventResult = eventResults.OrderByDescending(x => x.eventResultID).Take(numberEventResult);
            eventResults = resultEventResult.ToList();


            var resultProjectEventRecord = projectEventRecords.Find(x => x.EventID == record.EventID);
            if (resultProjectEventRecord != null)
            {
                var resultRecordProject = recordProjects.Find(x => x.ProjectID == resultProjectEventRecord.ProjectID);
                recordProject = resultRecordProject;
            }
            
            Load.Hide();

            
        }

        public void OnManageRe()
        {
            //Page = page;
            Page = "/";
            _navigationManager.NavigateTo($"/Record/ManageEvent/{record.EventNumber}/{recordProject.ProjectID}");

        }

        /// <summary>
        /// Task OnAfterRenderAsync ChartJS
        /// </summary>
        /// <param name="firstRender"></param>
        /// <returns></returns>
        protected async override Task OnAfterRenderAsync(bool firstRender)
        {
            if (firstRender)
            {
                await jsRuntime.InvokeAsync<object>("initializeCarousel");
                firstRender = false;
            }
        }

        private void Loading()
        {
            System.Threading.Thread.Sleep(300);
            // Retrieve data from the server and initialize
            // Employees property which the View will bind
        }
    }

}
