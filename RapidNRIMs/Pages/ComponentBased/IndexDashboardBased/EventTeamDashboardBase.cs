using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Configuration;
using Microsoft.JSInterop;
using RapidNRIMs.Model;
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
    public class EventTeamDashboardBase : ComponentBase
    {
        /// <summary>
        /// List Record
        /// </summary>
        protected List<RecordEvent> recordEvents = new List<RecordEvent>();
        protected List<RecordEventProvince> recordEventProvinces = new List<RecordEventProvince>();
        protected List<RecordEventDistrict> recordEventDistricts = new List<RecordEventDistrict>();
        protected List<EventResult> eventResults = new List<EventResult>();
        protected List<SubDistrict> subDistricts = new List<SubDistrict>();
        protected List<RecordEventTeam> teams = new List<RecordEventTeam>();
        protected List<Account> accounts = new List<Account>();

        protected EventResult eventResult = new EventResult();
        protected List<ProjectEventRecord> projectEventRecords = new List<ProjectEventRecord>();
        protected List<RecordProject> recordProjects = new List<RecordProject>();
        protected List<RecordProjectType> recordProjectTypes = new List<RecordProjectType>();
        protected List<RecordRegional> recordRegionals = new List<RecordRegional>();    
        protected List<ProjectTeam> projectTeams = new List<ProjectTeam>();
        protected List<ProjectSupportTeam> projectSupportTeams = new List<ProjectSupportTeam>();

        [Inject]
        protected AppData AppData { get; set; }
        [Inject]
        protected HttpClient Http { get; set; }
        [Inject]
        protected IJSRuntime jsRuntime { get; set; }
        [Inject]
        protected IMasterData masterData { get; set; }
        [Inject]
        protected IConfiguration config { get; set; }

        protected string FullName { get; set; }

        protected Guid? USERID { get; set; }

        /// <summary>
        /// Task OnInitializedAsync
        /// </summary>
        /// <returns></returns>
        protected override async Task OnInitializedAsync()
        {
            recordEventProvinces = AppData.Provinces;
            recordEventDistricts = AppData.Districts;
            subDistricts = AppData.subDistricts;
            recordProjects = AppData.recordProjects;
            recordProjectTypes = AppData.recordProjectTypes;
            recordRegionals = AppData.recordRegionals;
            


            recordEvents = await Http.GetFromJsonAsync<List<RecordEvent>>($"{config["nurl"]}/api/GetEventRecord");
            //var result = recordEvents.OrderByDescending(x => x.EventNumber).ToList();
            //recordEvents = result;

            teams = await Http.GetFromJsonAsync<List<RecordEventTeam>>($"{config["nurl"]}/api/GetEventTeam");

            accounts = await Http.GetFromJsonAsync<List<Account>>($"{config["aurl"]}/api/GetAccount");

            AppData.recordEventUnits = await masterData.GetMasterDataAsync<RecordEventUnit>("RecordEventUnit");

            eventResults = await masterData.GetMasterDataAsync<EventResult>("EventResultAll");

            projectEventRecords = await Http.GetFromJsonAsync<List<ProjectEventRecord>>($"{config["nurl"]}/api/GetProjectEventRecord");

            projectTeams = await Http.GetFromJsonAsync<List<ProjectTeam>>($"{config["nurl"]}/api/GetProjectTeam");

            projectSupportTeams = await Http.GetFromJsonAsync<List<ProjectSupportTeam>>($"{config["nurl"]}/api/ProjectSupportTeam");

            //await jsRuntime.InvokeAsync<object>("ShowTextTeam");


        }



        protected async void ShowNameTeamEvent(Guid? userid)
        {
            var result = accounts.Find(x => x.UserID == userid);
           
            if (result != null)
            {

                await Alert(result.FirstName + " " + result.LastName);
            }
           

        }

        // โค้ดสำหรับแสดงชื่อ supportTeam
        protected async void ShowSupportTeamNameEvent(int supportTeamID)
        {
            var result = projectSupportTeams.Find(x => x.ProjectSupportTeamID == supportTeamID);

            if (result != null)
            {
                await Alert(result.Name);
            }
        }

        //        protected async void ShowNameTeamEvent(Guid? userid)
        //{
        //    var result = accounts.Find(x => x.UserID == userid);

        //    int userIdAsInt = userid.HasValue ? userid.Value.GetHashCode() : 0;

        //    var resultSupport = projectSupportTeams.Find(x => x.ProjectSupportTeamID == userIdAsInt);

        //    if (result != null)
        //    {
        //        await Alert(result.FirstName + " " + result.LastName);
        //    }
        //    else if(resultSupport != null)
        //    {
        //        await Alert(resultSupport.Name);
        //    }
        //}


        //protected void TrClickedAtIndex(Guid? userId, int? userSupportTeamId)
        //{
        //    // ตรวจสอบว่าคลิกที่แถวได้หรือไม่
        //    if (userId.HasValue || userSupportTeamId.HasValue)
        //    {
        //        // ตรวจสอบค่า userId และ userSupportTeamId และดำเนินการตามเงื่อนไข
        //        if (userId.HasValue && userId != Guid.Empty)
        //        {
        //            // กระทำเมื่อคลิกที่ UserId
        //            UserID = userId.Value;
        //            UserSupportTeamID = null;
        //        }
        //        else if (userSupportTeamId.HasValue && userSupportTeamId != 0)
        //        {
        //            // กระทำเมื่อคลิกที่ UserSupportTeamID
        //            UserSupportTeamID = userSupportTeamId.Value;
        //            UserID = null;
        //        }
        //    }
        //    else
        //    {
        //        // กระทำเมื่อไม่มีการคลิกที่แถว
        //        // สามารถเพิ่มการกระทำเพิ่มเติมได้ตามต้องการ
        //        // เช่น การเคลียร์ค่า UserID และ UserSupportTeamID
        //        UserID = null;
        //        UserSupportTeamID = null;
        //    }
        //}

        protected async Task Alert(string Message)
        {
            await jsRuntime.InvokeAsync<object>("ShowNameTeamEvent", Message);
        }
    }
}
