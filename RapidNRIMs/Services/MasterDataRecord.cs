using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace RapidNRIMs.Services
{
    public class MasterDataRecord : IMasterDataRecord
    {
        /// <summary>
        /// inject interface
        /// </summary>
        private readonly HttpClient _http;
        private readonly IConfiguration _configuration;

        /// <summary>
        /// construter
        /// </summary>
        /// <param name="http"></param>
        /// <param name="configuration"></param>
        public MasterDataRecord(HttpClient http, IConfiguration configuration)
        {
            _http = http;
            _configuration = configuration;
        }

        /// <summary>
        /// GetDistrictBYID
        /// </summary>
        /// <typeparam name="TModel"></typeparam>
        /// <param name="key"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<List<TModel>> GetDistrictBYID<TModel>(string key, int? id)
        {
            string path = $"{_configuration["nurl"]}/api/";
            string service = "";

            switch (key)
            {
                case "DistrictbyID":
                    service = $"District/{id}";
                    break;
                case "SubDistrictbyID":
                    service = $"SubDistrict/{id}";
                    break;
                case null:
                    break;
            }

            var responseMessage = await _http.GetAsync($"{path}{service}");
            var content = responseMessage.Content.ReadAsStringAsync().Result;
            if (responseMessage.StatusCode == HttpStatusCode.NotFound || responseMessage.StatusCode == HttpStatusCode.BadRequest)
            {
                var result = "{\"content\":\"" + content + "\"}";
                return JsonConvert.DeserializeObject<List<TModel>>(result);

            }
            else
            {
                var result = await responseMessage.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<List<TModel>>(result);
            }
        }

        /// <summary>
        /// PostInventoryMasterDataAsync
        /// </summary>
        /// <typeparam name="TModel"></typeparam>
        /// <param name="key"></param>
        /// <param name="model"></param>
        /// <returns></returns>
        /// <exception cref="System.NotImplementedException"></exception>
        public async Task<List<TModel>> PostEventTypeMasterDataAsync<TModel>(string key, TModel model)
        {
            string path = $"{_configuration["nurl"]}/api/";
            string service = "";

            switch (key)
            {
                case "PostEventType":
                    service = "RegisterEventType";
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

        public async Task<List<TModel>> GetEventResult<TModel>(string key, int id)
        {
            string path = $"{_configuration["nurl"]}/api/";
            string service = "";

            switch (key)
            {
                case "EventResult":
                    service = $"GetEventResult/{id}";
                    break;
                case "EventTeam":
                    service = $"GetEventTeam/{id}";
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
                //return default;
            }
        }

    }
}
