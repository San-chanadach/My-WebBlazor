using Blazored.Toast.Services;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using RapidNRIMs.Model.Authenications;
using RapidNRIMs.Model.Instruments;
using RapidNRIMs.Model.PersonalDose;
using RapidNRIMs.Services;
using SixLabors.ImageSharp.Formats;
using System;
using System.Globalization;
using System.Text.RegularExpressions;
using Microsoft.AspNetCore.Components.WebAssembly.Services;
using Blazored.LocalStorage;
using RapidNRIMs.Model.Project;
using RapidNRIMs.Model.EventRecord;

namespace RapidNRIMs.Pages.ComponentBased.PersonalDoseBase
{
    public class PersonalDoseSearchAllBase : ComponentBase
    {

        public List<PersonalDose> listPersonalDose = new List<PersonalDose>();
        public List<ProjectSupportTeam> SupportTeam = new List<ProjectSupportTeam>();
        protected List<Account> accounts = new List<Account>();
        public PersonalDose personalDose = new PersonalDose();
        public List<RecordEvent> records = new List<RecordEvent>();

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
        [Inject]
        protected ILocalStorageService LocalStorage { get; set; }


        protected Guid? UserID { get; set; }
        protected int? UserSupportTeamID { get; set; }
        public string inputValueTeam = "";
        public string inputValueSupportTeam = "";
        public string userName { get; set; } = string.Empty;
        public string supportName { get; set; } = string.Empty;
        public List<ProjectSupportTeam> supporteamsuggestions = new List<ProjectSupportTeam>();
        public List<string> teamsuggestions = new List<string>();
        public int supportTeamId { get; set; }
        public Guid? TeamUserId { get; set; }

        [Parameter]
        public string? ParameterUserID { get; set; }

        [Parameter]
        public string? ParameterUserSupportTeamID { get; set; }


        protected override async Task OnInitializedAsync()
        {
            if (ParameterUserID != "00000000-0000-0000-0000-000000000000" && ParameterUserID != null)
            {
                listPersonalDose = await Http.GetFromJsonAsync<List<PersonalDose>>($"{Config["nurl"]}/api/PersonalDoses/UserIdentifier/{ParameterUserID}");
                await jsRuntime.InvokeAsync<object>("ResponsiveDataTables");
            }
            else if (ParameterUserSupportTeamID != "0" && ParameterUserSupportTeamID != null)
            {
                listPersonalDose = await Http.GetFromJsonAsync<List<PersonalDose>>($"{Config["nurl"]}/api/PersonalDoses/UserIdentifier/{ParameterUserSupportTeamID}");
                await jsRuntime.InvokeAsync<object>("ResponsiveDataTables");
            }

            SupportTeam = await Http.GetFromJsonAsync<List<ProjectSupportTeam>>($"{Config["nurl"]}/api/ProjectSupportTeam");
            accounts = await Http.GetFromJsonAsync<List<Account>>($"{Config["aurl"]}/api/GetAccount");
            records = await Http.GetFromJsonAsync<List<RecordEvent>>($"{Config["nurl"]}/api/GetEventRecord"); 
        }



        protected async Task OnsearchDoseUserAll()
        {

            try
            {
               
                // ตั้งค่า UserID เป็น null ก่อนเริ่มการดำเนินการ
                ParameterUserID = null;
                ParameterUserSupportTeamID = null;

                UserID = null;
                UserSupportTeamID = null;

                personalDose.OriginalUserID = personalDose.UserID;
                personalDose.OriginalSupportID = personalDose.UserSupportTeamID;

                var resultUserName = accounts.Find(x => x.FirstName + ' ' + x.LastName == inputValueTeam);
                if (resultUserName != null)
                {
                    UserID = resultUserName.UserID;
                    userName = resultUserName.FirstName + ' ' + resultUserName.LastName;
                    //ToastService.ShowError($"{UserID}");
                }
                var resultSupportName = SupportTeam.Find(x => x.ProjectSupportTeamID == personalDose.UserSupportTeamID);
                if (resultSupportName != null)
                {
                    UserSupportTeamID = resultSupportName.ProjectSupportTeamID;
                    supportName = resultSupportName.Name;
                }

                if (personalDose.UserID != UserID || inputValueTeam != userName || personalDose.UserSupportTeamID != UserSupportTeamID || inputValueSupportTeam != supportName)
                {
                    ToastService.ShowError("This user does not exist.");
                    listPersonalDose = new List<PersonalDose>();
                }
                else
                {
                    if (personalDose.OriginalUserID != null)
                    {
                        // ถ้ามีการเปลี่ยนแปลงใน OriginalUserID ให้กำหนด UserID เป็น null และค้นหา PersonalDose ด้วย OriginalUserID
                        UserID = null;
                        userName = "";
                        listPersonalDose = await Http.GetFromJsonAsync<List<PersonalDose>>($"{Config["nurl"]}/api/PersonalDoses/UserIdentifier/{personalDose.OriginalUserID}");
                        
                    }
                    else if (personalDose.UserSupportTeamID != null)
                    {
                        // ถ้า UserSupportTeamID ไม่เป็น null ให้กำหนด UserID เป็น null และค้นหา PersonalDose ด้วย OriginalSupportID
                        UserID = null;
                        UserSupportTeamID = null;
                        supportName = "";
                        listPersonalDose = await Http.GetFromJsonAsync<List<PersonalDose>>($"{Config["nurl"]}/api/PersonalDoses/UserIdentifier/{personalDose.UserSupportTeamID}");
                        
                    }
                    else
                    {

                        // ถ้าทั้ง UserID และ UserSupportTeamID เป็น null ให้กำหนดทั้ง UserID และ UserSupportTeamID เป็น null และค้นหา PersonalDose ทั้งหมด
                        UserID = null;
                        UserSupportTeamID = null;
                        listPersonalDose = await Http.GetFromJsonAsync<List<PersonalDose>>($"{Config["nurl"]}/api/PersonalDoses/All");


                    }

                    // เช็คว่า listPersonalDose เป็น Array ว่างหรือไม่
                    if (listPersonalDose == null || listPersonalDose.Count == 0)
                    {
                        // แสดง Alert ว่า listPersonalDose ว่าง
                        ToastService.ShowError("This user does not exist.");
                    }
                    else
                    {
                        // ไม่มีเงื่อนไขพิเศษ ให้ดำเนินการต่อไป
                        await jsRuntime.InvokeAsync<object>("ResponsiveDataTables");
                    }
                }
                
                


                // await jsRuntime.InvokeAsync<object>("ResponsiveDataTables");

            }
            catch (Exception e)
            {
                ToastService.ShowError($"Error:{e.Message}");
            }

            
        }


        /// <summary>
        /// User Team
        /// </summary>
        /// <param name="args"></param>
        /// <returns></returns>
        public async Task ChangeUserTeamAutoComplete(ChangeEventArgs args)
        {
            inputValueTeam = args.Value.ToString();
            teamsuggestions.Clear();
            if (!string.IsNullOrEmpty(inputValueTeam))
            {
                teamsuggestions.Clear();
                await Task.Delay(200);
                var autoCompleteTeamValues = await AutoTeamComplete(inputValueTeam);
                teamsuggestions = autoCompleteTeamValues;
            }
            UserID = null;
            personalDose.UserID = null;
 
           

            //listPersonalDose = new List<PersonalDose>();

        }

        /// <summary>
        /// User Tema for OnclickTeamAll
        /// </summary>
        /// <returns></returns>
        public async Task OnclickTeamAll()
        {
            if (string.IsNullOrEmpty(inputValueTeam))
            {
                var autoTeamCompleteAll = await AutoTeamCompleteAll();
                teamsuggestions = autoTeamCompleteAll;

            }

        }

        /// <summary>
        /// User Team AutoTeamComplete
        /// </summary>
        /// <param name="inputValue"></param>
        /// <returns></returns>
        public async Task<List<string>> AutoTeamComplete(string inputTeamValue)
        {

            var responseTeam = await Http.GetFromJsonAsync<List<string>>($"{Config["aurl"]}/api/GetAccount/SearchTeam?query={inputTeamValue}");
            return responseTeam;
        }

        /// <summary>
        /// User Team AutoTeamCompleteAll
        /// </summary>
        /// <returns></returns>
        public async Task<List<string>> AutoTeamCompleteAll()
        {

            var responseTeamAll = await Http.GetFromJsonAsync<List<string>>($"{Config["aurl"]}/api/GetAccount/SearchTeam");
            return responseTeamAll;
        }


        /// <summary>
        /// User Team SelectItemTeam
        /// </summary>
        /// <param name="selectedItem"></param>
        public void SelectItemTeam(string selectedItemTeam)
        {
            inputValueTeam = selectedItemTeam;
            var resultteam = accounts.Find(x => x.FirstName + ' ' + x.LastName == inputValueTeam);
            if (resultteam != null)
            {
                personalDose.UserID = resultteam.UserID;
                //UserID = null;
                //Name = resultteam.FirstName + ' ' + resultteam.LastName;

                ///ToastService.ShowError($"ERR: {Name}");
            }
            
            teamsuggestions.Clear();
            
        }


        /// <summary>
        /// Support Team
        /// </summary>
        /// <param name="args"></param>
        /// <returns></returns>
        public async Task ChangeSupportTeamAutoComplete(ChangeEventArgs args)
        {
            inputValueSupportTeam = args.Value.ToString();
            if (!string.IsNullOrEmpty(inputValueSupportTeam))
            {
                supporteamsuggestions.Clear();
                await Task.Delay(200);
                var autoCompleteSupportTeamValues = await AutoSupportTeamComplete(inputValueSupportTeam);
                supporteamsuggestions = autoCompleteSupportTeamValues;
            }
            UserSupportTeamID = null;
            personalDose.UserSupportTeamID = null;
            personalDose.UserSupportTeamID = 0;
            
        }


        /// <summary>
        /// SupportTema for OnclickSupportAll
        /// </summary>
        /// <returns></returns>
        public async Task OnclickSupportAll()
        {
            if (string.IsNullOrEmpty(inputValueSupportTeam))
            {
                var autoSupportTeamCompleteAll = await AutoSupportTeamCompleteAll();
                supporteamsuggestions = autoSupportTeamCompleteAll;

            }

        }

        /// <summary>
        /// Support Team AutoSupportTeamComplete
        /// </summary>
        /// <param name="inputValue"></param>
        /// <returns></returns>
        public async Task<List<ProjectSupportTeam>> AutoSupportTeamComplete(string inputSupportTeamValue)
        {

            var responseSupport = await Http.GetFromJsonAsync<List<ProjectSupportTeam>>($"{Config["nurl"]}/api/ProjectSupportTeam/SearchSupportTeam?query={inputSupportTeamValue}");
            return responseSupport;
        }

        /// <summary>
        /// Support Team AutoSupportTeamCompleteAll
        /// </summary>
        /// <returns></returns>
        public async Task<List<ProjectSupportTeam>> AutoSupportTeamCompleteAll()
        {

            var responseSupportAll = await Http.GetFromJsonAsync<List<ProjectSupportTeam>>($"{Config["nurl"]}/api/ProjectSupportTeam/SearchSupportTeam");
            return responseSupportAll;
        }


        /// <summary>
        /// Support Team SelectItemSupportTeam
        /// </summary>
        /// <param name="selectedItem"></param>
        public void SelectItemSupportTeam(ProjectSupportTeam selectedItemSupportTeam)
        {
            inputValueSupportTeam = selectedItemSupportTeam.Name;
            personalDose.UserSupportTeamID = selectedItemSupportTeam.ProjectSupportTeamID;
            //ToastService.ShowError($"Error:{personalDose.UserSupportTeamID}");
            supporteamsuggestions.Clear();
            
        }

        protected void OnClearPersonalDose()
        {
            ParameterUserID = null;
            ParameterUserSupportTeamID = null;
            personalDose.UserID = null;
            personalDose.UserSupportTeamID = null;
            UserID = null;
            UserSupportTeamID = null;
            inputValueTeam = "";
            inputValueSupportTeam = "";
            userName = "";
            supportName = "";
            teamsuggestions.Clear();
            supporteamsuggestions.Clear();

            listPersonalDose = new List<PersonalDose>();
        }





        protected void TrClickedAtIndex(Guid? userId, int? userSupportTeamId)
        {
            // ตรวจสอบว่าคลิกที่แถวได้หรือไม่
            if (userId.HasValue || userSupportTeamId.HasValue)
            {
                // ตรวจสอบค่า userId และ userSupportTeamId และดำเนินการตามเงื่อนไข
                if (userId.HasValue && userId != Guid.Empty)
                {
                    // กระทำเมื่อคลิกที่ UserId
                    UserID = userId.Value;
                    UserSupportTeamID = null;
                }
                else if (userSupportTeamId.HasValue && userSupportTeamId != 0)
                {
                    // กระทำเมื่อคลิกที่ UserSupportTeamID
                    UserSupportTeamID = userSupportTeamId.Value;
                    UserID = null;
                }
            }
            else
            {
                // กระทำเมื่อไม่มีการคลิกที่แถว
                // สามารถเพิ่มการกระทำเพิ่มเติมได้ตามต้องการ
                // เช่น การเคลียร์ค่า UserID และ UserSupportTeamID
                UserID = null;
                UserSupportTeamID = null;
            }
        }



        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            if (firstRender)
            {
               // await jsRuntime.InvokeAsync<object>("ResponsiveDataTables");
                await jsRuntime.InvokeVoidAsync("clearURL");
                await jsRuntime.InvokeVoidAsync("addClickSupportHandler");
                await jsRuntime.InvokeVoidAsync("addClickTeamHandler");
            }
        }

    }
}
