using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;

namespace RapidNRIMs.Services
{
    public class MasterData : IMasterData
    {
        /// <summary>
        /// inject interface
        /// </summary>
        private readonly HttpClient _http;
        private readonly IConfiguration _configuration;

        public MasterData(HttpClient http, IConfiguration configuration)
        {
            _http = http;
            _configuration = configuration;
        }

        /// <summary>
        /// GetMasterDataAsync
        /// </summary>
        /// <typeparam name="TModel"></typeparam>
        /// <param name="key"></param>
        /// <returns></returns>
        public async Task<List<TModel>> GetMasterDataAsync<TModel>(string key)
        {
            string path = $"{_configuration["nurl"]}/api/";
            string service = "";

            switch (key)
            {
                case "EventType":
                    service = "EventType/GetAllEventTypes";
                    break;
                case "EventResultAll":
                    service = "GetEventResult";
                    break;
                case "Instrument":
                    service = "GetInstrument";
                    break;
                case "InstrumentAction":
                    service = "InstrumentAction/GetAllInstrumentActions";
                    break;
                case "InstrumentAgency":
                    service = "InstrumentAgency/GetAllInstrumentAgencies";
                    break;
                case "InstrumentBrand":
                    service = "InstrumentBrand/GetAllInstrumentBrands";
                    break;
                case "InstrumentCatagory":
                    service = "InstrumentCatagory/GetAllInstrumentCatagory";
                    break;
                case "InstrumentLocation":
                    service = "InstrumentLocation/GetAllInstrumentLocations";
                    break;
                case "InstrumentModel":
                    service = "InstrumentModel/GetAllInstrumentModels";
                    break;
                case "InstrumentType":
                    service = "InstrumentType/GetAllInstrumentType";
                    break;
                case "InstrumentCheckListType":
                    service = "InstrumentCheckListType/GetAllInstrumentCheckListType";
                    break;
                case "InstrumentUnit":
                    service = "InstrumentUnit/GetAllInstrumentUnits";
                    break;
                case "InstrumentMapCheckListType":
                    service = "InstrumentMapCheckListType";
                    break;
                case "InstrumentCheckOut":
                    service = "GetInstrumentCheckOut";
                    break;
                case "Inventory":
                    service = "GetInventory/GetAllInventories";
                    break;
                case "InventoryAction":
                    service = "InventoryAction/GetAllInventoryActions";
                    break;
                case "InventoryAgency":
                    service = "InventoryAgency/GetAllInventoryAgencys";
                    break;
                case "InventoryBrand":
                    service = "InventoryBrand/GetAllInventoryBrands";
                    break;
                case "InventoryLocation":
                    service = "InventoryLocation/GetAllInventoryLocations";
                    break;
                case "InventoryStockType":
                    service = "InventoryStockType/GetAllInventoryStockTypes";
                    break;
                case "RadiationSourceLocation":
                    service = "RadiationSourceLocation/GetAllRadiationSourceLocations";
                    break;
                case "RadiationSourceType":
                    service = "RadiationSourceType/GetAllRadiationSourceTypes";
                    break;
                case "RadiationSourceAgency":
                    service = "RadiationSourceAgency/GetAllRadiationSourceAgencys";
                    break;
                case "RadiationSourceUnit":
                    service = "RadiationSourceUnit/GetAllRadiationSourceUnits";
                    break;
                case "RadiationSourceDoseUnit":
                    service = "RadiationSourceDoseUnit/GetAllRadiationSourceDoseUnits";
                    break;
                case "RadiationSourceCheckOutAction":
                    service = "GetRadiationSourceCheckOutAction";
                    break;
                case "ProjectType":
                    service = "ProjectType/GetAllProjectTypes";
                    break;
                case "ProjectRecord":
                    service = "ProjectRecord/GetAllProjectRecords";
                    break;
                case "Regional":
                    service = "Regional/GetAllRegionals";
                    break;
                case "RecordEventUnit":
                    service = "RecordEventUnit/GetAllRecordEventUnits";
                    break;
                case null:
                    break;
            }
            var responseMessage = await _http.GetAsync($"{path}{service}");
            if (responseMessage.StatusCode == HttpStatusCode.NotFound)
            {
                return null;
            }
            else
            {
                var content = await responseMessage.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<List<TModel>>(content);
            }
        }

        /// <summary>
        /// GetAllActiveMasterDataAsync
        /// </summary>
        /// <typeparam name="TModel"></typeparam>
        /// <param name="key"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public async Task<List<TModel>> GetAllActiveMasterDataAsync<TModel>(string key)
        {
            string path = $"{_configuration["nurl"]}/api/";
            string service = "";

            switch (key)
            {
                case "ActiveEventType":
                    service = "EventType/GetAllActiveEventTypes";
                    break;
                case "ActiveInstrumentBrand":
                    service = "InstrumentBrand/GetAllActiveInstrumentBrands";
                    break;
                case "ActiveInstrumentCheckListType":
                    service = "InstrumentCheckListType/GetAllActiveInstrumentCheckListType";
                    break;
                case "ActiveInstrumentModel":
                    service = "InstrumentModel/GetAllActiveInstrumentModels";
                    break;
                case "ActiveInstrumentType":
                    service = "InstrumentType/GetAllActiveInstrumentType";
                    break;
                case "ActiveInstrumentUnit":
                    service = "InstrumentUnit/GetAllActiveInstrumentUnits";
                    break;
                case "ActiveInstrumentAction":
                    service = "InstrumentAction/GetAllActiveInstrumentActions";
                    break;
                case "ActiveInstrumentAgencies":
                    service = "InstrumentAgency/GetAllActiveInstrumentAgencies";
                    break;
                case "ActiveInstrumentCategory":
                    service = "InstrumentCatagory/GetAllActiveInstrumentCatagory";
                    break;
                case "ActiveInstrumentLocation":
                    service = "InstrumentLocation/GetAllActiveInstrumentLocation";
                    break;
                case "ActiveInventory":
                    service = "GetInventory/GetAllActiveInventories";
                    break;
                case "ActiveInventoryAction":
                    service = "InventoryAction/GetAllActiveInventoryActions";
                    break;
                case "ActiveInventoryAgency":
                    service = "InventoryAgency/GetAllActiveInventoryAgencys";
                    break;
                case "ActiveInventoryBrand":
                    service = "InventoryBrand/GetAllActiveInventoryBrands";
                    break;
                case "ActiveInventoryLocation":
                    service = "InventoryLocation/GetAllActiveInventoryLocations";
                    break;
                case "ActiveInventoryStockType":
                    service = "InventoryStockType/GetAllActiveInventoryStockTypes";
                    break;
                case "ActiveRadiationSourceLocations":
                    service = "RadiationSourceLocation/GetAllActiveRadiationSourceLocations";
                    break;
                case "ActiveRadiationSourceTypes":
                    service = "RadiationSourceType/GetAllActiveRadiationSourceTypes";
                    break;
                case "ActiveRadiationSourceAgencys":
                    service = "RadiationSourceAgency/GetAllActiveRadiationSourceAgencys";
                    break;
                case "ActiveRadiationSourceUnit":
                    service = "RadiationSourceUnit/GetAllActiveRadiationSourceUnits";
                    break;
                case "ActiveRadiationSourceDoseUnit":
                    service = "RadiationSourceDoseUnit/GetAllActiveRadiationSourceDoseUnits";
                    break;
                case "ActiveRadiationSourceCheckOutAction":
                    service = "RadiationSourceCheckOutAction/GetAllActiveRadiationSourceCheckOutActions";
                    break;
                case "ActiveProjectType":
                    service = "ProjectType/GetActiveProjectTypes";
                    break;
                case "ActiveProjectRecord":
                    service = "ProjectRecord/GetAllActiveProjectRecords";
                    break;
                case null:
                    break;
            }
            var responseMessage = await _http.GetAsync($"{path}{service}");
            if (responseMessage.StatusCode == HttpStatusCode.NotFound)
            {
                return null;
            }
            else
            {
                var content = await responseMessage.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<List<TModel>>(content);
            }
        }

        /// <summary>
        /// GetMasterDataAsyncByID
        /// </summary>
        /// <typeparam name="TModel"></typeparam>
        /// <param name="key"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<TModel> GetMasterDataAsyncByID<TModel>(string key, int? id)
        {
            string path = $"{_configuration["nurl"]}/api/";
            string service = "";

            switch (key)
            {
                case "EventTypeByID":
                    service = $"EventType/{id}";
                    break;
                case "InstrumentActionByID":
                    service = $"InstrumentAction/{id}";
                    break;
                case "InstrumentAgencyByID":
                    service = $"InstrumentAgency/{id}";
                    break;
                case "InstrumentBrandByID":
                    service = $"InstrumentBrand/{id}";
                    break;
                case "InstrumentCategoryByID":
                    service = $"InstrumentCatagory/{id}";
                    break;
                case "InstrumentLocationByID":
                    service = $"InstrumentLocation/{id}";
                    break;
                case "InstrumentModelByID":
                    service = $"InstrumentModel/{id}";
                    break;
                case "InstrumentTypeByID":
                    service = $"InstrumentType/{id}";
                    break;
                case "InstrumentCheckListTypeByID":
                    service = $"InstrumentCheckListType/{id}";
                    break;
                case "InstrumentCheckListResultByID":
                    service = $"InstrumentCheckListResult/{id}";
                    break;
                case "InstrumentUnitByID":
                    service = $"InstrumentUnit/{id}";
                    break;
                case "InventoryByID":
                    service = $"GetInventory/{id}";
                    break;
                case "InventoryActionByID":
                    service = $"InventoryAction/{id}";
                    break;
                case "InventoryAgencyByID":
                    service = $"InventoryAgency/{id}";
                    break;
                case "InventoryBrandByID":
                    service = $"InventoryBrand/{id}";
                    break;
                case "InventoryLocationByID":
                    service = $"InventoryLocation/{id}";
                    break;
                case "InventoryStockTypeByID":
                    service = $"InventoryStockType/{id}";
                    break;
                case "RadiationSourceLocationByID":
                    service = $"RadiationSourceLocation/{id}";
                    break;
                case "RadiationSourceTypeByID":
                    service = $"RadiationSourceType/{id}";
                    break;
                case "RadiationSourceAgencyByID":
                    service = $"RadiationSourceAgency/{id}";
                    break;
                case "RadiationSourceUnitByID":
                    service = $"RadiationSourceUnit/{id}";
                    break;
                case "RadiationSourceDoseUnitByID":
                    service = $"RadiationSourceDoseUnit/{id}";
                    break;
                case "RadiationSourceCheckOutActionByID":
                    service = $"RadiationSourceCheckOutAction/{id}";
                    break;
                case "ProjectTypeByID":
                    service = $"ProjectType/{id}";
                    break;
                case "ProjectRecordByID":
                    service = $"ProjectRecord/{id}";
                    break;
                case "EventResultByID":
                    service = $"GetEventResult/single/{id}";
                    break;
                case null:
                    break;
            }

            var responseMessage = await _http.GetAsync($"{path}{service}");
            var content = responseMessage.Content.ReadAsStringAsync().Result;
            if (responseMessage.StatusCode == HttpStatusCode.NotFound || responseMessage.StatusCode == HttpStatusCode.BadRequest)
            {
                var result = "{\"content\":\"" + content + "\"}";
                return JsonConvert.DeserializeObject<TModel>(result);
            }
            else
            {
                var result = await responseMessage.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<TModel>(result);

            }
        }

        /// <summary>
        /// GetMasterDataAsyncFirstByID(ในกรณีที่ Service api ตัวเก่ามัน return ออกมาเป็น List)
        /// </summary>
        /// <typeparam name="TModel"></typeparam>
        /// <param name="key"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public async Task<List<TModel>> GetMasterDataAsyncFirstByID<TModel>(string key, int? id)
        {
            string path = $"{_configuration["nurl"]}/api/";
            string service = "";

            switch (key)
            {
                case "InstrumentCheckListResultByID":
                    service = $"GetInstrumentChecklistResult/{id}";
                    break;
                case null:
                    break;
            }

            var responseMessage = await _http.GetAsync($"{path}{service}");
            if (responseMessage.StatusCode == HttpStatusCode.NotFound)
            {
                return null;
            }
            else
            {
                var result = await responseMessage.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<List<TModel>>(result);
            }
        }

        /// <summary>
        /// PostMasterDataAsync
        /// </summary>
        /// <typeparam name="TModel"></typeparam>
        /// <param name="key"></param>
        /// <param name="model"></param>
        /// <returns></returns>
        public async Task<TModel> PostMasterDataAsync<TModel>(string key, TModel model)
        {
            string path = $"{_configuration["nurl"]}/api/";
            string service = "";

            switch (key)
            {
                case "PostEventType":
                    service = "EventType";
                    break;
                case "PostInstrumentAction":
                    service = "InstrumentAction";
                    break;
                case "PostInstrumentAgency":
                    service = "InstrumentAgency";
                    break;
                case "PostInstrumentBrand":
                    service = "InstrumentBrand";
                    break;
                case "PostInstrumentCategory":
                    service = "InstrumentCatagory";
                    break;
                case "PostInstrumentLocation":
                    service = "InstrumentLocation";
                    break;
                case "PostInstrumentModel":
                    service = "InstrumentModel";
                    break;
                case "PostInstrumentType":
                    service = "InstrumentType";
                    break;
                case "PostInstrumentCheckListType":
                    service = "InstrumentCheckListType";
                    break;
                case "PostInstrumentUnit":
                    service = "InstrumentUnit";
                    break;
                case "PostInventory":
                    service = "GetInventory";
                    break;
                case "PostInventoryAction":
                    service = "InventoryAction";
                    break;
                case "PostInventoryAgency":
                    service = "InventoryAgency";
                    break;
                case "PostInventoryBrand":
                    service = "InventoryBrand";
                    break;
                case "PostInventoryLocation":
                    service = "InventoryLocation";
                    break;
                case "PostInventoryStockType":
                    service = "InventoryStockType";
                    break;
                case "PostRadiationSourceLocation":
                    service = "RadiationSourceLocation";
                    break;
                case "PostRadiationSourceType":
                    service = "RadiationSourceType";
                    break;
                case "PostRadiationSourceAgency":
                    service = "RadiationSourceAgency";
                    break;
                case "PostRadiationSourceUnit":
                    service = "RadiationSourceUnit";
                    break;
                case "PostRadiationSourceDoseUnit":
                    service = "RadiationSourceDoseUnit";
                    break;
                case "PostRadiationSourceCheckOutAction":
                    service = "RadiationSourceCheckOutAction";
                    break;
                case "PostInventoryCheckIn":
                    service = "RegisterInventoryCheckIn";
                    break;
                case "PostProjectType":
                    service = "ProjectType";
                    break;
                case "PostProjectRecord":
                    service = "ProjectRecord";
                    break;
                case null:
                    break;
            }

            var json = JsonConvert.SerializeObject(model);
            var con = new StringContent(json, Encoding.UTF8, "application/json"); 
             var response = await _http.PostAsync($"{path}{service}", con);
            if (response.StatusCode == HttpStatusCode.NotFound)
            {
                return default;
            }
            else
            {
                var content = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<TModel>(content);
            }
        }

        /// <summary>
        /// PutMasterDataAsync
        /// </summary>
        /// <typeparam name="TModel"></typeparam>
        /// <param name="key"></param>
        /// <param name="model"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<TModel> PutMasterDataAsync<TModel>(string key, TModel model , int? id)
        {
            string path = $"{_configuration["nurl"]}/api/";
            string service = "";

            switch (key)
            {
                case "PutEventType":
                    service = $"EventType/{id}";
                    break;
                case "PutInstrumentAction":
                    service = $"InstrumentAction/{id}";
                    break;
                case "PutInstrumentAgency":
                    service = $"InstrumentAgency/{id}";
                    break;
                case "PutInstrumentBrand":
                    service = $"InstrumentBrand/{id}";
                    break;
                case "PutInstrumentCategory":
                    service = $"InstrumentCatagory/{id}";
                    break;
                case "PutInstrumentLocation":
                    service = $"InstrumentLocation/{id}";
                    break;
                case "PutInstrumentModel":
                    service = $"InstrumentModel/{id}";
                    break;
                case "PutInstrumentType":
                    service = $"InstrumentType/{id}";
                    break;
                case "PutInstrumentCheckListType":
                    service = $"InstrumentCheckListType/{id}";
                    break;
                case "PutInstrumentUnit":
                    service = $"InstrumentUnit/{id}";
                    break;
                case "PutInventory":
                    service = $"GetInventory/{id}";
                    break;
                case "PutInventoryAction":
                    service = $"InventoryAction/{id}";
                    break;
                case "PutInventoryAgency":
                    service = $"InventoryAgency/{id}";
                    break;
                case "PutInventoryBrand":
                    service = $"InventoryBrand/{id}";
                    break;
                case "PutInventoryLocation":
                    service = $"InventoryLocation/{id}";
                    break;
                case "PutInventoryStockType":
                    service = $"InventoryStockType/{id}";
                    break;
                case "PutRadiationSourceLocation":
                    service = $"RadiationSourceLocation/{id}";
                    break;
                case "PutRadiationSourceType":
                    service = $"RadiationSourceType/{id}";
                    break;
                case "PutRadiationSourceAgency":
                    service = $"RadiationSourceAgency/{id}";
                    break;
                case "PutRadiationSourceUnit":
                    service = $"RadiationSourceUnit/{id}";
                    break;
                case "PutRadiationSourceDoseUnit":
                    service = $"RadiationSourceDoseUnit/{id}";
                    break;
                case "PutRadiationSourceCheckOutAction":
                    service = $"RadiationSourceCheckOutAction/{id}";
                    break;
                case "PutProjectType":
                    service = $"ProjectType/{id}";
                    break;
                case "PutProjectRecord":
                    service = $"ProjectRecord/{id}";
                    break;
                case null:
                    break;
            }

            var json = JsonConvert.SerializeObject(model);
            var con = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await _http.PutAsync($"{path}{service}", con);
            if (response.StatusCode == HttpStatusCode.NotFound)
            {
                return default;
            }
            else
            {
                var content = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<TModel>(content);
            }
        }

        /// <summary>
        /// DeleteMasterDataAsync
        /// </summary>
        /// <typeparam name="TModel"></typeparam>
        /// <param name="key"></param>
        /// <param name="model"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<TModel> DeleteMasterDataAsync<TModel>(string key, int? id)
        {
            string path = $"{_configuration["nurl"]}/api/";
            string service = "";

            switch (key)
            {
                case "DeleteEventType":
                    service = $"EventType/{id}";
                    break;
                case "DeleteInstrumentAction":
                    service = $"InstrumentAction/{id}";
                    break;
                case "DeleteInstrumentAgency":
                    service = $"InstrumentAgency/{id}";
                    break;
                case "DeleteInstrumentBrand":
                    service = $"InstrumentBrand/{id}";
                    break;
                case "DeleteInstrumentCategory":
                    service = $"InstrumentCatagory/{id}";
                    break;
                case "DeleteInstrumentLocation":
                    service = $"InstrumentLocation/{id}";
                    break;
                case "DeleteInstrumentModel":
                    service = $"InstrumentModel/{id}";
                    break;
                case "DeleteInstrumentType":
                    service = $"InstrumentType/{id}";
                    break;
                case "DeleteInstrumentCheckListType":
                    service = $"InstrumentCheckListType/{id}";
                    break;
                case "DeleteInstrumentUnit":
                    service = $"InstrumentUnit/{id}";
                    break;
                case "DeleteInventoryAction":
                    service = $"InventoryAction/{id}";
                    break;
                case "DeleteInventoryAgency":
                    service = $"InventoryAgency/{id}";
                    break;
                case "DeleteInventoryBrand":
                    service = $"InventoryBrand/{id}";
                    break;
                case "DeleteInventoryLocation":
                    service = $"InventoryLocation/{id}";
                    break;
                case "DeleteInventoryStockType":
                    service = $"InventoryStockType/{id}";
                    break;
                case "DeleteRadiationSourceLocation":
                    service = $"RadiationSourceLocation/{id}";
                    break;
                case "DeleteRadiationSourceType":
                    service = $"RadiationSourceType/{id}";
                    break;
                case "DeleteRadiationSourceAgency":
                    service = $"RadiationSourceAgency/{id}";
                    break;
                case "DeleteRadiationSourceUnit":
                    service = $"RadiationSourceUnit/{id}";
                    break;
                case "DeleteRadiationSourceDoseUnit":
                    service = $"RadiationSourceDoseUnit/{id}";
                    break;
                case "DeleteRadiationSourceCheckOutAction":
                    service = $"RadiationSourceCheckOutAction/{id}";
                    break;
                case "DeleteProjectType":
                    service = $"ProjectType/{id}";
                    break;
                case "DeleteProjectRecord":
                    service = $"ProjectRecord/{id}";
                    break;
                case null:
                    break;

            }

            var responseMessage = await _http.DeleteAsync($"{path}{service}");
            var content = responseMessage.Content.ReadAsStringAsync().Result;
            if (responseMessage.StatusCode == HttpStatusCode.NotFound || responseMessage.StatusCode == HttpStatusCode.BadRequest)
            {
                var result = "{\"content\":\"" + content + "\"}";
                return JsonConvert.DeserializeObject<TModel>(result);
            }
            else
            {
                var result = await responseMessage.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<TModel>(result);
            }

        }

        
    }
}
