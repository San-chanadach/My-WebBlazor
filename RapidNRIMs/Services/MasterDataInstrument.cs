using Blazored.LocalStorage;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace RapidNRIMs.Services
{
    public class MasterDataInstrument : IMasterDataInstrument
    {
        /// <summary>
        /// inject interface
        /// </summary>
        private readonly HttpClient _http;
        private readonly IConfiguration _configuration;
        private readonly ILocalStorageService _localStorageService;

        public MasterDataInstrument(HttpClient http, IConfiguration configuration, ILocalStorageService localStorageService)
        {
            _http = http;
            _configuration = configuration;
            _localStorageService = localStorageService;
        }

        /// <summary>
        /// GetAllInstrumentMasterDataAsync
        /// </summary>
        /// <typeparam name="TModel"></typeparam>
        /// <param name="key"></param>
        /// <returns></returns>
        /// <exception cref="System.NotImplementedException"></exception>
        public async Task<List<TModel>> GetAllInstrumentMasterDataAsync<TModel>(string key)
        {
            string path = $"{_configuration["nurl"]}/api/";
            string service = "";

            switch (key)
            {
                case "GetAllInstrument":
                    service = "GetInstrument";
                    break;
                case "GetInstrumentListView":
                    service = "GetInstrument/GetInstrumentListView";
                    break;
                case "InstrumentCalibration":
                    service = "GetDueInstrumentCalibration";
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
                var result = JsonConvert.DeserializeObject<List<TModel>>(content);
                return result;
            }
        }

        /// <summary>
        /// GetInstrumentMasterDataAsyncByID
        /// </summary>
        /// <typeparam name="TModel"></typeparam>
        /// <param name="key"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<List<TModel>> GetInstrumentMasterDataAsyncByID<TModel>(string key, int? id)
        {
            string path = $"{_configuration["nurl"]}/api/";
            string service = "";

            switch (key)
            {
                case "InstrumentCalibrationByID":
                    service = $"GetInstrumentCalibration/{id}";
                    break;
                case "InstrumentMaintenanceByID":
                    service = $"GetInstrumentMaintenance/{id}";
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
        /// PostInstrumentMasterDataAsync
        /// </summary>
        /// <typeparam name="TModel"></typeparam>
        /// <param name="key"></param>
        /// <param name="model"></param>
        /// <returns></returns>
        /// <exception cref="System.NotImplementedException"></exception>
        public async Task<List<TModel>> PostInstrumentMasterDataAsync<TModel>(string key, TModel model)
        {
            string path = $"{_configuration["nurl"]}/api/";
            string service = "";

            switch (key)
            {
                case "PostInstrumentByParameter":
                    service = "GetInstrumentByParameter";
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
                return JsonConvert.DeserializeObject<List<TModel>>(content);
            }
        }



        /// <summary>
        /// PutInstrumentMasterDataAsync
        /// </summary>
        /// <typeparam name="TModel"></typeparam>
        /// <param name="key"></param>
        /// <param name="model"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        /// <exception cref="System.NotImplementedException"></exception>
        public async Task<List<TModel>> PutInstrumentMasterDataAsync<TModel>(string key, TModel model)
        {
            string path = $"{_configuration["nurl"]}/api/";
            string service = "";

            switch (key)
            {
                case "PutInstrumentCalibration":
                    service = $"RegisterInstrumentCalibration";
                    break;
                case "PutInstrumentMaintenance":
                    service = $"RegisterInstrumentMaintenance";
                    break;
                case null:
                    break;
            }

            var json = JsonConvert.SerializeObject(model);
            var con = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await _http.PutAsync($"{path}{service}", con);
            if (response.StatusCode == HttpStatusCode.NotFound)
            {
                return null;
            }
            else
            {
                var content = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<List<TModel>>(content);
            }
        }
    }
}
