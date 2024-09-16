using Blazored.Toast.Services;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using RapidNRIMs.Model.Authenications;
using RapidNRIMs.Model.Instruments;
using RapidNRIMs.Model.PersonalDose;
using RapidNRIMs.Model.Project;
using RapidNRIMs.Services;
using System;
using System.Globalization;
using System.Net.Http;
using System.Text.RegularExpressions;

namespace RapidNRIMs.Pages.ComponentBased.PersonalDoseBase
{
    public class PersonalDoseBase : ComponentBase
    {
        public List<PersonalDose> listPersonalDose = new List<PersonalDose>();
        protected List<Account> accounts = new List<Account>();
        public List<InstrumentLocation> listInstrumentLocation = new List<InstrumentLocation>();
        public List<ProjectSupportTeam> SupportTeam = new List<ProjectSupportTeam>();
        public List<ProjectSupportTeam> SearchSupportTeam = new List<ProjectSupportTeam>();

        public PersonalDose personalDose = new PersonalDose();

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
        public string TimeInput { get; set; }
        public string ConvertedStartTime { get; set; } = string.Empty;
        public string ConvertedEndTime { get; set; }
        public string StartDate { get; set; } = string.Empty;
        public string EndDate { get; set; } = string.Empty;
        public string searchKeyword { get; set; } = string.Empty;
        public string searchKeywordSupportTeam { get; set; } = string.Empty;
        public string searchKeywordTeam { get; set; } = string.Empty;
        public ElementReference instrumentSelect;
        public List<Instrument> listInstruments = new List<Instrument>();
        public string inputValue = "";
        public string inputValueTeam = "";
        public string inputValueSupportTeam = "";
        public List<ProjectSupportTeam> supporteamsuggestions = new List<ProjectSupportTeam>();
        public List<string> teamsuggestions = new List<string>();
        public List<string> suggestions = new List<string>();
        public int supportTeamId { get; set; }
        public Guid? TeamUserId { get; set; }
        public string instrumentName { get; set; }  

        public DateTime Time_Current { get; set; }
        public DateTime TimeEnd { get; set; }
        public DateTime date { get; set; }
        public DateTime dateEnd { get; set; }
        public string currentDate = DateTime.Now.ToString("yyyy-MM-dd");
        public string currentTime = DateTime.Now.ToString("HH:mm");
        public string TotalHour { get; set; } = string.Empty;
        public int TotalMinutes { get; set; }
        public bool isSaving { get; set; }


        protected override async Task OnInitializedAsync()
        {
            try
            {
                listInstrumentLocation = AppData.instrumentLocations;
                accounts = await Http.GetFromJsonAsync<List<Account>>($"{Config["aurl"]}/api/GetAccount");
                SupportTeam = await Http.GetFromJsonAsync<List<ProjectSupportTeam>>($"{Config["nurl"]}/api/ProjectSupportTeam");
                listPersonalDose = await Http.GetFromJsonAsync<List<PersonalDose>>($"{Config["nurl"]}/api/PersonalDoses/All/{DateTime.Now.ToString("yyyy-MM-dd HH:mm")}");
                
            }
            catch(Exception e) 
            {
                ToastService.ShowError($"ERR: {e.Message}");
            }
        }

        

        /// <summary>
        /// SearchTextBoxInstrument
        /// </summary>
        /// <returns></returns>
        public async Task SearchTextBoxInstrument()
        {

            listInstruments = await Http.GetFromJsonAsync<List<Instrument>>($"{Config["nurl"]}/api/SearchInstrument?query={searchKeyword}");
        }

        public void CheckBox()
        {
            IsChack = !IsChack;
        }

        public async Task ConvertTime(string inputId)
        {
            ConvertedStartTime = await jsRuntime.InvokeAsync<string>("convertTime", inputId);
            if (DateTime.TryParseExact(ConvertedStartTime, "HH:mm", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime convertedStartTime))
            {
                personalDose.StartTime = convertedStartTime;
                //ToastService.ShowError($"ERR: {TimeUtc.TimeOfDay}");
            }



        }

        public async Task ConverTimeEnd(string inputEndId)
        {
            ConvertedEndTime = await jsRuntime.InvokeAsync<string>("convertEndTime", inputEndId);
            if (DateTime.TryParseExact(ConvertedEndTime, "HH:mm", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime convertedEndTime))
            {
                personalDose.EndTime = convertedEndTime;
               // ToastService.ShowError($"ERR: {}");
            }
        }

        public ElementReference startDatePicker;
        public ElementReference endDatePicker;

        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            if (firstRender)
            {
                await jsRuntime.InvokeVoidAsync("InitDatePicker", startDatePicker, DotNetObjectReference.Create(this));
                await jsRuntime.InvokeVoidAsync("InitDateEndPicker", endDatePicker, DotNetObjectReference.Create(this));
                await jsRuntime.InvokeVoidAsync("addClickHandler");
                await jsRuntime.InvokeVoidAsync("addClickSupportHandler");
                await jsRuntime.InvokeVoidAsync("addClickTeamHandler");
            }
        }

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

        public string Name { get; set; } = string.Empty;
        public string supportName { get; set; } = string.Empty;

        public async Task SavePersonalDose()
        {
            try
            {

                var resultUserName = accounts.Find(x => x.FirstName + ' ' + x.LastName == inputValueTeam);
                if (resultUserName != null)
                {
                    Name = resultUserName.FirstName + ' ' + resultUserName.LastName;
                }
                var resultSupportName = SupportTeam.Find(x => x.Name == inputValueSupportTeam);
                if (resultSupportName != null)
                {
                    supportName = resultSupportName.Name;
                }

                if (inputValueTeam != Name || inputValueSupportTeam != supportName)
                {
                    ToastService.ShowError($"User Team or Support Team names do not exist.");
                }
                else
                {
                    if (inputValueTeam == "")
                    {
                        TeamUserId = new Guid("00000000-0000-0000-0000-000000000000");

                    }
                    if (inputValueSupportTeam == "")
                    {
                        supportTeamId = 0;

                    }

                    if (!string.IsNullOrEmpty(StartDate))
                    {
                        personalDose.StartDatetime = DateTime.ParseExact(StartDate, "dd/MM/yyyy", CultureInfo.InvariantCulture);
                    }

                    if (!string.IsNullOrEmpty(EndDate))
                    {
                        personalDose.EndDatetime = DateTime.ParseExact(EndDate, "dd/MM/yyyy", CultureInfo.InvariantCulture);
                    }

                    currentTime = DateTime.Now.ToString("HH:mm");

                    if (DateTime.TryParseExact(currentTime, "HH:mm", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime convertedTime))
                        Time_Current = convertedTime;

                    if (!string.IsNullOrEmpty(currentDate))
                    {
                        personalDose.CreateRegister = DateTime.ParseExact(currentDate, "yyyy-MM-dd", CultureInfo.InvariantCulture);
                    }

                    // Combine date and time
                    DateTime combinedStartDateTime = personalDose.StartDatetime.Date + personalDose.StartTime.TimeOfDay;
                    DateTime combinedEndDateTime = personalDose.EndDatetime.Date + personalDose.EndTime.TimeOfDay;

                    if (combinedEndDateTime < combinedStartDateTime)
                    {
                        ToastService.ShowError("End date/time must be greater than start date/time");
                    }
                    else
                    {
                        // Calculate duration
                        TimeSpan duration = combinedEndDateTime - combinedStartDateTime;

                        // Get total hours and minutes
                        int totalMinutes = (int)Math.Max(duration.TotalMinutes, 0);
                        int totalHours = (int)Math.Floor(duration.TotalHours);
                        int minutes = totalMinutes % 60;

                        // Format the duration
                        string formattedDuration = $"{totalHours} ชั่วโมง {minutes} นาที";
                        personalDose.TotalHour = formattedDuration;


                        //ToastService.ShowInfo($"show {}");  
                        

                        personalDose.StartDatetime = combinedStartDateTime;
                        personalDose.EndDatetime = combinedEndDateTime;
                        personalDose.CreateRegister = personalDose.CreateRegister.Date + Time_Current.TimeOfDay;
                        personalDose.InstrumentName = instrumentName;
                        personalDose.FromProjectPersonalDose = 0;
                        personalDose.FromEventPersonalDose = 0;
                        personalDose.UserID = TeamUserId;
                        personalDose.UserSupportTeamID = supportTeamId;
                        personalDose.DoseAccumulationUnit = 1;

                        var resultPositionTeam = accounts.Find(x => x.UserID == personalDose.UserID) != null ? accounts.Find(x => x.UserID == personalDose.UserID).PositionName:"-";
                        if (TeamUserId != new Guid("00000000-0000-0000-0000-000000000000"))
                        {
                            personalDose.PositionName = resultPositionTeam; 
                            //ToastService.ShowError($"{personalDose.PositionName}");
                        }

                        var reusltPositionSupportTeam = SupportTeam.Find(x => x.ProjectSupportTeamID == personalDose.UserSupportTeamID) != null ? SupportTeam.Find(x => x.ProjectSupportTeamID == personalDose.UserSupportTeamID).Position:"-";
                        if(supportTeamId != 0)
                        {
                            personalDose.PositionName = reusltPositionSupportTeam;
                            //ToastService.ShowError($"{personalDose.PositionName}");
                        }

                        //  ToastService.ShowError($"ERR: {personalDose.UserSupportTeamID}");

                        isSaving = true;
                        var respond = await Http.PostAsJsonAsync($"{Config["nurl"]}/api/PersonalDoses", personalDose);
                        if (respond.StatusCode == System.Net.HttpStatusCode.OK)
                        {
                            ToastService.ShowSuccess("Successfully added Personal Dose");
                            listPersonalDose = await Http.GetFromJsonAsync<List<PersonalDose>>($"{Config["nurl"]}/api/PersonalDoses/All/{DateTime.Now.ToString($"yyyy-MM-dd HH:mm")}");
                            StateHasChanged();
                            await Task.Delay(3000);
                        }
                        else
                        {
                            ToastService.ShowError($"ERR: {respond.StatusCode}");
                        }
                        isSaving = false;

                    }
                    
                    personalDose.UserID = null;
                    personalDose.UserSupportTeamID = 0;
                    personalDose.LocationName = "";
                    personalDose.DoseAccumulation = 0;
                    StartDate = "";
                    EndDate = "";
                    ConvertedStartTime = "";
                    ConvertedEndTime = "";
                    inputValue = "";
                    inputValueTeam = "";
                    inputValueSupportTeam = "";
                    Name = "";
                    teamsuggestions.Clear();
                    supporteamsuggestions.Clear();
                    suggestions.Clear();
                    supportName = "";


                }

                


                

                //if (totalMinutes != 0)
                //{
                //    isSaving = true;

                //    var respond = await Http.PostAsJsonAsync($"{Config["nurl"]}/api/PersonalDoses", personalDose);
                //    if (respond.StatusCode == System.Net.HttpStatusCode.OK)
                //    {
                //        ToastService.ShowSuccess("Successfully added Personal Dose");
                //        listPersonalDose = await Http.GetFromJsonAsync<List<PersonalDose>>($"{Config["nurl"]}/api/PersonalDoses/All/{DateTime.Now.ToString($"yyyy-MM-dd HH:mm")}");
                //        StateHasChanged();
                //        await Task.Delay(3000);
                //    }
                //    else
                //    {
                //        ToastService.ShowError($"ERR: {respond.StatusCode}");
                //    }
                //    isSaving = false;
                //}
                //else
                //{
                //    ToastService.ShowError($"Can't calculate time");
                //}
            }
            catch (Exception e)
            {
                ToastService.ShowError($"ERR: {e.Message}");
                isSaving = false;
            }
            finally
            {
                isSaving = false;
            }
        }


        //public async Task SavePersonalDose()
        //{
        //    try
        //    {
        //        if (StartDate != "")
        //        {
        //            personalDose.StartDatetime = DateTime.ParseExact(StartDate, "dd/MM/yyyy", CultureInfo.InvariantCulture);
        //            //ToastService.ShowError($"ERR: {date.ToShortDateString()}");
        //        }
        //        //ToastService.ShowError($"ERR: {TimeUtc.TimeOfDay}");

        //        if (EndDate != "")
        //        {
        //            personalDose.EndDatetime = DateTime.ParseExact(EndDate, "dd/MM/yyyy", CultureInfo.InvariantCulture);

        //        }

        //        //currentTime = DateTime.Now.ToString("HH:mm");
        //        currentTime = DateTime.Now.ToString("HH:mm");

        //        //condition chang time 24 Hour
        //        if (DateTime.TryParseExact(currentTime, "HH:mm", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime convertedTime))
        //            Time_Current = convertedTime;

        //        if (currentDate != "")
        //        {
        //            personalDose.CreateRegister = DateTime.ParseExact(currentDate, "yyyy-MM-dd", CultureInfo.InvariantCulture);
        //        }

        //        // ใช้ Add เพื่อรวมวันที่และเวลา
        //        DateTime combinedStartDateTime = personalDose.StartDatetime.Date + personalDose.StartTime.TimeOfDay;
        //        DateTime combinedEndDateTime = personalDose.EndDatetime.Date + personalDose.EndTime.TimeOfDay;
        //        DateTime combinedCurrentDateTime = personalDose.CreateRegister.Date + Time_Current.TimeOfDay;

        //        //Calculate Time

        //        TimeSpan? duration = personalDose.EndTime.TimeOfDay - personalDose.StartTime.TimeOfDay;

        //        // Get total minutes
        //        int totalMinutes = (int)Math.Max(duration.Value.TotalMinutes, 0);
        //        TotalMinutes = totalMinutes;
        //        if (TotalMinutes >= 60)
        //        {
        //            // Calculate hours and minutes separately
        //            int hours = totalMinutes / 60;
        //            int minutes = totalMinutes % 60;

        //            // Format the result as "H ชั่วโมง m นาที" (e.g., "1 ชั่วโมง 30 นาที")
        //            string formattedDuration = $"{hours} ชั่วโมง {minutes} นาที";
        //            personalDose.TotalHour = formattedDuration;
        //        }
        //        else
        //        {
        //            // Display the duration in minutes
        //            string formattedDuration = $"{totalMinutes} นาที";
        //            personalDose.TotalHour = formattedDuration;
        //        }





        //        // ตัวอย่างการใช้งาน
        //        personalDose.StartDatetime = combinedStartDateTime;
        //        personalDose.EndDatetime = combinedEndDateTime;
        //        personalDose.CreateRegister = combinedCurrentDateTime;
        //        personalDose.InstrumentID = instrumentId;


        //        //ToastService.ShowError($"ERR: {personalDose.CreateRegister}");
        //        if (TotalMinutes != 0)
        //        {
        //            isSaving = true; // Set the flag to indicate saving is in progress             // Add a delay before re-enabling the button

        //            var respond = await Http.PostAsJsonAsync($"{Config["nurl"]}/api/PersonalDoses", personalDose);
        //            if (respond.StatusCode == System.Net.HttpStatusCode.OK)
        //            {

        //                ToastService.ShowSuccess("Successfully added Personal Dose");
        //                listPersonalDose = await Http.GetFromJsonAsync<List<PersonalDose>>($"{Config["nurl"]}/api/PersonalDoses/All/{DateTime.Now.ToString($"yyyy-MM-dd HH:mm")}");
        //                StateHasChanged();
        //                await Task.Delay(3000); // 3000 milliseconds = 3 seconds


        //            }
        //            else
        //            {
        //                ToastService.ShowError($"ERR: {respond.StatusCode}");
        //            }
        //            isSaving = false;
        //        }
        //        else
        //        {
        //            ToastService.ShowError($"Can't calculate time");
        //        }
        //    }
        //    catch (Exception e)
        //    {

        //        ToastService.ShowError($"ERR: {e.Message}");
        //        isSaving = false; // Reset the flag in case of an exception
        //    }
        //    finally
        //    {
        //        // Ensure the button is enabled in any case
        //        isSaving = false;
        //    }



        //}


        public void ClearPersonalDose()
        {
            personalDose.UserID = null;
            personalDose.UserSupportTeamID = 0;
            personalDose.LocationName = "";
            personalDose.DoseAccumulation = 0;
            StartDate = "";
            EndDate = "";
            ConvertedStartTime = "";
            ConvertedEndTime = "";
            inputValue = "";
            inputValueTeam = "";
            inputValueSupportTeam = "";
            Name = "";
            teamsuggestions.Clear();
            supporteamsuggestions.Clear();
            suggestions.Clear();

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
            var resultteam = accounts.Find(x => x.FirstName +' '+ x.LastName == inputValueTeam);
            if (resultteam != null)
            {
                TeamUserId = resultteam.UserID;
                
                //Name = resultteam.FirstName + ' ' + resultteam.LastName;

                ///ToastService.ShowError($"ERR: {Name}");
            }
            teamsuggestions.Clear();
            Name = "";
           
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
            supportTeamId = selectedItemSupportTeam.ProjectSupportTeamID;

            supporteamsuggestions.Clear();
            supportName = "";
        }


        /// <summary>
        /// Instrument ChangeAutoComplete
        /// </summary>
        /// <param name="args"></param>
        /// <returns></returns>
        public async Task ChangeAutoComplete(ChangeEventArgs args)
        {
            inputValue = args.Value.ToString();
            if (!string.IsNullOrEmpty(inputValue))
            {
                suggestions.Clear();
                await Task.Delay(200);
                var autoCompleteValues = await AutoComplete(inputValue);
                suggestions = autoCompleteValues;
            }
            else
            {
                instrumentName = "";
            }
        }


        /// <summary>
        /// Instrument for OnclickAll
        /// </summary>
        /// <returns></returns>
        public async Task OnclickAll()
        {
            if (string.IsNullOrEmpty(inputValue))
            { 
                var autoCompleteAll = await AutoCompleteAll();
                suggestions = autoCompleteAll;
               // suggestions.AddRange(autoCompleteAll);

            }
            //DateTime re = DateTime.Today + DateTime.Now.TimeOfDay;
            //ToastService.ShowError($"{DateTime.Now}");
            //condition chang time 24 Hour
           


        }


        /// <summary>
        /// Instrument AutoComplete
        /// </summary>
        /// <param name="inputValue"></param>
        /// <returns></returns>
        public async Task<List<string>> AutoComplete(string inputValue)
        {

            var response = await Http.GetFromJsonAsync<List<string>>($"{Config["nurl"]}/api/SearchInstrument?query={inputValue}");
            return response;
        }

        /// <summary>
        /// Instrument AutoCompleteAll
        /// </summary>
        /// <returns></returns>
        public async Task<List<string>> AutoCompleteAll()
        {

            var responseAll = await Http.GetFromJsonAsync<List<string>>($"{Config["nurl"]}/api/SearchInstrument");
            return responseAll;
        }

        public void SelectItem(string selectedItem)
        {
            inputValue = selectedItem;
            var result = AppData.instrumentsList.Find(x => x.InstrumentENName == inputValue);
            if (result != null)
            {
                instrumentName = result.InstrumentENName;
                
            }
            suggestions.Clear();
        }
    }
}



//public void ConvertTime(ChangeEventArgs e)
//{
//    var inputTime = e.Value.ToString();

//    // ถ้าไม่ใช่ตัวเลขหรือไม่ใช่ตัวเลข 4 ตัว ให้เคลียร์ textbox และป้องกันเหตุการณ์ต่อไป
//    if (!Regex.IsMatch(inputTime, @"^\d{4}$"))
//    {
//        ToastService.ShowError("Please enter numbers only.");
//        TimeInput = string.Empty; // เคลียร์ Textbox
//        return;
//    }

//    var hours = inputTime.Substring(0, 2);
//    var minutes = inputTime.Substring(2, 2);

//    // ถ้าชั่วโมงมากกว่า 23 หรือนาทีมากกว่า 59 ให้แสดงข้อความแจ้งเตือน
//    if (int.Parse(hours) > 23 || int.Parse(minutes) > 59)
//    {
//        ToastService.ShowError("Please fill in the correct time (e.g., time 13:00 is 1300).");
//        TimeInput = string.Empty; // เคลียร์ Textbox
//        return;
//    }

//    TimeInput = $"{hours}:{minutes}";

//}
