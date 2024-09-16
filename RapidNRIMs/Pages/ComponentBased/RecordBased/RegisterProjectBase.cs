using Blazored.Toast.Services;
using BlazorStrap;
using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Configuration;
using Microsoft.JSInterop;
using RapidNRIMs.Model.Authenications;
using RapidNRIMs.Model.EventRecord;
using RapidNRIMs.Services;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace RapidNRIMs.Pages.ComponentBased.RecordBased
{
    public class RegisterProjectBase : ComponentBase
    {

        protected List<Account> accounts = new List<Account>();
        protected List<RecordProject> recordProjects = new List<RecordProject>();
        protected RecordProject addProject = new RecordProject();
        
        

        /// <summary>
        /// BSModal
        /// </summary>
        protected BSModal Load { get; set; }
        protected BSModal ModalResponseError { get; set; }
        protected BSModal ModalRespondSuccess { get; set; }

        /// <summary>
        /// Variable
        /// </summary>
        protected string RequertMessage;

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


        /// <summary>
        /// OnInitializedAsync
        /// </summary>
        /// <returns></returns>
        protected override async Task OnInitializedAsync()
        {
            try
            {
                AppData.recordProjects = await _masterData.GetMasterDataAsync<RecordProject>("ProjectRecord");
                accounts = await Http.GetFromJsonAsync<List<Account>>($"{Config["aurl"]}/api/GetAccount");
            }
            catch (Exception e)
            {
                var val = e.Message;
                RequertMessage = val;
            }
        }


        /// <summary>
        /// SaveCreateProject
        /// </summary>
        protected async Task SaveCreateProject()
        {
            try
            {
                if (addProject.ProjectEndDate.Date >= addProject.ProjectStartDate.Date)
                {
                    this.addProject.ProjectRegisteredDate = DateTime.Today;
                    this.addProject.ProjectInsStatusID = 1;
                    this.addProject.ProjectInvsStatusID = 1;
                    var respond = await _masterData.PostMasterDataAsync("PostProjectRecord", addProject);
                    if (!string.IsNullOrEmpty(respond.ToString()))
                    {
                        var requertException = respond.StatusMessage;
                        RequertMessage = requertException;
                        await OnInitializedAsync();
                        this.addProject.ProjectID = respond.ProjectID;
                        this.addProject.ProjectNumber = respond.ProjectNumber;
                        ModalRespondSuccess.Show();


                    }
                    else
                    {
                        var requertException = respond.Content;
                        RequertMessage = requertException;
                        ModalResponseError.Show();
                    }
                }
                else
                {
                    ToastService.ShowError("End date must be greater than start date");
                }

                

            }
            catch (Exception e)
            {
                var val = e.Message;
                RequertMessage = val;
                ModalResponseError.Show();
            }
        }

        protected void ClearRegisterProject()
        {

            addProject = new RecordProject
            {
                ProjectRegional = 0,
                ProjectType = 0,
                ProjectRegisteredBy = null
            };
            
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
