using Blazored.Toast.Services;
using BlazorStrap;
using iText.Kernel.Pdf.Canvas.Parser.ClipperLib;
using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Configuration;
using Microsoft.JSInterop;
using RapidNRIMs.Model.Authenications;
using RapidNRIMs.Model.EventRecord;
using RapidNRIMs.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace RapidNRIMs.Pages.ComponentBased.RecordBased
{
    public class ProjectSearchBase : ComponentBase
    {
        protected List<RecordProject> recordProjects = new List<RecordProject>();
        protected List<RecordProject> FilteredrecordProjects = new List<RecordProject>();
        protected IEnumerable<RecordProject> listLimitRecordEvent;
        protected List<Account> accounts = new List<Account>();
        protected RecordProject recordProject = new RecordProject 
        { 
                ProjectNumber = ""
        };

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
        protected IMasterData _masterData { get; set; }
        [Inject]
        protected HttpClient Http { get; set; }
        [Inject]
        protected IConfiguration Config { get; set; }
        [Inject]
        protected IMasterDataPhase2 _masterDataPhase2 { get; set; }


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
                //recordProjects = AppData.recordProjects;
                recordProjects = await _masterData.GetMasterDataAsync<RecordProject>("ProjectRecord");
                accounts = await Http.GetFromJsonAsync<List<Account>>($"{Config["aurl"]}/api/GetAccount");

                SetProjectListlimit();


                 

            }
            catch (Exception e)
            {
                var val = e.Message;
                RequertMessage = val;
            }
        }

        protected void SetProjectListlimit()
        {
            int numberOfrecords = 20;
            var result = recordProjects.OrderByDescending(x => x.ProjectID).Take(numberOfrecords);
            listLimitRecordEvent = result;
        }
        

        protected async Task OnSearch()
        {
          
            await Task.Run(Loading);
            Load.Show();
            recordProjects = await _masterData.GetMasterDataAsync<RecordProject>("ProjectRecord");
            
            try
            {


               
                FilteredrecordProjects = recordProjects.Where(i => i.ProjectNumber.ToString().ToLower().Contains(recordProject.ProjectNumber.ToString().ToLower())).ToList();

                if (recordProject.ProjectRegional != 0 && recordProject.ProjectRegional != null)
                {
                    FilteredrecordProjects = FilteredrecordProjects.Where(i => i.ProjectRegional == recordProject.ProjectRegional).ToList();
                }


                if (recordProject.ProjectType != 0 && recordProject.ProjectType != null)
                {
                    FilteredrecordProjects = FilteredrecordProjects.Where(i => i.ProjectType == recordProject.ProjectType).ToList();

                }

                if (recordProject.ProjectRegisteredBy != null)
                {
                    FilteredrecordProjects = FilteredrecordProjects.Where(i => i.ProjectRegisteredBy == recordProject.ProjectRegisteredBy).ToList();

                }

                if (recordProject.ProjectRecommend != "" && recordProject.ProjectRecommend != null)
                {

                    FilteredrecordProjects = FilteredrecordProjects.Where(i => i.ProjectRecommend == recordProject.ProjectRecommend).ToList();

                }
                this.StateHasChanged();
            }
            catch (Exception e)
            {
                ToastService.ShowError($"Project Search Error:{e.Message}");
            }
            
            Load.Hide();
        }

        protected void Loading()
        {
            System.Threading.Thread.Sleep(300);
            // Retrieve data from the server and initialize
            // Employees property which the View will bind
        }

        protected async Task TrClickedAtIndex(int? id)
        {
            ID = id;
           
        }

        protected void ClearProjectSearch()
        {

            recordProject.ProjectNumber = "";
            recordProject.ProjectRegional = 0;
            recordProject.ProjectType = 0;
            recordProject.ProjectRegisteredBy = null;
            recordProject.ProjectInformerName = "";
            ID = null;
            FilteredrecordProjects = new List<RecordProject>();
        }

        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            if (firstRender)
            {
                await jsRuntime.InvokeVoidAsync("clearURL");
                await jsRuntime.InvokeAsync<object>("ResponsiveDataTables");
                //await jsRuntime.InvokeAsync<object>("exampleTables", "#example");
            }
        }
    }
}
