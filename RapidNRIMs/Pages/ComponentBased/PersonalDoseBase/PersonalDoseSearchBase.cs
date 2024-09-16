using Blazored.Toast.Services;
using ICU4N.Util;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using RapidNRIMs.Model.Authenications;
using RapidNRIMs.Model.Instruments;
using RapidNRIMs.Model.PersonalDose;
using RapidNRIMs.Model.Project;
using RapidNRIMs.Services;
using SixLabors.ImageSharp.Formats;
using System;
using System.Collections;
using System.Globalization;
using System.Text.RegularExpressions;

namespace RapidNRIMs.Pages.ComponentBased.PersonalDoseBase
{
    public class PersonalDoseSearchBase : ComponentBase
    {
        protected List<PersonalDose> listPersonalDose = new List<PersonalDose>();
        protected List<PersonalDose> listPersonalDoseByUser = new List<PersonalDose>();
        protected List<Account> accounts = new List<Account>();
        protected PersonalDose personalDose = new PersonalDose();
        protected List<InstrumentLocation> listInstrumentLocation = new List<InstrumentLocation>();
        public List<ProjectSupportTeam> SupportTeam = new List<ProjectSupportTeam>();

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


        public bool IsChack { get; set; } = false;
        public string dateT { get; set; } = string.Empty;
        public string dateET { get; set; } = string.Empty;
        public string StartDate { get; set; } = string.Empty;
        public string EndDate { get; set; } = string.Empty;

        [Parameter]
        public string? UserID { get; set; }

        [Parameter]
        public string? UserSupportTeamID { get; set; }


        public DateTime date { get; set; }
        public DateTime dateEnd { get; set; }
        public DateTime UserStartAll {  get; set; } 
        public DateTime UserEndAll { get; set; }
        public DateTime SupportStartAll { get; set; }
        public DateTime SupportEndAll { get; set; }
        public string formattedStartDate { get; set; } = string.Empty; 

        protected override async Task OnInitializedAsync()
        {
            //if (serID != null)
            //{
            //    var result = await Http.GetFromJsonAsync<List<PersonalDose>>($"{Config["nurl"]}/api/PersonalDoses/UserID/{userID}");
            //    if (result != null)
            //    {
            //        personalDose = result.First();
            //    }
            //}
           
            accounts = await Http.GetFromJsonAsync<List<Account>>($"{Config["aurl"]}/api/GetAccount");
            SupportTeam = await Http.GetFromJsonAsync<List<ProjectSupportTeam>>($"{Config["nurl"]}/api/ProjectSupportTeam");
            listInstrumentLocation = AppData.instrumentLocations;
            
        }

        protected async Task SearchDoseByUserAll()
        {
            if (UserID != "00000000-0000-0000-0000-000000000000")
            {
                listPersonalDose = await Http.GetFromJsonAsync<List<PersonalDose>>($"{Config["nurl"]}/api/PersonalDoses/UserIdentifier/{UserID}");
                // เลือกค่าวันแรกของ StartDatetime จาก listPersonalDose และเก็บไว้ใน StartAll
                UserStartAll = listPersonalDose.OrderBy(x => x.StartDatetime).FirstOrDefault().StartDatetime;

                // เลือกค่าวันสุดท้ายของ EndDatetime จาก listPersonalDose และเก็บไว้ใน EndAll
                UserEndAll = listPersonalDose.OrderByDescending(x => x.EndDatetime).FirstOrDefault().EndDatetime;
            }
            else
            {
                listPersonalDose = await Http.GetFromJsonAsync<List<PersonalDose>>($"{Config["nurl"]}/api/PersonalDoses/UserIdentifier/{UserSupportTeamID}");
                // เลือกค่าวันแรกของ StartDatetime จาก listPersonalDose และเก็บไว้ใน StartAll
                UserStartAll = listPersonalDose.OrderBy(x => x.StartDatetime).FirstOrDefault().StartDatetime;

                // เลือกค่าวันสุดท้ายของ EndDatetime จาก listPersonalDose และเก็บไว้ใน EndAll
                UserEndAll = listPersonalDose.OrderByDescending(x => x.EndDatetime).FirstOrDefault().EndDatetime;
            }
            //listPersonalDose = await Http.GetFromJsonAsync<List<PersonalDose>>($"{Config["nurl"]}/api/PersonalDoses/UserID{UserID}"); 
        }

        protected async Task SearchDoseByUserDate()
        {
            
            if (StartDate != "")
            {
                personalDose.StartDatetime = DateTime.ParseExact(StartDate, "dd/MM/yyyy", CultureInfo.InvariantCulture);
            }

            if (EndDate != "")
            {
                personalDose.EndDatetime = DateTime.ParseExact(EndDate, "dd/MM/yyyy", CultureInfo.InvariantCulture);

            }

            if (UserID != "00000000-0000-0000-0000-000000000000")
            {
                var result = await Http.GetFromJsonAsync<List<PersonalDose>>($"{Config["nurl"]}/api/PersonalDoses/ByDate/{UserID}/{personalDose.StartDatetime.Date.ToString("yyyy-MM-dd")}/{personalDose.EndDatetime.Date.ToString("yyyy-MM-dd")}");
                if (result != null)
                {
                    listPersonalDoseByUser = result;
                }
                else
                {
                    ToastService.ShowError($"Error");
                }
            }
            else
            {
                var result = await Http.GetFromJsonAsync<List<PersonalDose>>($"{Config["nurl"]}/api/PersonalDoses/ByDate/{UserSupportTeamID}/{personalDose.StartDatetime.Date.ToString("yyyy-MM-dd")}/{personalDose.EndDatetime.Date.ToString("yyyy-MM-dd")}");
                if (result != null)
                {
                    listPersonalDoseByUser = result;
                }
                else
                {
                    ToastService.ShowError($"Error");
                }
            }
            

        }

        public void CheckBox()
        {

            IsChack = !IsChack;
            listPersonalDoseByUser.Clear();


            listPersonalDose.Clear();

        }

        public void ClearPersonalDose()
        {
            // StartDate = "";
            // EndDate = "";
            personalDose.StartDatetime = DateTime.Now;
            personalDose.EndDatetime = DateTime.Now;    
            
            listPersonalDoseByUser.Clear();
           
           
             listPersonalDose.Clear();
           
           
            IsChack = false;
            StateHasChanged();

        }

        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            
            if (firstRender)
            {
                //await jsRuntime.InvokeVoidAsync("InitDatePicker", startDatePicker, DotNetObjectReference.Create(this));
                //await jsRuntime.InvokeVoidAsync("InitDateEndPicker", endDatePicker, DotNetObjectReference.Create(this));
                await jsRuntime.InvokeVoidAsync("clearURL");
            }
            
            
        }


        public ElementReference startDatePicker;
        public ElementReference endDatePicker;

        
        

        [JSInvokable]
        public Task SetSelectedDate(string formattedDate)
        {

            StartDate = formattedDate;
            StateHasChanged(); // อัพเดท UI
            return Task.CompletedTask;
        }

        [JSInvokable]
        public Task SetSelectedDateEnd(string formattedDateEnd)
        {
            EndDate = formattedDateEnd;
            StateHasChanged(); // อัพเดท UI
            return Task.CompletedTask;
        }




        

        public async Task Save()
        {
            if (dateT != "")
            {
                date = DateTime.ParseExact(dateT, "dd/MM/yyyy", CultureInfo.InvariantCulture);
                ToastService.ShowError($"ERR: {date.ToShortDateString()}");
            }
           
            if (dateET != "")
            {
                dateEnd = DateTime.ParseExact(dateET, "dd/MM/yyyy", CultureInfo.InvariantCulture);
                ToastService.ShowError($"ERR: {dateEnd.ToShortDateString()}");
            }
            
        }

        public async Task ShowDatePicker()
        {
            if (IsChack)
            {
                await jsRuntime.InvokeVoidAsync("InitDatePicker", startDatePicker, DotNetObjectReference.Create(this));
                await jsRuntime.InvokeVoidAsync("InitDateEndPicker", endDatePicker, DotNetObjectReference.Create(this));
            }
        }

        


    }
}
