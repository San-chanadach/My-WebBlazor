using Blazored.Toast.Services;
using BlazorStrap;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using RapidNRIMs.Model.Authenications;
using RapidNRIMs.Model.EventRecord;
using RapidNRIMs.Model.Instruments;
using RapidNRIMs.Model.Inventories;
using RapidNRIMs.Model.Project;
using Instrument = RapidNRIMs.Model.Instruments.Instrument;
using RapidNRIMs.Services;
using System.Diagnostics.Metrics;
using System.Net;
using RapidNRIMs.Pages.Instruments;
using static System.Net.WebRequestMethods;
using RapidNRIMs.Model.PersonalDose;
using System;
using System.Globalization;
using RapidNRIMs.Model.Authencations;
using Microsoft.AspNetCore.Components.Web;
using System.Text;

namespace RapidNRIMs.Pages.ComponentBased.RecordBased
{
    public class ManageProjectBase : ComponentBase
    {
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

        public int select;
        public string zipCode = "";
        public string number;
        public int? Regoinal;
        public Guid? userID;//กำหนดค่าให้เป็น null ป้องกันไม่ให้ขึ้น reload
        public int? Remaining { get; set; }
        public string currentDate { get; set; }
        public string currentTime { get; set; }
        public DateTime Time_Current { get; set; }

        public RecordEvent recordEvent = new RecordEvent();
        public RecordRegional recordRegional = new RecordRegional();
        public ProjectEventRecord projectEventRecord = new ProjectEventRecord();
        protected RecordProject recordProject = new RecordProject();
        protected RecordProject updateProject = new RecordProject();
        public ProjectTeam addTeam = new ProjectTeam();
        public ProjectSupportTeam addSupportTeam = new ProjectSupportTeam();
        public ProjectPersonalDose addProjectPersonalDose = new ProjectPersonalDose();
        public ProjectPersonalDose editProjectPersonalDose = new ProjectPersonalDose();
        public ProjectInstrument projectInstrument = new ProjectInstrument();
        public ProjectInventoryStock projectInventoryStock = new ProjectInventoryStock();
        public ProjectInventoryStock editProjectInventoryStock = new ProjectInventoryStock();
        public Instrument instrument = new Instrument();
        public InventoryStock inventoryStock = new InventoryStock();
        public Account account = new Account();




        public List<ProjectEventRecord> listprojectEventRecord = new List<ProjectEventRecord>();
        public List<ProjectEventRecord> conditionProjectEvetnRecord = new List<ProjectEventRecord>();
        public List<RecordRegional> listrecordRegional = new List<RecordRegional>();
        public List<RecordEvent> recordEvents = new List<RecordEvent>();
        public List<RecordEvent> listRecordEvent = new List<RecordEvent>();
        public List<RecordEventType> recordEventTypes = new List<RecordEventType>();
        public List<RecordEventProvince> recordEventProvinces = new List<RecordEventProvince>();
        public List<RecordEventDistrict> recordEventDistricts = new List<RecordEventDistrict>();
        public List<SubDistrict> subDistricts = new List<SubDistrict>();
        protected List<Account> accounts = new List<Account>();
        public List<ProjectTeam> teams = new List<ProjectTeam>();
        public List<ProjectSupportTeam> SupportTeam = new List<ProjectSupportTeam>();
        public List<ProjectInstrument> projectInstruments = new List<ProjectInstrument>();
        public List<ProjectPersonalDose> projectPersonalDoses = new List<ProjectPersonalDose>();
        public List<Instrument> listInstrument = new List<Instrument>();
        public List<ProjectInventoryStock> projectInventoryStocks = new List<ProjectInventoryStock>();
        public List<InventoryStock> listInventoryStock = new List<InventoryStock>();
        public List<Inventory> listInventories = new List<Inventory>();
        public List<InstrumentBrand> listInstrumentBrands = new List<InstrumentBrand>();
        public List<InstrumentModel> listInstrumentModels = new List<InstrumentModel>();
        public List<InstrumentAgency> listInstrumentAgencys = new List<InstrumentAgency>();
        public List<InstrumentType> listInstrumentTypes = new List<InstrumentType>();
        public List<InstrumentStatus> listInstrumentStatus = new List<InstrumentStatus>();
        public List<InstrumentLocation> listInstrumentLocations = new List<InstrumentLocation>();
        public List<InstrumentUnit> listInstrumentUnits = new List<InstrumentUnit>();
        public List<EvntInstrument> Lins = new List<EvntInstrument>();
        public List<EventSupportTeam> eventSupportTeams = new List<EventSupportTeam>();
        public ProjectEventRecord projectEventRecordID = new ProjectEventRecord();
        public List<RecordProject> recordProjectRecords = new List<RecordProject>();
        public List<Instrument> instrumentPersonalDoseList = new List<Instrument>();
        public List<EventPersonalDose> eventPersonalDoses = new List<EventPersonalDose>();
        public List<Position> positionList = new List<Position>();
        protected List<EventSumPersonalDose> eventSumPersonalDoses = new List<EventSumPersonalDose>();
        protected List<RecordProjectType> recordProjectTypes = new List<RecordProjectType>();

        //****ที่เพิ่มเข้ามาในอันนี้ คือ รีเฟรส ข้อมูลที่ทำการ CheckOut Consumable โดยทำการ Get ข้อมูลของ MinStock,Inventory มาอีกครั้งในตอน CheckOut Consumable*********
        protected List<MinStock> listMinStock = new List<MinStock>();
        protected List<Inventory> listInventory = new List<Inventory>();
        protected List<InventoryAgency> inventoryAgencys = new List<InventoryAgency>();
        protected List<InventoryBrand> inventoryBrands = new List<InventoryBrand>();
        protected List<Inventory> inventories = new List<Inventory>();


        [Parameter]
        public string id { get; set; }

        [Parameter]
        public string EventNumber { get; set; }


        protected string RequertMessage;
        protected int deleteInstrumentID;
        protected int deleteTeamID;
        protected int deleteSupportTeamID;
        protected int deletePersonalDoseTeamID;
        protected int deleteInventoryStockID;
        protected string deleteEventNumer = string.Empty;
        protected string UsedEvent = string.Empty;
        public BSModal Load { get; set; }
        public BSModal ModalResponseError { get; set; }
        public BSModal ModalRespondSuccess { get; set; }
        public BSModal CreateRecordEvent { get; set; }
        public BSModal UpdateProjectInventory { get; set; }
        public BSModal? ModalResponseConfirmCheckOutInstrument { get; set; }
        public BSModal? ModalResponseConfirmCheckInInstrument { get; set; }
        public BSModal? ModalResponseConfirmCheckInInstrumentNotEvent { get; set; }
        public BSModal? ModalResponseConfirmDeleteInstrument { get; set; }
        public BSModal? ModalResponseConfirmDeleteTeam { get; set; }
        public BSModal? ModalResponseConfirmDeleteSupportTeam { get; set; }
        public BSModal? ModalResponseConfirmDeletePersonalDoseTeam { get; set; }
        public BSModal? ModalResponseConfirmDeleteInventory { get; set; }
        public BSModal? ModalResponseConfirmCheckOutInventory { get; set; }
        public BSModal? ModalResponseConfirmDeleteEvent { get; set; }
        public BSModal? ModalResponseUsedInEvent { get; set; }

        protected string ID;
        public void TrClickedAtIndex(string id)
        {
            ID = id;

        }

        public DateTime TestDate;

        protected override async Task OnInitializedAsync()
        {
            try
            {

                recordProjectRecords = AppData.recordProjects;
                recordEventTypes = AppData.recordEventTypes;
                recordEventProvinces = AppData.Provinces;
                recordProjectTypes = await _masterData.GetMasterDataAsync<RecordProjectType>("ProjectType");
                instrumentPersonalDoseList = await _masterData.GetMasterDataAsync<Instrument>("Instrument");
                inventories = AppData.inventorys;


                var result = await _masterDataPhase2.GetMasterDataAsyncByID<RecordProject>("ProjectRecordByID", int.Parse(id));
                recordProject = result;
                updateProject.ProjectRegional = recordProject.ProjectRegional;

                accounts = await Http.GetFromJsonAsync<List<Account>>($"{Config["aurl"]}/api/GetAccount");

                /**************************************Add New**********************************************************************************************************************/
                teams = await Http.GetFromJsonAsync<List<ProjectTeam>>($"{Config["nurl"]}/api/GetProjectTeam/{recordProject.ProjectID}");

                SupportTeam = await Http.GetFromJsonAsync<List<ProjectSupportTeam>>($"{Config["nurl"]}/api/ProjectSupportTeam/{recordProject.ProjectID}");

                //projectPersonalDoses = await Http.GetFromJsonAsync<List<ProjectPersonalDose>>($"{Config["nurl"]}/api/GetProjectPersonalDose/{recordProject.ProjectID}");

                eventPersonalDoses = await Http.GetFromJsonAsync<List<EventPersonalDose>>($"{Config["nurl"]}/api/GetEventPersonalDose/ProjectById/{recordProject.ProjectID}");

                //positionList = await Http.GetFromJsonAsync<List<Position>>($"{Config["aurl"]}/api/Position");

                eventSumPersonalDoses = await Http.GetFromJsonAsync<List<EventSumPersonalDose>>($"{Config["nurl"]}/api/GetEventSumPersonalDose/{recordProject.ProjectID}");

                listInventories = AppData.inventorys;

                listInstrumentTypes = AppData.instrumentTypes;

                listInstrumentBrands = AppData.instrumentBrands;

                listInstrumentAgencys = AppData.instrumentAgencies;

                listInstrumentModels = AppData.instrumentModels;

                listInstrumentLocations = AppData.instrumentLocations;

                listInstrumentStatus = AppData.instrumentStatus;

                //listRecordEvent = AppData.recordEvents;

                ///Added and edited on 30-01-67
                projectInstruments = await Http.GetFromJsonAsync<List<ProjectInstrument>>($"{Config["nurl"]}/api/GetProjectInstrument/{recordProject.ProjectID}");
                var resultLins = projectInstruments.OrderBy(i => i.InstrumentNumber).ToList();
                foreach (var i in resultLins)
                {
                    if (i.InstrumentNumber != "")
                    {
                        this.listInstrument.AddRange(await Http.GetFromJsonAsync<IList<Instrument>>($"{Config["nurl"]}/api/GetInstrumentByInstrumentNumber/{i.InstrumentNumber}"));
                    }
                }
                if (this.listInstrument.Count() > 0)
                {

                    foreach (var i in this.listInstrument)
                    {
                        i.GetLookup(listInstrumentBrands, listInstrumentModels, listInstrumentAgencys, listInstrumentStatus, listInstrumentLocations);
                    }


                }

                projectInventoryStocks = await Http.GetFromJsonAsync<List<ProjectInventoryStock>>($"{Config["nurl"]}/api/GetProjectInventory/{recordProject.ProjectID}");
                var resultINVS = projectInventoryStocks.OrderBy(x => x.ProjectStockNumber).ToList();
                foreach (var i in resultINVS)
                {
                    if (i.ProjectStockNumber != "")
                    {
                        this.listInventoryStock.AddRange(await Http.GetFromJsonAsync<IList<InventoryStock>>($"{Config["nurl"]}/api/GetInventoryStockByStockNumber/{i.ProjectStockNumber}"));
                    }

                }
                if (this.listInventoryStock.Count() > 0)
                {
                    foreach (var i in listInventoryStock)
                    {
                        i.GetLookUp(listInventories);
                    }
                }




                listInstrumentUnits = await Http.GetFromJsonAsync<List<InstrumentUnit>>($"{Config["nurl"]}/api/InstrumentUnit/GetAllInstrumentUnits");
                var resultUnit = listInstrumentUnits.Find(i => i.IsActive == true).IsActive;
                if (resultUnit == true)
                {
                    listInstrumentUnits = await Http.GetFromJsonAsync<List<InstrumentUnit>>($"{Config["nurl"]}/api/InstrumentUnit/GetAllActiveInstrumentUnits");
                }
                else
                {
                    listInstrumentUnits = await Http.GetFromJsonAsync<List<InstrumentUnit>>($"{Config["nurl"]}/api/InstrumentUnit/GetAllInstrumentUnits");
                }

                //addTeam.UserID = accounts.First().UserID;
                /************************************************************************************************************************************************************/


                listprojectEventRecord = await Http.GetFromJsonAsync<List<ProjectEventRecord>>($"{Config["nurl"]}/api/GetProjectEventRecord/{recordProject.ProjectID}");
                var resultEventList = listprojectEventRecord.OrderBy(i => i.EventNumber).ToList();
                foreach (var i in resultEventList)
                {
                    if (i.EventNumber != "")
                    {
                        this.recordEvents.AddRange(await Http.GetFromJsonAsync<IList<RecordEvent>>($"{Config["nurl"]}/api/GetEventRecordByEventNumber/{i.EventNumber}"));
                    }
                }


                if (recordEvent.ProvinceID > 0)
                {
                    recordEventDistricts = AppData.Districts.Where(i => i.DistrictProvinceID == recordEvent.ProvinceID).ToList();
                }
                if (recordEvent.DistrictID > 0)
                {
                    subDistricts = AppData.subDistricts.Where(i => i.subDistrictDistrictID == recordEvent.DistrictID).ToList();
                }



                var resultRegionalNumber = AppData.recordRegionals.Find(x => x.RegionalNumber == updateProject.ProjectRegional).RegionalNumber;
                if (resultRegionalNumber != 7)
                {
                    var resultProvice = recordEventProvinces.Where(x => x.ProvinceGeographyID == resultRegionalNumber).ToList();
                    recordEventProvinces = resultProvice;
                    Regoinal = resultRegionalNumber;

                }
                else
                {
                    recordEventProvinces = AppData.Provinces;

                }

                ///OrderBy Provinces and Districts
                if (AppData.LanguageID == 0)
                {
                    var resultEventProvinces = recordEventProvinces.OrderBy(pEN => pEN.ProvinceENName).ToList();
                    recordEventProvinces = resultEventProvinces;
                    var resultEventTypes = recordEventTypes.OrderBy(tEN => tEN.EventTypeENName).ToList();
                    recordEventTypes = resultEventTypes;
                    /*   var resultEventDistricts = recordEventDistricts.OrderBy(dEN => dEN.DistrictENName).ToList();
                       recordEventDistricts = resultEventDistricts;
                       var resultsubDistricts = subDistricts.OrderBy(sdEN => sdEN.subDistrictENName).ToList();
                       subDistricts = resultsubDistricts;*/
                }
                else
                {
                    var resultEventProvinces = recordEventProvinces.OrderBy(pTH => pTH.ProvinceTHName).ToList();
                    recordEventProvinces = resultEventProvinces;
                    var resultEventTypes = recordEventTypes.OrderBy(tTH => tTH.EventTypeTHName).ToList();
                    recordEventTypes = resultEventTypes;
                    /* var resultEventDistricts = recordEventDistricts.OrderBy(dTH => dTH.DistrictTHName).ToList();
                     recordEventDistricts = resultEventDistricts;
                     var resultsubDistricts = subDistricts.OrderBy(sdTH => sdTH.subDistrictTHName).ToList();
                     subDistricts = resultsubDistricts;*/
                }

                //อัปเดตค่า OriginalPersonalDose Project Team 
                //foreach (var i in teams)
                //{
                //    i.OriginalPersonalDose = i.PersonalDose;
                //}

                ////อัปเดตค่า OriginalPersonalDose Project Support Team 
                //foreach (var i in SupportTeam)
                //{
                //    i.OriginalPersonalDose = i.PersonalDose;
                //}

                // Set the default value for EventRegisterDate to ProjectStartDate if not already set
                if (!recordEvent.EventRegisterDate.HasValue)
                {
                    recordEvent.EventRegisterDate = recordProject.ProjectStartDate;
                }



            }
            catch (Exception e)
            {
                ToastService.ShowError($"ERR: {e.Message}");
            }




        }

        protected async Task SetUpdateProjectRecord()
        {
            recordEventProvinces = AppData.Provinces;

            var result = await _masterDataPhase2.GetMasterDataAsyncByID<RecordProject>("ProjectRecordByID", int.Parse(id));
            recordProject = result;
            updateProject.ProjectRegional = recordProject.ProjectRegional;
            AppData.recordProjects = await _masterDataPhase2.GetMasterDataAsync<RecordProject>("ProjectRecord");

            if (recordEvent.ProvinceID > 0)
            {
                recordEventDistricts = AppData.Districts.Where(i => i.DistrictProvinceID == recordEvent.ProvinceID).ToList();
            }
            if (recordEvent.DistrictID > 0)
            {
                subDistricts = AppData.subDistricts.Where(i => i.subDistrictDistrictID == recordEvent.DistrictID).ToList();
            }

            var resultRegionalNumber = AppData.recordRegionals.Find(x => x.RegionalNumber == updateProject.ProjectRegional).RegionalNumber;
            if (resultRegionalNumber != 7)
            {
                var resultProvice = recordEventProvinces.Where(x => x.ProvinceGeographyID == resultRegionalNumber).ToList();
                recordEventProvinces = resultProvice;
                Regoinal = resultRegionalNumber;

            }
            else
            {
                recordEventProvinces = AppData.Provinces;

            }

            if (AppData.LanguageID == 0)
            {
                var resultEventProvinces = recordEventProvinces.OrderBy(pEN => pEN.ProvinceENName).ToList();
                recordEventProvinces = resultEventProvinces;
                var resultEventTypes = recordEventTypes.OrderBy(tEN => tEN.EventTypeENName).ToList();
                recordEventTypes = resultEventTypes;
                /*   var resultEventDistricts = recordEventDistricts.OrderBy(dEN => dEN.DistrictENName).ToList();
                   recordEventDistricts = resultEventDistricts;
                   var resultsubDistricts = subDistricts.OrderBy(sdEN => sdEN.subDistrictENName).ToList();
                   subDistricts = resultsubDistricts;*/
            }
            else
            {
                var resultEventProvinces = recordEventProvinces.OrderBy(pTH => pTH.ProvinceTHName).ToList();
                recordEventProvinces = resultEventProvinces;
                var resultEventTypes = recordEventTypes.OrderBy(tTH => tTH.EventTypeTHName).ToList();
                recordEventTypes = resultEventTypes;
                /* var resultEventDistricts = recordEventDistricts.OrderBy(dTH => dTH.DistrictTHName).ToList();
                 recordEventDistricts = resultEventDistricts;
                 var resultsubDistricts = subDistricts.OrderBy(sdTH => sdTH.subDistrictTHName).ToList();
                 subDistricts = resultsubDistricts;*/
            }
        }

        /// <summary>
        /// SaveEditProjectRecord
        /// </summary>
        protected async Task SaveEditProjectRecord()
        {
            try
            {
                if (recordProject.ProjectEndDate.Date >= recordProject.ProjectStartDate.Date)
                {
                    var respond = await _masterDataPhase2.PutMasterDataAsync("PutProjectRecord", recordProject, recordProject.ProjectID);
                    if (!string.IsNullOrEmpty(respond.ToString()))
                    {
                        var requertException = respond.StatusMessage;
                        RequertMessage = requertException;
                        await SetUpdateProjectRecord();
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

        public bool isDoubleClick = false;
        public bool isSaving { get; set; }

        public async Task OnCreateRecordEvent()
        {
            if (recordProject.ProjectInsStatusID == 3)
            {
                ToastService.ShowError("This project has been completed.");
            }
            else
            {
                CreateRecordEvent.Show();
            }
        }


        protected void OnDateChanged(ChangeEventArgs e)
        {
            if (DateTime.TryParse(e.Value.ToString(), out var newDate))
            {
                recordEvent.EventRegisterDate = newDate;
            }
        }

        public async Task OnSaveCreateRecordEvent()
        {
            await Task.Run(Loading);
            Load.Show();
            if (recordProject.ProjectInsStatusID == 3)
            {
                ToastService.ShowError("This project has been completed.");
            }
            else if (!isDoubleClick)
            {
                if (recordEvent.EventRegisterDate.HasValue &&
                            recordEvent.EventRegisterDate.Value.Date >= recordProject.ProjectStartDate.Date &&
                            recordEvent.EventRegisterDate.Value.Date <= recordProject.ProjectEndDate.Date)
                {

                    isDoubleClick = true;
                    try
                    {

                        var result = recordEventProvinces.Where(x => x.ProvinceID == recordEvent.ProvinceID).ToList();

                        if (AppData.CurrentPermission.Find(i => i.permissionID == 1).permissionC)
                        {
                            recordEvent.eventCreateBy = (Guid)AppData.UserID;
                            recordEvent.eventCreateDate = DateTime.Now;
                            recordEvent.EventStatusID = 1;
                            recordEvent.EventType = recordProject.ProjectType;
                            recordEvent.EventInformerName = recordProject.ProjectInformerName;
                            recordEvent.EventStartDate = recordEvent.EventRegisterDate;
                            recordEvent.EventEndDate = recordEvent.EventRegisterDate;
                            //ToastService.ShowSuccess($"{recordEvent.EventEndDate}");

                            if (result.Any())
                            {
                                var respond = await Http.PostAsJsonAsync<RecordEvent>($"{Config["nurl"]}/api/RegisterEventRecord", recordEvent);
                                if (respond.StatusCode == System.Net.HttpStatusCode.OK)
                                {
                                    ToastService.ShowSuccess("Register Event Successfully");
                                    try
                                    {
                                        List<RecordEvent> listEvent = await respond.Content.ReadFromJsonAsync<List<RecordEvent>>();
                                        // var rec =result.First<RecordEvent>();
                                        this.recordEvent = listEvent.First<RecordEvent>();

                                        EventNumber = recordEvent.EventNumber;

                                        // Check not haveRecordEvent and Drupicate
                                        if (listEvent.Count > 0 && !recordEvents.Any(i => i.EventNumber.ToLower() == EventNumber))
                                        {
                                            projectEventRecord.ProjectID = recordProject.ProjectID;
                                            projectEventRecord.EventID = recordEvent.EventID;
                                            projectEventRecord.EventNumber = EventNumber;

                                            var respondProject = await Http.PostAsJsonAsync($"{Config["nurl"]}/api/RegisterProjectEvent", projectEventRecord);
                                            if (respondProject.StatusCode == System.Net.HttpStatusCode.OK)
                                            {
                                                listprojectEventRecord = await Http.GetFromJsonAsync<List<ProjectEventRecord>>($"{Config["nurl"]}/api/GetProjectEventRecord/{recordProject.ProjectID}");
                                                var resultEventlist = listprojectEventRecord.OrderBy(i => i.EventNumber).ToList();
                                                recordEvents = new List<RecordEvent>();
                                                foreach (var i in resultEventlist)
                                                {
                                                    this.recordEvents.AddRange(await Http.GetFromJsonAsync<IList<RecordEvent>>($"{Config["nurl"]}/api/GetEventRecordByEventNumber/{i.EventNumber}"));

                                                }

                                                RequertMessage = "Added Event Record Successfully";
                                                recordEvent.EventName = "";
                                                recordEvent.EventRegisterDate = recordProject.ProjectStartDate;
                                                recordEvent.EventType = 0;
                                                recordEvent.EventLocationName = "";
                                                recordEvent.ProvinceID = 0;
                                                recordEvent.DistrictID = 0;
                                                recordEvent.SubDistrictID = 0;
                                                recordEvent.zipCode = 0;
                                                recordEvent.EventInformerName = "";
                                                recordEvent.EventInformation = "";

                                                ModalRespondSuccess.Show();
                                            }



                                        }
                                        else
                                        {
                                            RequertMessage = "Invalid EventNumber OR Duplicatie EventNumber";
                                            ModalResponseError.Show();
                                        }


                                    }
                                    catch (Exception e)
                                    {
                                        var val = e.Message;
                                        ToastService.ShowError($"{val}Error!");
                                    }

                                }
                                else
                                {
                                    ToastService.ShowError("Error! "); //
                                    Console.WriteLine(respond);
                                }
                            }
                            //else
                            //{
                            //    //RequertMessage = "Can not add event because it does not match the specified region.";
                            //    //ModalResponseError.Show();
                            //}


                        }
                    }
                    catch (Exception e)
                    {
                        ToastService.ShowError($"Error{e.Message}");
                    }
                    finally
                    {
                        isDoubleClick = false; // Reset the double-click flag
                    }

                }
                else
                {

                    ToastService.ShowError($"The registration date is outside the project's dates.");
                }


            }
            CreateRecordEvent.Hide();
            Load.Hide();
        }

        private void ClearRecordEventFields()
        {
            recordEvent.EventName = "";
            recordEvent.EventRegisterDate = recordProject.ProjectStartDate;
            recordEvent.EventType = 0;
            recordEvent.EventLocationName = "";
            recordEvent.ProvinceID = 0;
            recordEvent.DistrictID = 0;
            recordEvent.SubDistrictID = 0;
            recordEvent.zipCode = 0;
            recordEvent.EventInformerName = "";
            recordEvent.EventInformation = "";
        }


        /// <summary>
        /// OnProvinceSelected
        /// </summary>
        /// <param name="e"></param>
        public void OnProvinceSelected(ChangeEventArgs e)
        {

            // แปลงค่าที่ผู้ใช้ป้อนเข้ามาเป็น int
            if (int.TryParse(e.Value.ToString(), out int parsedValueProvinceID))
            {
                recordEvent.ProvinceID = parsedValueProvinceID;
                if (this.recordEvent.ProvinceID != null && this.recordEvent.ProvinceID != 0)
                {
                    recordEventDistricts = recordEventProvinces.Find(i => i.ProvinceID == recordEvent.ProvinceID).Districts;
                    if (AppData.LanguageID == 0)
                    {
                        var resultEventDistricts = recordEventDistricts.OrderBy(dEN => dEN.DistrictENName).ToList();
                        recordEventDistricts = resultEventDistricts;

                    }
                    else
                    {
                        var resultEventDistricts = recordEventDistricts.OrderBy(dTH => dTH.DistrictTHName).ToList();
                        recordEventDistricts = resultEventDistricts;
                    }

                    recordEvent.DistrictID = 0;
                    recordEvent.SubDistrictID = 0;
                    recordEvent.zipCode = 0;
                }
                else
                {
                    recordEventDistricts = new List<RecordEventDistrict>();
                    subDistricts = new List<SubDistrict>();
                    recordEvent.zipCode = 0;

                }
            }

        }

        /// <summary>
        /// OnDistrictSelected
        /// </summary>
        /// <param name="e"></param>
        public void OnDistrictSelected(ChangeEventArgs e)
        {
            if (int.TryParse(e.Value.ToString(), out int parsedValueDistrictsID))
            {
                recordEvent.DistrictID = parsedValueDistrictsID;
                if (this.recordEvent.DistrictID != null && this.recordEvent.DistrictID != 0)
                {
                    this.subDistricts = recordEventDistricts.Find(i => i.DistrictID == recordEvent.DistrictID).SubDistricts;
                    if (AppData.LanguageID == 0)
                    {
                        var resultsubDistricts = subDistricts.OrderBy(sdEN => sdEN.subDistrictENName).ToList();
                        subDistricts = resultsubDistricts;

                    }
                    else
                    {
                        var resultsubDistricts = subDistricts.OrderBy(sdTH => sdTH.subDistrictTHName).ToList();
                        subDistricts = resultsubDistricts;
                    }

                    recordEvent.SubDistrictID = 0;
                    recordEvent.zipCode = 0;
                }
                else
                {
                    subDistricts = new List<SubDistrict>();
                    recordEvent.zipCode = 0;
                }

            }

        }

        /// <summary>
        /// OnSubDistrictSelected
        /// </summary>
        /// <param name="e"></param>
        public void OnSubDistrictSelected(ChangeEventArgs e)
        {
            if (int.TryParse(e.Value.ToString(), out int parsedValueSubDistrictsID))
            {
                recordEvent.SubDistrictID = parsedValueSubDistrictsID;
                if (this.recordEvent.SubDistrictID != null && this.recordEvent.SubDistrictID != 0)
                {
                    recordEvent.zipCode = Int32.Parse(subDistricts.Find(i => i.subDistrictID == this.recordEvent.SubDistrictID).subDistrictCode);
                }
                else
                {
                    recordEvent.zipCode = 0;
                }
            }

        }

        public async Task OnAddEventRecord()
        {
            await Task.Run(Loading);
            Load.Show();
            try
            {


                var resultRegionalNumber = AppData.recordRegionals.Find(x => x.RegionalNumber == updateProject.ProjectRegional).RegionalNumber;
                var resultProvice = AppData.Provinces.Where(x => x.ProvinceGeographyID == resultRegionalNumber).ToList();
                List<RecordEvent> listEvent = await Http.GetFromJsonAsync<List<RecordEvent>>($"{Config["nurl"]}/api/GetEventRecordByEventNumber/{projectEventRecord.EventNumber}");
                recordEvent = listEvent.First();
                var result = resultProvice.Where(x => x.ProvinceID == recordEvent.ProvinceID).ToList();

                // Check not haveRecordEvent and Drupicate
                if (listEvent.Count > 0 && !recordEvents.Any(i => i.EventNumber.ToLower() == projectEventRecord.EventNumber.ToLower()))
                {
                    projectEventRecord.ProjectID = recordProject.ProjectID;
                    projectEventRecord.EventID = recordEvent.EventID;
                    if (result.Any())
                    {
                        var respond = await Http.PostAsJsonAsync($"{Config["nurl"]}/api/RegisterProjectEvent", projectEventRecord);
                        if (respond.StatusCode == System.Net.HttpStatusCode.OK)
                        {
                            listprojectEventRecord = await Http.GetFromJsonAsync<List<ProjectEventRecord>>($"{Config["nurl"]}/api/GetProjectEventRecord/{recordProject.ProjectID}");
                            var resultEventlist = listprojectEventRecord.OrderBy(i => i.EventNumber).ToList();
                            recordEvents = new List<RecordEvent>();
                            foreach (var i in resultEventlist)
                            {
                                this.recordEvents.AddRange(await Http.GetFromJsonAsync<IList<RecordEvent>>($"{Config["nurl"]}/api/GetEventRecordByEventNumber/{i.EventNumber}"));

                            }

                            RequertMessage = "Added Event Record Successfully";
                            ModalRespondSuccess.Show();
                        }
                    }
                    else if (resultRegionalNumber == 7)
                    {
                        var respond = await Http.PostAsJsonAsync($"{Config["nurl"]}/api/RegisterProjectEvent", projectEventRecord);
                        if (respond.StatusCode == System.Net.HttpStatusCode.OK)
                        {
                            listprojectEventRecord = await Http.GetFromJsonAsync<List<ProjectEventRecord>>($"{Config["nurl"]}/api/GetProjectEventRecord/{recordProject.ProjectID}");
                            var resultEventlist = listprojectEventRecord.OrderBy(i => i.EventNumber).ToList();
                            recordEvents = new List<RecordEvent>();
                            foreach (var i in resultEventlist)
                            {
                                this.recordEvents.AddRange(await Http.GetFromJsonAsync<IList<RecordEvent>>($"{Config["nurl"]}/api/GetEventRecordByEventNumber/{i.EventNumber}"));

                            }

                            RequertMessage = "Successfully added Event Record";
                            ModalRespondSuccess.Show();
                        }
                    }
                    else
                    {
                        RequertMessage = "Can not add event because it does not match the specified region.";
                        ModalResponseError.Show();
                    }

                }
                else
                {
                    RequertMessage = "Invalid EventNumber OR Duplicatie EventNumber";
                    ModalResponseError.Show();
                }

            }
            catch (Exception e)
            {
                var val = e.Message;
                RequertMessage = val;
                ModalResponseError.Show();
            }
            Load.Hide();

        }

        public async Task ConfirmDeleteEvent(string eventNumber)
        {
            if (recordProject.ProjectInsStatusID == 3)
            {
                await OnPutEventRecord();
            }
            else
            {
                deleteEventNumer = eventNumber.ToString();
                ModalResponseConfirmDeleteEvent.Show();
            }
        }

        public async Task OnPutEventRecord()
        {
            await Task.Run(Loading);
            Load.Show();
            if (recordProject.ProjectInsStatusID == 3)
            {
                ToastService.ShowError("This project has been completed.");
            }
            else if (!isDoubleClick)
            {
                isDoubleClick = true;
                try
                {

                    int id = listprojectEventRecord.Find(i => i.EventNumber.ToString().ToLower().Contains(deleteEventNumer.ToString().ToLower())).ProjectEventID;
                    var respond = await Http.PostAsync($"{Config["nurl"]}/api/DeleteProjectEvent/{id}", null);

                    listprojectEventRecord = await Http.GetFromJsonAsync<List<ProjectEventRecord>>($"{Config["nurl"]}/api/GetProjectEventRecord/{recordProject.ProjectID}");
                    var resultEventlist = listprojectEventRecord.OrderBy(i => i.EventNumber).ToList();
                    recordEvents = new List<RecordEvent>();
                    foreach (var i in resultEventlist)
                    {

                        this.recordEvents.AddRange(await Http.GetFromJsonAsync<IList<RecordEvent>>($"{Config["nurl"]}/api/GetEventRecordByEventNumber/{i.EventNumber}"));
                    }
                    ModalResponseConfirmDeleteEvent.Hide();
                    RequertMessage = "Deleted Event Record Successfully";
                    ModalRespondSuccess.Show();

                }
                catch (Exception e)
                {
                    var val = e.Message;
                    RequertMessage = val;
                    ModalResponseError.Show();
                }
                finally
                {
                    Load.Hide();
                    isDoubleClick = false; // Reset the double-click flag
                }

            }
            StateHasChanged();
            Load.Hide();
        }

        protected void Loading()
        {
            System.Threading.Thread.Sleep(300);
            // Retrieve data from the server and initialize
            // Employees property which the View will bind
        }

        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            if (firstRender)
            {
                await jsRuntime.InvokeVoidAsync("clearURL");
                await jsRuntime.InvokeVoidAsync("addEnterKeyPressListener");
                //await jsRuntime.InvokeAsync<object>("exampleTables", "#example");
            }
        }



        public async void initialBack()
        {
            AppData.recordProjects = await _masterData.GetMasterDataAsync<RecordProject>("ProjectRecord");
        }

        /// <summary>
        /// OnAddSupportTeam
        /// </summary>
        /// <returns></returns>
        public async Task OnAddProjectSupportTeam()
        {
            try
            {
                if (addSupportTeam.Name != "")
                {
                    if (recordProject.ProjectInsStatusID == 3)
                    {
                        ToastService.ShowError("This project has been completed.");

                    }
                    else if (!SupportTeam.Any(i => i.Name == addSupportTeam.Name && i.OrderProject == 1))
                    {
                        addSupportTeam.ProjectID = recordProject.ProjectID;
                        addSupportTeam.PersonalDose = 0;
                        addSupportTeam.PersonalDoseUnitID = 1;
                        addSupportTeam.PersonalDoseDate = DateTime.Now;
                        var respond = await Http.PostAsJsonAsync($"{Config["nurl"]}/api/ProjectSupportTeam", addSupportTeam);
                        ToastService.ShowSuccess("Successfully added SupportTeam");
                        SupportTeam = await Http.GetFromJsonAsync<List<ProjectSupportTeam>>($"{Config["nurl"]}/api/ProjectSupportTeam/{recordProject.ProjectID}");
                        eventSumPersonalDoses = await Http.GetFromJsonAsync<List<EventSumPersonalDose>>($"{Config["nurl"]}/api/GetEventSumPersonalDose/{recordProject.ProjectID}");
                        addSupportTeam.Name = "";
                        addSupportTeam.Position = "";
                        addSupportTeam.Department = "";
                        addSupportTeam.PhoneNumber = "";
                        addSupportTeam.Email = "";
                        //อัปเดตค่า OriginalPersonalDose เมื่อลบข้อมูล
                        //foreach (var i in SupportTeam)
                        //{
                        //    i.OriginalPersonalDose = i.PersonalDose;
                        //}
                    }
                    else
                    {
                        ToastService.ShowError("Suppor Team Add Duplicatie");
                    }

                }
                else
                {
                    ToastService.ShowError("Fill in at least one support name field.");
                }

            }
            catch (Exception e)
            {
                ToastService.ShowError("ERR:" + e.Message);
            }

        }

        public async Task OnAddProjectInstrument()
        {
            Load.Show();
            try
            {
                if (projectInstrument.InstrumentNumber != "")
                {
                    List<Instrument> resultInstrument = await Http.GetFromJsonAsync<List<Instrument>>($"{Config["nurl"]}/api/GetInstrumentByInstrumentNumber/{projectInstrument.InstrumentNumber}");
                    instrument = resultInstrument.First();
                    // Check not haveInstrument Status is not normal
                    if (recordProject.ProjectInsStatusID == 3)
                    {
                        ToastService.ShowError("This project has been completed.");

                    }
                    else if (resultInstrument.Any(x => x.InstrumentStatusID != 1))
                    {
                        ToastService.ShowError("Instrument not available");
                    }
                    else
                    {

                        // Check not haveInstrument Drupicate
                        if (resultInstrument.Count > 0 && !listInstrument.Any(i => i.InstrumentNumber.ToString().ToUpper() == projectInstrument.InstrumentNumber.ToUpper()))
                        {
                            if (this.recordProject.ProjectInsStatusID != 1)
                            {
                                ToastService.ShowError("Cannot Add Instrument You have checckout already done! ");
                            }
                            else
                            {
                                projectInstrument.ProjectID = recordProject.ProjectID;
                                projectInstrument.InstrumentID = instrument.InstrumentID;

                                var respond = await Http.PostAsJsonAsync($"{Config["nurl"]}/api/RegisterProjectInstrument", projectInstrument);
                                if (respond.StatusCode == System.Net.HttpStatusCode.OK)
                                {

                                    projectInstruments = await Http.GetFromJsonAsync<List<ProjectInstrument>>($"{Config["nurl"]}/api/GetProjectInstrument/{recordProject.ProjectID}");
                                    var resultLins = projectInstruments.OrderBy(i => i.InstrumentNumber).ToList();
                                    listInstrument = new List<Instrument>();
                                    foreach (var i in resultLins)
                                    {
                                        this.listInstrument.AddRange(await Http.GetFromJsonAsync<IList<Instrument>>($"{Config["nurl"]}/api/GetInstrumentByInstrumentNumber/{i.InstrumentNumber}"));

                                    }
                                    foreach (var i in listInstrument)
                                    {
                                        i.GetLookup(listInstrumentBrands, listInstrumentModels, listInstrumentAgencys, listInstrumentStatus, listInstrumentLocations);
                                    }


                                    ToastService.ShowSuccess("Successfully added Project Instrument");
                                    projectInstrument.InstrumentNumber = "";
                                }
                            }



                        }
                        else { ToastService.ShowError("Instrument Number Duplicatie"); }
                    }

                }
                else
                {
                    ToastService.ShowError("Please select a Instrument");
                }

            }
            catch (Exception e)
            {
                ToastService.ShowError("ERR:" + e.Message);
            }
            Load.Hide();

        }

        public async Task OnAddProjectTeam()
        {
            Load.Show();
            try
            {
                if (addTeam.UserID != new Guid() && addTeam.UserID != null)
                {
                    if (recordProject.ProjectInsStatusID == 3)
                    {
                        ToastService.ShowError("This project has been completed.");

                    }
                    else if (!teams.Any(i => i.UserID == addTeam.UserID))
                    {

                        addTeam.ProjectID = recordProject.ProjectID;
                        addTeam.PersonalDoseUnitID = 1;
                        addTeam.PersonalDoseDate = DateTime.Now;
                        var respond = await Http.PostAsJsonAsync($"{Config["nurl"]}/api/RegisterProjectTeam", addTeam);
                        ToastService.ShowSuccess("Successfully added Project Team");
                        teams = await Http.GetFromJsonAsync<List<ProjectTeam>>($"{Config["nurl"]}/api/GetProjectTeam/{recordProject.ProjectID}");
                        eventSumPersonalDoses = await Http.GetFromJsonAsync<List<EventSumPersonalDose>>($"{Config["nurl"]}/api/GetEventSumPersonalDose/{recordProject.ProjectID}");
                        addTeam.UserID = null;
                        //อัปเดตค่า OriginalPersonalDose เมื่อลบข้อมูล
                        //foreach (var i in teams)
                        //{
                        //    i.OriginalPersonalDose = i.PersonalDose;
                        //}
                    }
                    else
                    {
                        ToastService.ShowError("Team Add Duplicatie");
                    }
                }
                else
                {
                    ToastService.ShowError("Please select a team");
                }
            }
            catch (Exception e)
            {
                ToastService.ShowError($"ERR: {e.Message}");
            }
            Load.Hide();
        }

        public async Task OnAddProjectPersonalDose()
        {
            Load.Show();
            try
            {
                if (addProjectPersonalDose.UserID != new Guid() && addProjectPersonalDose.UserID != null)
                {
                    if (recordProject.ProjectInsStatusID == 3)
                    {
                        ToastService.ShowError("This project has been completed.");

                    }
                    else if (!projectPersonalDoses.Any(i => i.UserID == addProjectPersonalDose.UserID))
                    {

                        addProjectPersonalDose.ProjectID = recordProject.ProjectID;
                        addProjectPersonalDose.PersonalDoseUnitID = 1;
                        addProjectPersonalDose.SupportTeamID = 0;
                        addProjectPersonalDose.PersonalDoseDate = DateTime.Now;
                        addProjectPersonalDose.IsTeam = true;
                        addProjectPersonalDose.PersonalDose = 0;
                        var respond = await Http.PostAsJsonAsync($"{Config["nurl"]}/api/RegisterProjectPersonalDose", addProjectPersonalDose);
                        ToastService.ShowSuccess("Successfully added Team Personal Dose");
                        projectPersonalDoses = await Http.GetFromJsonAsync<List<ProjectPersonalDose>>($"{Config["nurl"]}/api/GetProjectPersonalDose/{recordProject.ProjectID}");
                        addProjectPersonalDose.UserID = null;

                    }
                    else
                    {
                        ToastService.ShowError("Team Add Duplicatie");
                    }
                }
                else if (addProjectPersonalDose.SupportTeamID != null && addProjectPersonalDose.SupportTeamID != 0)
                {
                    if (recordProject.ProjectInsStatusID == 3)
                    {
                        ToastService.ShowError("This project has been completed.");

                    }
                    else if (!projectPersonalDoses.Any(i => i.SupportTeamID == addProjectPersonalDose.SupportTeamID))
                    {

                        addProjectPersonalDose.ProjectID = recordProject.ProjectID;
                        addProjectPersonalDose.PersonalDoseUnitID = 1;
                        addProjectPersonalDose.UserID = new Guid("00000000-0000-0000-0000-000000000000");
                        addProjectPersonalDose.PersonalDoseDate = DateTime.Now;
                        addProjectPersonalDose.IsTeam = false;
                        addProjectPersonalDose.PersonalDose = 0;
                        var respond = await Http.PostAsJsonAsync($"{Config["nurl"]}/api/RegisterProjectPersonalDose", addProjectPersonalDose);
                        ToastService.ShowSuccess("Successfully added Support Team Personal Dose");
                        projectPersonalDoses = await Http.GetFromJsonAsync<List<ProjectPersonalDose>>($"{Config["nurl"]}/api/GetProjectPersonalDose/{recordProject.ProjectID}");
                        addProjectPersonalDose.SupportTeamID = null;


                        //// อัปเดตค่า OriginalPersonalDose เมื่อเพิ่มข้อมูล
                        //foreach (var i in projectPersonalDoses)
                        //{
                        //    i.OriginalPersonalDose = i.PersonalDose;
                        //}
                    }
                    else
                    {
                        ToastService.ShowError("Support Team Add Duplicatie");
                    }
                }
                else
                {
                    ToastService.ShowError("Please select a team or support team");
                }
            }
            catch (Exception e)
            {
                ToastService.ShowError($"ERR: {e.Message}");
            }
            Load.Hide();
        }

        public async Task OnAddProjectStock()
        {
            Load.Show();
            try
            {
                if (projectInventoryStock.ProjectStockNumber != null && projectInventoryStock.ProjectStockNumber != "")
                {
                    var a = await Http.GetFromJsonAsync<List<InventoryStock>>($"{Config["nurl"]}/api/GetInventoryStockByStockNumber/{projectInventoryStock.ProjectStockNumber}");
                    if (recordProject.ProjectInsStatusID == 3)
                    {
                        ToastService.ShowError("This project has been completed.");

                    }
                    else if (a.Any(x => x.IsActive != true))
                    {
                        ToastService.ShowError("Comsumable not available");
                    }
                    else if (!listInventoryStock.Any(i => i.InventoryStockNumber == projectInventoryStock.ProjectStockNumber))
                    {

                        if (projectInventoryStock.ProjectStockNumber != "" && projectInventoryStock.ProjectStockQuantity > 0 && a.Count() > 0 && projectInventoryStock.ProjectStockQuantity <= a.First().InventoryStockQuantity)
                        {
                            if (recordProject.ProjectInvsStatusID != 1)
                            {
                                ToastService.ShowError(" You have checckOut already done ! ");
                            }
                            else
                            {
                                projectInventoryStock.ProjectID = recordProject.ProjectID;
                                projectInventoryStock.ProjectStockID = a.First().InventoryStockID;
                                projectInventoryStock.ProjectStockNumber = a.First().InventoryStockNumber;
                                projectInventoryStock.RemainQuantity = projectInventoryStock.ProjectStockQuantity;
                                var respond = await Http.PostAsJsonAsync($"{Config["nurl"]}/api/RegisterProjectInventory", projectInventoryStock);
                                if (respond.StatusCode == System.Net.HttpStatusCode.OK)
                                {
                                    ToastService.ShowSuccess("Successfully add Project InventoryStock");

                                    projectInventoryStocks = await Http.GetFromJsonAsync<List<ProjectInventoryStock>>($"{Config["nurl"]}/api/GetProjectInventory/{recordProject.ProjectID}");
                                    foreach (var i in projectInventoryStocks)
                                    {

                                        this.listInventoryStock.AddRange(await Http.GetFromJsonAsync<IList<InventoryStock>>($"{Config["nurl"]}/api/GetInventoryStockByStockNumber/{i.ProjectStockNumber}"));
                                    }
                                    foreach (var i in listInventoryStock)
                                    {
                                        i.GetLookUp(AppData.inventorys);
                                    }
                                    projectInventoryStock.ProjectStockNumber = "";
                                    projectInventoryStock.ProjectStockQuantity = 0;
                                }
                            }

                        }
                        else { ToastService.ShowError("There is no remaining stock.! "); }
                    }
                    else
                    {
                        ToastService.ShowError("Comsumable StockNumber Duplicatie");
                    }
                }
                else
                {
                    ToastService.ShowError("Please select a Comsumable Stock");
                }
            }
            catch (Exception e)
            {
                ToastService.ShowError($"ERR: {e.Message}");
            }
            Load.Hide();
        }

        public async Task OnDeleteProjectTeam(int id)
        {


            if (recordProject.ProjectInsStatusID == 3)
            {
                await SaveDeleteProjectTeam();
            }
            else
            {
                deleteTeamID = id;
                ModalResponseConfirmDeleteTeam.Show();
            }
        }

        public async Task OnDeleteProjectPersonalDose(int id)
        {
            if (recordProject.ProjectInsStatusID == 3)
            {
                await SavaDeleteProjectPersonalDoseTeam();
            }
            else
            {
                deletePersonalDoseTeamID = id;
                ModalResponseConfirmDeletePersonalDoseTeam.Show();
            }



        }

        protected async Task SavaDeleteProjectPersonalDoseTeam()
        {
            if (recordProject.ProjectInsStatusID == 3)
            {
                ToastService.ShowError("This project has been completed.");
            }
            else
            {
                var respond = await Http.PostAsync($"{Config["nurl"]}/api/DeleteProjectPersonalDose/{deletePersonalDoseTeamID}", null);
                ToastService.ShowSuccess("Deleted ProjectPersonalDose Success");
                projectPersonalDoses = await Http.GetFromJsonAsync<List<ProjectPersonalDose>>($"{Config["nurl"]}/api/GetProjectPersonalDose/{recordProject.ProjectID}");


                ModalResponseConfirmDeletePersonalDoseTeam.Hide();
            }

        }

        public async Task OnDeletProjectSupport(int id)
        {

            if (recordProject.ProjectInsStatusID == 3)
            {
                await SaveDeleteProjectSupportTeam();
            }
            else
            {
                deleteSupportTeamID = id;
                ModalResponseConfirmDeleteSupportTeam.Show();
            }

        }

        public async Task OnDeleteProjectInstrument(string index)
        {

            Load.Show();
            try
            {
                if (recordProject.ProjectInsStatusID == 3)
                {
                    await SaveDeleteProjectInstrument();
                }
                else if (this.recordProject.ProjectInsStatusID != 1)
                {
                    await SaveDeleteProjectInstrument();
                }
                else
                {
                    //deleteInstrumentID = index;
                    int id = projectInstruments.Find(i => i.InstrumentNumber.ToString().ToLower().Contains(index.ToString().ToLower())).ProjectInstrumentID;
                    deleteInstrumentID = id;

                    //var respond = await Http.PostAsync($"{Config["nurl"]}/api/DeleteProjectInstrument/{id}", null);

                    //projectInstruments = await Http.GetFromJsonAsync<List<ProjectInstrument>>($"{Config["nurl"]}/api/GetProjectInstrument/{recordProject.ProjectID}");
                    //var resultLins = projectInstruments.OrderBy(i => i.InstrumentNumber).ToList();
                    //listInstrument = new List<Instrument>();
                    //foreach (var i in resultLins)
                    //{

                    //    this.listInstrument.AddRange(await Http.GetFromJsonAsync<IList<Instrument>>($"{Config["nurl"]}/api/GetInstrumentByInstrumentNumber/{i.InstrumentNumber}"));
                    //}

                    //if (this.listInstrument.Count() > 0)
                    //{

                    //    foreach (var i in this.listInstrument)
                    //    {
                    //        i.GetLookup(listInstrumentBrands, listInstrumentModels, listInstrumentAgencys, listInstrumentStatus, listInstrumentLocations);
                    //    }


                    //}


                    //ToastService.ShowSuccess("Deleted ProjectInstrument Success");

                    ModalResponseConfirmDeleteInstrument.Show();
                }



            }
            catch (Exception e)
            {

                ToastService.ShowError("ERR" + e.Message);
            }
            StateHasChanged();
            Load.Hide();
        }


        protected async Task SaveDeleteProjectTeam()
        {


            if (recordProject.ProjectInsStatusID == 3)
            {
                ToastService.ShowError("This project has been completed.");
            }

            else
            {

                var respond = await Http.PostAsync($"{Config["nurl"]}/api/DeleteProjectTeam/{deleteTeamID}", null);
                ToastService.ShowSuccess("Deleted ProjectTeam Success");
                teams = await Http.GetFromJsonAsync<List<ProjectTeam>>($"{Config["nurl"]}/api/GetProjectTeam/{recordProject.ProjectID}");
                eventSumPersonalDoses = await Http.GetFromJsonAsync<List<EventSumPersonalDose>>($"{Config["nurl"]}/api/GetEventSumPersonalDose/{recordProject.ProjectID}");

                ////อัปเดตค่า OriginalPersonalDose เมื่อลบข้อมูล
                //foreach (var i in teams)
                //{
                //    i.OriginalPersonalDose = i.PersonalDose;
                //}
                ModalResponseConfirmDeleteTeam.Hide();
            }

        }

        protected async Task SaveDeleteProjectSupportTeam()
        {
            //var resultEventID = await Http.GetFromJsonAsync<List<ProjectEventRecord>>($"{Config["nurl"]}/api/GetProjectEventRecord/{recordProject.ProjectID}");
            //var eventNumbers = new List<string>();
            //foreach (var ix in resultEventID)
            //{
            //    var eventSupportTeams = await Http.GetFromJsonAsync<List<EventSupportTeam>>($"{Config["nurl"]}/api/EventSupportTeam/{ix.EventID}");
            //    if (eventSupportTeams.Count > 0)
            //    {
            //        eventNumbers.Add(ix.EventNumber.ToString());
            //    }
            //}

            if (recordProject.ProjectInsStatusID == 3)
            {
                ToastService.ShowError("This project has been completed.");
            }
            else
            {

                var respond = await Http.DeleteAsync($"{Config["nurl"]}/api/ProjectSupportTeam/Project/{deleteSupportTeamID}");
                ToastService.ShowSuccess("Deleted Project SupportTeam Success");
                SupportTeam = await Http.GetFromJsonAsync<List<ProjectSupportTeam>>($"{Config["nurl"]}/api/ProjectSupportTeam/{recordProject.ProjectID}");
                eventSumPersonalDoses = await Http.GetFromJsonAsync<List<EventSumPersonalDose>>($"{Config["nurl"]}/api/GetEventSumPersonalDose/{recordProject.ProjectID}");
                ////อัปเดตค่า OriginalPersonalDose เมื่อลบข้อมูล
                //foreach (var i in SupportTeam)
                //{
                //    i.OriginalPersonalDose = i.PersonalDose;
                //}
                ModalResponseConfirmDeleteSupportTeam.Hide();



            }

        }

        protected async Task SaveDeleteProjectInstrument()
        {
            Load.Show();
            try
            {
                if (recordProject.ProjectInsStatusID == 3)
                {
                    ToastService.ShowError("This project has been completed.");
                }
                else if (this.recordProject.ProjectInsStatusID != 1)
                {
                    ToastService.ShowError("Can't Delete Instrument have checckout already done! ");
                }
                else
                {
                    var respond = await Http.PostAsync($"{Config["nurl"]}/api/DeleteProjectInstrument/{deleteInstrumentID}", null);

                    projectInstruments = await Http.GetFromJsonAsync<List<ProjectInstrument>>($"{Config["nurl"]}/api/GetProjectInstrument/{recordProject.ProjectID}");
                    var resultLins = projectInstruments.OrderBy(i => i.InstrumentNumber).ToList();
                    listInstrument = new List<Instrument>();
                    foreach (var i in resultLins)
                    {

                        this.listInstrument.AddRange(await Http.GetFromJsonAsync<IList<Instrument>>($"{Config["nurl"]}/api/GetInstrumentByInstrumentNumber/{i.InstrumentNumber}"));
                    }

                    if (this.listInstrument.Count() > 0)
                    {

                        foreach (var i in this.listInstrument)
                        {
                            i.GetLookup(listInstrumentBrands, listInstrumentModels, listInstrumentAgencys, listInstrumentStatus, listInstrumentLocations);
                        }


                    }


                    ToastService.ShowSuccess("Deleted ProjectInstrument Success");
                }


            }
            catch (Exception e)
            {

                ToastService.ShowError("ERR" + e.Message);
            }
            ModalResponseConfirmDeleteInstrument.Hide();
            StateHasChanged();
            Load.Hide();
        }

        public async Task OnUpdateProjectInventoryStock()
        {
            if (recordProject.ProjectInsStatusID == 3)
            {
                ToastService.ShowError("This project has been completed.");
            }
            else if (recordProject.ProjectInvsStatusID != 1)
            {
                ToastService.ShowError(" Cannot Update Consumable, You have checckout already done! ");
            }
            else
            {
                editProjectInventoryStock.RemainQuantity = editProjectInventoryStock.ProjectStockQuantity;
                var a = await Http.GetFromJsonAsync<List<InventoryStock>>($"{Config["nurl"]}/api/GetInventoryStockByStockNumber/{editProjectInventoryStock.ProjectStockNumber}");
                if (editProjectInventoryStock.ProjectStockQuantity <= a.First().InventoryStockQuantity)
                {
                    var respond = await Http.PutAsJsonAsync($"{Config["nurl"]}/api/UpdateProjectInventory/{editProjectInventoryStock.ProjectInventoryID}", editProjectInventoryStock);
                    if (respond.StatusCode == HttpStatusCode.OK)
                    {
                        //Remaining = a.First().InventoryStockQuantity;
                        ToastService.ShowSuccess("Update Project ComsumableStock Successfully");

                        projectInventoryStocks = await Http.GetFromJsonAsync<List<ProjectInventoryStock>>($"{Config["nurl"]}/api/GetProjectInventory/{recordProject.ProjectID}");
                        foreach (var i in projectInventoryStocks)
                        {
                            this.listInventoryStock.AddRange(await Http.GetFromJsonAsync<IList<InventoryStock>>($"{Config["nurl"]}/api/GetInventoryStockByStockNumber/{i.ProjectStockNumber}"));
                        }
                        foreach (var i in listInventoryStock)
                        {
                            i.GetLookUp(listInventories);
                        }
                    }
                    UpdateProjectInventory.Hide();
                }
                else
                {
                    ToastService.ShowError("There is no remaining stock.! ");
                }
            }


        }

        public async Task OnDeleteProjectInventoryStock(int id)
        {
            if (recordProject.ProjectInsStatusID == 3)
            {
                await SaveDeleteProjectInventoryStock();
            }
            else if (recordProject.ProjectInvsStatusID != 1)
            {
                await SaveDeleteProjectInventoryStock();
            }
            else
            {
                deleteInventoryStockID = id;
                ModalResponseConfirmDeleteInventory.Show();
                //var respond = await Http.PostAsync($"{Config["nurl"]}/api/DeleteProjectInventory/{id}", null);
                //if (respond.StatusCode == System.Net.HttpStatusCode.OK)
                //{
                //    ToastService.ShowSuccess("Deleted Project ComsumableStock Successfully");

                //    projectInventoryStocks = await Http.GetFromJsonAsync<List<ProjectInventoryStock>>($"{Config["nurl"]}/api/GetProjectInventory/{recordProject.ProjectID}");
                //    foreach (var i in projectInventoryStocks)
                //    {
                //        this.listInventoryStock.AddRange(await Http.GetFromJsonAsync<IList<InventoryStock>>($"{Config["nurl"]}/api/GetInventoryStockByStockNumber/{i.ProjectStockNumber}"));
                //    }
                //    foreach (var i in listInventoryStock)
                //    {
                //        i.GetLookUp(listInventories);
                //    }

                //}
            }

        }

        protected async Task SaveDeleteProjectInventoryStock()
        {
            if (recordProject.ProjectInsStatusID == 3)
            {
                ToastService.ShowError("This project has been completed.");
            }
            else if (recordProject.ProjectInvsStatusID != 1)

            {
                ToastService.ShowError("Can't Delete Consumable have checckout already done! ");
            }
            else
            {
                var respond = await Http.PostAsync($"{Config["nurl"]}/api/DeleteProjectInventory/{deleteInventoryStockID}", null);
                if (respond.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    ToastService.ShowSuccess("Deleted Project ComsumableStock Successfully");

                    projectInventoryStocks = await Http.GetFromJsonAsync<List<ProjectInventoryStock>>($"{Config["nurl"]}/api/GetProjectInventory/{recordProject.ProjectID}");
                    var resultINVS = projectInventoryStocks.OrderBy(i => i.ProjectStockNumber).ToList();
                    listInventoryStock = new List<InventoryStock>();
                    foreach (var i in resultINVS)
                    {

                        this.listInventoryStock.AddRange(await Http.GetFromJsonAsync<IList<InventoryStock>>($"{Config["nurl"]}/api/GetInventoryStockByStockNumber/{i.ProjectStockNumber}"));
                    }
                    if (this.listInventoryStock.Count() > 0)
                    {
                        foreach (var i in listInventoryStock)
                        {
                            i.GetLookUp(listInventories);
                        }
                    }


                    listInventories = AppData.inventorys;

                    ModalResponseConfirmDeleteInventory.Hide();
                }
            }

        }

        public async Task GetProjectInventoryById(int id)
        {
            if (recordProject.ProjectInsStatusID == 3)
            {
                await OnUpdateProjectInventoryStock();
            }
            else if (recordProject.ProjectInvsStatusID != 1)
            {
                await OnUpdateProjectInventoryStock();
            }
            else
            {
                var respond = await Http.GetFromJsonAsync<List<ProjectInventoryStock>>($"{Config["nurl"]}/api/GetProjectInventoryById/{id}");
                if (respond != null)
                {
                    editProjectInventoryStock = respond.First();
                    UpdateProjectInventory.Show();
                }
            }


        }

        protected async Task PostInstrumentCheckOut()
        {
            /*
            * ตรวจสอบ InstrumentStatusID ต้องเป็น Normal ทั้งหมดถึงจะกด CheckOut ได้
            */
            if (recordProject.ProjectInsStatusID == 3)
            {
                ToastService.ShowError("This project has been completed.");

            }
            else if (this.listInstrument.Count() > 0 && this.listInstrument.Any(i => i.InstrumentStatusID != 1))
            {
                ToastService.ShowError(" Some Instrument Can't Checkout. Please Checked All Instruments Are  Normal Status.");
            }
            else if (this.listInstrument.Count() == 0)
            {
                ToastService.ShowError("Haven't added any instruments.");
            }
            else if (this.recordProject.ProjectInsStatusID != 1)
            {
                ToastService.ShowError(" You have checckout already done ! ");
            }
            else
            {

                //var resultEventID = await Http.GetFromJsonAsync<List<ProjectEventRecord>>($"{Config["nurl"]}/api/GetProjectEventRecord/{recordProject.ProjectID}");
                //projectEventRecordID = resultEventID.First();
                //var resultEventINS = await Http.GetFromJsonAsync<List<EvntInstrument>>($"{Config["nurl"]}/api/GetEventInstrument/{projectEventRecordID.EventID}");
                //if (resultEventINS.Count == 0)
                //{
                //    ToastService.ShowError("Haven't added any Instruments to the Event!");
                //}

                HttpResponseMessage respond = new HttpResponseMessage(System.Net.HttpStatusCode.Unused);
                InstrumentCheckOut instrumentCheckOut;
                foreach (var i in listInstrument)
                {


                    instrumentCheckOut = new InstrumentCheckOut
                    {
                        InstrumentCheckOutGiveTo = AppData.UserID,
                        InstrumentCheckOutAction = 2,
                        InstrumentCheckOutDate = DateTime.Now,
                        InstrumentCheckOutReturnDate = recordProject.ProjectEndDate,
                        InstrumentCheckOutNote = "Use In ProjectNumber:" + recordProject.ProjectNumber + "  ProjectName : " + recordProject.ProjectName,
                        InstrumentNumber = i.InstrumentNumber,
                        IsStaff = true,
                        ByUserID = AppData.UserID
                    };


                    var checkinstrumentnumber = (await Http.GetFromJsonAsync<List<Instrument>>($"{Config["nurl"]}/api/GetInstrumentByInstrumentNumber/{instrumentCheckOut.InstrumentNumber}")).Find(i => i.InstrumentNumber == instrumentCheckOut.InstrumentNumber && i.InstrumentStatusID == 1);
                    if (checkinstrumentnumber == null)
                    {

                        ToastService.ShowError(" InstrumentNumber" + i.InstrumentNumber + " Can not checkout.");
                    }
                    else
                    {
                        respond = await Http.PostAsJsonAsync($"{Config["nurl"]}/api/RegisterInstrumentCheckOut", instrumentCheckOut);
                        if (respond.StatusCode == System.Net.HttpStatusCode.OK)
                        {

                            List<InstrumentCheckOut> checkout = await respond.Content.ReadFromJsonAsync<List<InstrumentCheckOut>>();
                            instrumentCheckOut = checkout.First();

                            i.InstrumentStatusID = 2;
                            //  record.setCheckOutInstrumentAll();


                            //string url = $"{Config["rurl"]}/api/InstrumentCheckOutReport?CheckOutID={instrumentCheckOut.InstrumentCheckOutID}&USerID={instrumentCheckOut.InstrumentCheckOutGiveTo}&s={(instrumentCheckOut.IsStaff ? 1 : 0) }&CSerID={AppData.UserID}";
                            //((IJSInProcessRuntime)jsRuntime).InvokeVoid("OpenURL", url);

                            ToastService.ShowSuccess($"Check Out Save {i.InstrumentNumber} Successfully");
                        }
                        else
                        {

                            ToastService.ShowError("ERR:" + respond.StatusCode);
                        }


                    }
                }

                if (respond.StatusCode == System.Net.HttpStatusCode.OK)
                {

                    //await OnputEvent();


                    projectInstruments = await Http.GetFromJsonAsync<List<ProjectInstrument>>($"{Config["nurl"]}/api/GetProjectInstrument/{recordProject.ProjectID}");
                    var resultLins = projectInstruments.OrderBy(i => i.InstrumentNumber).ToList();
                    listInstrument = new List<Instrument>();
                    foreach (var i in resultLins)
                    {
                        this.listInstrument.AddRange(await Http.GetFromJsonAsync<IList<Instrument>>($"{Config["nurl"]}/api/GetInstrumentByInstrumentNumber/{i.InstrumentNumber}"));

                    }
                    foreach (var i in listInstrument)
                    {
                        i.GetLookup(listInstrumentBrands, listInstrumentModels, listInstrumentAgencys, listInstrumentStatus, listInstrumentLocations);
                    }


                }

                //update only the ProjectStatusID field
                await UpdateCheckOutAllProjectStatus();

                // เรียกใช้ StateHasChanged เพื่อรีเรนเดอร์คอมโพเนนต์ใหม่
                StateHasChanged();

                ModalResponseConfirmCheckOutInstrument.Hide();

            }

        }

        private async Task SetUpdateProjectStatus()
        {
            var result = await _masterDataPhase2.GetMasterDataAsyncByID<RecordProject>("ProjectRecordByID", int.Parse(id));
            recordProject = result;
            updateProject.ProjectRegional = recordProject.ProjectRegional;
        }

        private async Task UpdateCheckOutAllProjectStatus()
        {
            var updatedRecordProject = new RecordProject();
            updatedRecordProject.ProjectID = recordProject.ProjectID; // Assuming you need to keep the same ProjectID
            updatedRecordProject.ProjectName = recordProject.ProjectName;
            updatedRecordProject.ProjectType = recordProject.ProjectType;
            updatedRecordProject.ProjectRegisteredDate = recordProject.ProjectRegisteredDate;
            updatedRecordProject.ProjectRegional = recordProject.ProjectRegional;
            updatedRecordProject.ProjectInformerName = recordProject.ProjectInformerName;
            updatedRecordProject.ProjectStartDate = recordProject.ProjectStartDate;
            updatedRecordProject.ProjectEndDate = recordProject.ProjectEndDate;
            updatedRecordProject.ProjectRegisteredBy = recordProject.ProjectRegisteredBy;
            updatedRecordProject.ProjectUpdatedBy = recordProject.ProjectUpdatedBy;
            updatedRecordProject.ProjectUpdatedDate = recordProject.ProjectUpdatedDate;
            updatedRecordProject.ProjectRecommend = recordProject.ProjectRecommend;
            updatedRecordProject.ProjectInsStatusID = 2; // Update the ProjectStatusID field with the new value
            updatedRecordProject.ProjectInvsStatusID = recordProject.ProjectInvsStatusID;

            // Perform the update
            var respond = await _masterDataPhase2.PutMasterDataAsync("PutProjectRecord", updatedRecordProject, recordProject.ProjectID);
            if (!string.IsNullOrEmpty(respond.ToString()))
            {
                await SetUpdateProjectStatus();
            }
        }

       

        protected async Task PostInstrumentCheckInAll()
        {
            HttpResponseMessage res = new HttpResponseMessage(System.Net.HttpStatusCode.Unused);
            InstrumentCheckIn instrumentCheckIn;
            foreach (var i in listInstrument)
            {
                instrumentCheckIn = new InstrumentCheckIn
                {
                    InstrumentNumber = i.InstrumentNumber,
                    InstrumentCheckInLocation = i.InstrumentLocationID,
                    InstrumentCheckInReturnDate = DateTime.Now,
                    InstrumentCheckInGiveTo = AppData.UserID,
                    IsStaff = true,
                    ByUserID = AppData.UserID
                };

                try
                {
                    var checkinstrumentnumber = (await Http.GetFromJsonAsync<List<Instrument>>($"{Config["nurl"]}/api/GetInstrumentByInstrumentNumber/{instrumentCheckIn.InstrumentNumber}"))
                                                    .Find(i => i.InstrumentNumber == instrumentCheckIn.InstrumentNumber && i.InstrumentStatusID != 1);
                    if (checkinstrumentnumber == null)
                    {
                        ToastService.ShowError("InstrumentNumber " + i.InstrumentNumber + " Cannot be checked in.");
                    }
                    else
                    {
                        res = await Http.PostAsJsonAsync($"{Config["nurl"]}/api/RegisterInstrumentCheckIn", instrumentCheckIn);
                        if (res.StatusCode == System.Net.HttpStatusCode.OK)
                        {
                            i.InstrumentStatusID = 1;
                            ToastService.ShowSuccess($"Check In Save {i.InstrumentNumber} Successfully");
                        }
                        else
                        {
                            ToastService.ShowError("ERR:" + res.StatusCode);
                        }
                    }
                }
                catch (Exception e)
                {
                    ToastService.ShowError($"ERR:{e.Message}");
                }
            }

            if (res.StatusCode == System.Net.HttpStatusCode.OK)
            {
                projectInstruments = await Http.GetFromJsonAsync<List<ProjectInstrument>>($"{Config["nurl"]}/api/GetProjectInstrument/{recordProject.ProjectID}");
                var resultLins = projectInstruments.OrderBy(i => i.InstrumentNumber).ToList();
                listInstrument = new List<Instrument>();
                foreach (var j in resultLins)
                {
                    this.listInstrument.AddRange(await Http.GetFromJsonAsync<IList<Instrument>>($"{Config["nurl"]}/api/GetInstrumentByInstrumentNumber/{j.InstrumentNumber}"));
                }
                foreach (var j in listInstrument)
                {
                    j.GetLookup(listInstrumentBrands, listInstrumentModels, listInstrumentAgencys, listInstrumentStatus, listInstrumentLocations);
                }

                await UpdateCheckInAllProjectStatus();

                StateHasChanged();

                ModalResponseConfirmCheckInInstrument.Hide();
                ModalResponseConfirmCheckInInstrumentNotEvent.Hide();
            }
        }

        protected async Task PostInstrumentCheckIn()
        {
            if (recordProject.ProjectInsStatusID == 3)
            {
                ToastService.ShowError("This project has been completed.");
            }
            else if (this.recordProject.ProjectInsStatusID == 1)
            {
                ToastService.ShowError("Haven't checked out ! ");
            }
            else if (this.recordProject.ProjectInsStatusID != 2)
            {
                ToastService.ShowError(" You have checckIn already done ! ");
            }
            else
            {
                try
                {
                    //var resultEventID = await Http.GetFromJsonAsync<List<ProjectEventRecord>>($"{Config["nurl"]}/api/GetProjectEventRecord/{recordProject.ProjectID}");
                    // ตรวจสอบว่ามีข้อมูลใน resultEventID หรือไม่
                    if (listprojectEventRecord != null && listprojectEventRecord.Count > 0)
                    {
                        projectEventRecordID = listprojectEventRecord.First();

                        Lins = await Http.GetFromJsonAsync<List<EvntInstrument>>($"{Config["nurl"]}/api/GetEventInstrument/{projectEventRecordID.EventID}");
                        if (Lins == null || Lins.Count == 0)
                        {
                            ToastService.ShowError("Haven't added any Instruments to the Event!");
                        }
                        else
                        {
                            ModalResponseConfirmCheckInInstrument.Show();
                        }
                    }
                    else
                    {

                        ModalResponseConfirmCheckInInstrumentNotEvent.Show();

                    }
                }
                catch (Exception e)
                {
                    ToastService.ShowError($"ERR:{e.Message}");
                }




            }

        }

        private async Task UpdateCheckInAllProjectStatus()
        {
            var updatedRecordProject = new RecordProject();
            updatedRecordProject.ProjectID = recordProject.ProjectID; // Assuming you need to keep the same ProjectID
            updatedRecordProject.ProjectName = recordProject.ProjectName;
            updatedRecordProject.ProjectType = recordProject.ProjectType;
            updatedRecordProject.ProjectRegisteredDate = recordProject.ProjectRegisteredDate;
            updatedRecordProject.ProjectRegional = recordProject.ProjectRegional;
            updatedRecordProject.ProjectInformerName = recordProject.ProjectInformerName;
            updatedRecordProject.ProjectStartDate = recordProject.ProjectStartDate;
            updatedRecordProject.ProjectEndDate = recordProject.ProjectEndDate;
            updatedRecordProject.ProjectRegisteredBy = recordProject.ProjectRegisteredBy;
            updatedRecordProject.ProjectUpdatedBy = recordProject.ProjectUpdatedBy;
            updatedRecordProject.ProjectUpdatedDate = recordProject.ProjectUpdatedDate;
            updatedRecordProject.ProjectRecommend = recordProject.ProjectRecommend;
            updatedRecordProject.ProjectInsStatusID = 3; // Update the ProjectStatusID field with the new value
            updatedRecordProject.ProjectInvsStatusID = recordProject.ProjectInvsStatusID;

            // Perform the update
            var respond = await _masterDataPhase2.PutMasterDataAsync("PutProjectRecord", updatedRecordProject, recordProject.ProjectID);
            if (!string.IsNullOrEmpty(respond.ToString()))
            {
                await SetUpdateProjectStatus();
            }
        }

        protected async Task PostInventoryStockCheckOut()
        {
            if (recordProject.ProjectInsStatusID == 3)
            {
                ToastService.ShowError("This project has been completed.");
            }
            else if (this.listInventoryStock.Count() == 0)
            {
                ToastService.ShowError("Haven't added any consumable.");
            }
            else if (recordProject.ProjectInvsStatusID != 1)
            {
                ToastService.ShowError("You have checkOut already done!");
            }
            else
            {
                // สมมุติว่ามี projectInventoryStocks อย่างน้อยหนึ่งรายการ
                var firstInventoryStock = projectInventoryStocks.FirstOrDefault();

                if (firstInventoryStock != null)
                {
                    InventoryStockCheckOut inventoryStockCheckOut = new InventoryStockCheckOut
                    {
                        InventoryStockCheckOutGiveTo = AppData.UserID,
                        InventoryStockCheckOutAction = 1,
                        InventoryStockCheckOutDate = DateTime.Now,
                        ByUserID = AppData.UserID,
                        InventoryStockNumber = firstInventoryStock.ProjectStockNumber // ตั้งค่า InventoryStockNumber ให้เท่ากับ ProjectStockNumber ของรายการแรก
                    };

                    try
                    {
                        using var respond = await Http.PostAsJsonAsync($"{Config["nurl"]}/api/RegisterInventoryCheckOut", inventoryStockCheckOut);

                        if (respond.StatusCode == System.Net.HttpStatusCode.OK)
                        {
                            List<InventoryStockCheckOut> CheckOut = await respond.Content.ReadFromJsonAsync<List<InventoryStockCheckOut>>();
                            inventoryStockCheckOut = CheckOut.First();

                            inventoryStockCheckOut.InventoryStockNumber = CheckOut.First().InventoryStockNumber;

                            foreach (var i in projectInventoryStocks)
                            {
                                await Http.PostAsJsonAsync($"{Config["nurl"]}/api/RegisterInventoryStockCheckOutitem", new InventoryStockCheckOutItem
                                {
                                    InventoryStockQuantity = i.ProjectStockQuantity,
                                    InventoryStockNumber = i.ProjectStockNumber,
                                    InventoryStockCheckOutID = inventoryStockCheckOut.InventoryStockCheckOutID
                                });

                                ToastService.ShowSuccess($"CheckOut {i.ProjectStockNumber} Successfully");

                            }
                            await SetNotification();
                            //หน่อยบอกให้ Hide code GenReport Auto 
                            //string url = $"{Config["rurl"]}/api/InventoryCheckOutReport?CheckOutID={inventoryStockCheckOut.InventoryStockCheckOutID}&USerID={inventoryStockCheckOut.InventoryStockCheckOutGiveTo}";
                            //await jsRuntime.InvokeVoidAsync("OpenURL", url);
                        }
                        else
                        {
                            ToastService.ShowError("Error!");
                        }

                        await UpdateCheckOutAllInvsProjectStatus();
                        StateHasChanged();
                        ModalResponseConfirmCheckOutInventory.Hide();
                    }
                    catch (Exception e)
                    {
                        ToastService.ShowError($"ERR: {e.Message}");
                    }
                }
                else
                {
                    ToastService.ShowError("No inventory stock available to check out.");
                }
            }
        }

        private async Task UpdateCheckOutAllInvsProjectStatus()
        {
            var updatedRecordProject = new RecordProject();
            updatedRecordProject.ProjectID = recordProject.ProjectID; // Assuming you need to keep the same ProjectID
            updatedRecordProject.ProjectName = recordProject.ProjectName;
            updatedRecordProject.ProjectType = recordProject.ProjectType;
            updatedRecordProject.ProjectRegisteredDate = recordProject.ProjectRegisteredDate;
            updatedRecordProject.ProjectRegional = recordProject.ProjectRegional;
            updatedRecordProject.ProjectInformerName = recordProject.ProjectInformerName;
            updatedRecordProject.ProjectStartDate = recordProject.ProjectStartDate;
            updatedRecordProject.ProjectEndDate = recordProject.ProjectEndDate;
            updatedRecordProject.ProjectRegisteredBy = recordProject.ProjectRegisteredBy;
            updatedRecordProject.ProjectUpdatedBy = recordProject.ProjectUpdatedBy;
            updatedRecordProject.ProjectUpdatedDate = recordProject.ProjectUpdatedDate;
            updatedRecordProject.ProjectRecommend = recordProject.ProjectRecommend;
            updatedRecordProject.ProjectInsStatusID = recordProject.ProjectInsStatusID; // Update the ProjectStatusID field with the new value
            updatedRecordProject.ProjectInvsStatusID = 2;

            // Perform the update
            var respond = await _masterDataPhase2.PutMasterDataAsync("PutProjectRecord", updatedRecordProject, recordProject.ProjectID);
            if (!string.IsNullOrEmpty(respond.ToString()))
            {
                await SetUpdateProjectStatus();
            }
        }


        public async Task SetNotification()
        {
            //****ที่เพิ่มเข้ามาในอันนี้ คือ รีเฟรส ข้อมูลที่ทำการ CheckOut Consumable โดยทำการ Get ข้อมูลของ MinStock,Inventory มาอีกครั้งในตอน CheckOut Consumable*********
            AppData.inventorys = await _masterData.GetMasterDataAsync<Inventory>("Inventory");
            AppData.inventoryBrands = await _masterData.GetMasterDataAsync<InventoryBrand>("InventoryBrand");
            AppData.inventoryAgencys = await _masterData.GetMasterDataAsync<InventoryAgency>("InventoryAgency");
            AppData.mins = await Http.GetFromJsonAsync<List<MinStock>>($"{Config["nurl"]}/api/GetInventoryminStock");

            foreach (var i in AppData.inventorys)
            {
                i.Getlookup(AppData.inventoryBrands, AppData.inventoryAgencys);
            }

            listInventory = AppData.inventorys;
            inventoryBrands = AppData.inventoryBrands;
            inventoryAgencys = AppData.inventoryAgencys;
            listMinStock = AppData.mins;
            ///***********************************************************************************************************************************
        }

        //protected async Task UpdateProjectTeam()
        //{
        //    if (this.teams.Count() == 0)
        //    {
        //        ToastService.ShowError("There are no items.");
        //    }
        //    else
        //    {


        //        HttpResponseMessage respond = new HttpResponseMessage(System.Net.HttpStatusCode.Unused);
        //        ProjectTeam projectTeam;

        //        foreach (var i in teams)
        //        {
        //            if (i.PersonalDose != i.OriginalPersonalDose)
        //            {
        //                // อัปเดตค่า OriginalPersonalDose ก่อน
        //                i.OriginalPersonalDose = i.PersonalDose;

        //                // ทำการอัปเดตข้อมูล
        //                projectTeam = new ProjectTeam
        //                {
        //                    ProjectID = i.ProjectID,
        //                    UserID = i.UserID,
        //                    PersonalDose = i.PersonalDose,
        //                    PersonalDoseUnitID = i.PersonalDoseUnitID,
        //                    PersonalDoseDate = i.PersonalDoseDate
        //                };

        //                respond = await Http.PutAsJsonAsync<ProjectTeam>($"{Config["nurl"]}/api/RegisterProjectTeam/{i.ProjectTeamID}", projectTeam);
        //                if (respond.StatusCode == System.Net.HttpStatusCode.OK)
        //                {
        //                    ToastService.ShowSuccess($"Personal Dose Save {(accounts.Find(x => x.UserID == i.UserID) != null ? accounts.Find(x => x.UserID == i.UserID).FirstName : "-")} Successfully");
        //                }
        //                else
        //                {
        //                    ToastService.ShowError("ERR:" + respond.StatusCode);
        //                }
        //            }
        //        }

        //    }
        //}


        //protected async Task UpdateProjectSupportTeam()
        //{
        //    if (this.SupportTeam.Count() == 0)
        //    {
        //        ToastService.ShowError("There are no items.");
        //    }
        //    else
        //    {


        //        HttpResponseMessage respond = new HttpResponseMessage(System.Net.HttpStatusCode.Unused);
        //        ProjectSupportTeam projectSupportTeam;

        //        foreach (var i in SupportTeam)
        //        {
        //            if (i.PersonalDose != i.OriginalPersonalDose)
        //            {
        //                // อัปเดตค่า OriginalPersonalDose ก่อน
        //                i.OriginalPersonalDose = i.PersonalDose;

        //                // ทำการอัปเดตข้อมูล
        //                projectSupportTeam = new ProjectSupportTeam
        //                {
        //                    ProjectID = i.ProjectID,
        //                    Name = i.Name,
        //                    Position = i.Position,
        //                    Department = i.Department,
        //                    PhoneNumber = i.PhoneNumber,
        //                    Email = i.Email,
        //                    Order = i.Order,
        //                    PersonalDose = i.PersonalDose,
        //                    PersonalDoseUnitID = i.PersonalDoseUnitID,
        //                    PersonalDoseDate = i.PersonalDoseDate
        //                };

        //                respond = await Http.PutAsJsonAsync<ProjectSupportTeam>($"{Config["nurl"]}/api/ProjectSupportTeam/{i.ProjectSupportTeamID}", projectSupportTeam);
        //                if (respond.StatusCode == System.Net.HttpStatusCode.OK)
        //                {
        //                    ToastService.ShowSuccess($"Personal Dose Save {i.Name} Successfully");
        //                }
        //                else
        //                {
        //                    ToastService.ShowError("ERR:" + respond.StatusCode);
        //                }
        //            }
        //        }

        //    }
        //}


        protected async Task UpdateProjectPersonalDoseTeamAndSupportTeam()
        {

            if (recordProject.ProjectInsStatusID == 3)
            {
                ToastService.ShowError("This project has been completed.");
            }
            else if (projectPersonalDoses.Count == 0)
            {
                ToastService.ShowError("Please select a team or support team");
            }
            else
            {
                HttpResponseMessage respondUpdate = new HttpResponseMessage(System.Net.HttpStatusCode.Unused);
                HttpResponseMessage respondRegister = new HttpResponseMessage(System.Net.HttpStatusCode.Unused);
                ProjectPersonalDose projectpersonalDose;
                PersonalDose personalDose = new PersonalDose();

                currentDate = DateTime.Now.ToString("yyyy-MM-dd");
                currentTime = DateTime.Now.ToString("HH:mm");

                // Condition to convert time to 24-hour format
                if (DateTime.TryParseExact(currentTime, "HH:mm", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime convertedTime))
                    Time_Current = convertedTime;

                if (!string.IsNullOrEmpty(currentDate))
                {
                    personalDose.CreateRegister = DateTime.ParseExact(currentDate, "yyyy-MM-dd", CultureInfo.InvariantCulture);
                }

                DateTime combinedCurrentDateTime = personalDose.CreateRegister.Date + Time_Current.TimeOfDay;


                // Calculate duration
                TimeSpan duration = recordProject.ProjectEndDate - recordProject.ProjectStartDate;

                // Get total hours and minutes
                int totalMinutes = (int)Math.Max(duration.TotalMinutes, 0);
                int totalHours = (int)Math.Floor(duration.TotalHours);
                int minutes = totalMinutes % 60;

                // Format the duration
                string formattedDuration = $"{totalHours} ชั่วโมง {minutes} นาที";

                foreach (var i in projectPersonalDoses)
                {

                    // อัปเดตค่า OriginalPersonalDose ก่อน
                    //i.OriginalPersonalDose = i.PersonalDose;

                    // ทำการอัปเดตข้อมูล
                    projectpersonalDose = new ProjectPersonalDose
                    {
                        ProjectID = i.ProjectID,
                        UserID = i.UserID,
                        SupportTeamID = i.SupportTeamID,
                        PersonalDose = i.PersonalDose,
                        PersonalDoseUnitID = i.PersonalDoseUnitID,
                        PersonalDoseInstrumentName = i.PersonalDoseInstrumentName,
                        PersonalDoseDate = i.PersonalDoseDate,
                        IsTeam = i.IsTeam
                    };



                    personalDose = new PersonalDose
                    {
                        CreateRegister = combinedCurrentDateTime,
                        UserID = i.UserID,
                        UserSupportTeamID = i.SupportTeamID,
                        StartDatetime = recordProject.ProjectStartDate,
                        EndDatetime = recordProject.ProjectEndDate,
                        LocationName = (recordEventProvinces.Find(x => x.ProvinceGeographyID == recordProject.ProjectRegional) != null ? recordEventProvinces.Find(x => x.ProvinceGeographyID == recordProject.ProjectRegional).ProvinceENName : "-"),
                        InstrumentName = i.PersonalDoseInstrumentName,
                        DoseAccumulation = i.PersonalDose,
                        DoseAccumulationUnit = i.PersonalDoseUnitID,
                        TotalHour = formattedDuration,
                        FromProjectPersonalDose = i.ProjectID,

                    };


                    respondUpdate = await Http.PutAsJsonAsync<ProjectPersonalDose>($"{Config["nurl"]}/api/RegisterProjectPersonalDose/{i.ProjectPersonalDoseID}", projectpersonalDose);

                    respondRegister = await Http.PostAsJsonAsync($"{Config["nurl"]}/api/PersonalDoses", personalDose);

                    if (respondRegister.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        if (i.UserID != new Guid("00000000-0000-0000-0000-000000000000"))
                        {
                            ToastService.ShowSuccess($"Personal Dose Save {(accounts.Find(x => x.UserID == i.UserID) != null ? accounts.Find(x => x.UserID == i.UserID).FirstName : "-")} Successfully");
                        }
                        else if (i.SupportTeamID != 0)
                        {
                            ToastService.ShowSuccess($"Personal Dose Save {(SupportTeam.Find(x => x.ProjectSupportTeamID == i.SupportTeamID) != null ? SupportTeam.Find(x => x.ProjectSupportTeamID == i.SupportTeamID).Name : "-")} Successfully");
                        }
                    }

                    //if (respond.StatusCode == System.Net.HttpStatusCode.OK)
                    //{
                    //    if (i.UserID != new Guid("00000000-0000-0000-0000-000000000000"))
                    //    {
                    //        ToastService.ShowSuccess($"Personal Dose Save {(accounts.Find(x => x.UserID == i.UserID) != null ? accounts.Find(x => x.UserID == i.UserID).FirstName : "-")} Successfully");
                    //    }
                    //    else if (i.SupportTeamID != 0)
                    //    {
                    //        ToastService.ShowSuccess($"Personal Dose Save {(SupportTeam.Find(x => x.ProjectSupportTeamID == i.SupportTeamID) != null ? SupportTeam.Find(x => x.ProjectSupportTeamID == i.SupportTeamID).Name : "-")} Successfully");
                    //    }

                    //}
                    //else
                    //{
                    //    ToastService.ShowError("ERR:" + respond.StatusCode);
                    //}

                }
            }


        }


        protected async Task ConfirmInsturmentCheckOutAll()
        {
            if (recordProject.ProjectInsStatusID == 3 || recordProject.ProjectInsStatusID != 1 || this.listInstrument.Count() == 0)
            {
                await PostInstrumentCheckOut();
            }
            else
            {
                ModalResponseConfirmCheckOutInstrument.Show();
            }
        }


        protected async Task ConfirmInventoryStockCheckOut()
        {
            if (recordProject.ProjectInsStatusID == 3)
            {
                await PostInventoryStockCheckOut();
            }
            else if (this.listInventoryStock.Count() == 0)
            {
                await PostInventoryStockCheckOut();
            }
            else if (recordProject.ProjectInvsStatusID != 1)
            {
                await PostInventoryStockCheckOut();
            }
            else
            {
                ModalResponseConfirmCheckOutInventory.Show();
            }
        }



    }
}
