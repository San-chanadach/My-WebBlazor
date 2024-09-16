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
    public class MasterDataPhase2 : IMasterDataPhase2
    {
        /// <summary>
        /// inject interface
        /// </summary>
        private readonly HttpClient _http;
        private readonly IConfiguration _configuration;

        public MasterDataPhase2(HttpClient http, IConfiguration configuration)
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
            string path = $"{_configuration["nurlPhase2"]}/api/";
            string service = "";

            switch (key)
            {
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
            string path = $"{_configuration["nurlPhase2"]}/api/";
            string service = "";

            switch (key)
            {
                case "ActiveProjectType":
                    service = "ProjectType/GetActiveProjectTypes";
                    break;
                case "ActiveProjectRecord":
                    service = "ProjectRecord/GetAllActiveProjectRecords";
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
            string path = $"{_configuration["nurlPhase2"]}/api/";
            string service = "";

            switch (key)
            {
                case "ProjectTypeByID":
                    service = $"ProjectType/{id}";
                    break;
                case "ProjectRecordByID":
                    service = $"ProjectRecord/{id}";
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
        /// PostMasterDataAsync
        /// </summary>
        /// <typeparam name="TModel"></typeparam>
        /// <param name="key"></param>
        /// <param name="model"></param>
        /// <returns></returns>
        public async Task<TModel> PostMasterDataAsync<TModel>(string key, TModel model)
        {
            string path = $"{_configuration["nurlPhase2"]}/api/";
            string service = "";

            switch (key)
            {
                case "PostProjectType":
                    service = "ProjectType";
                    break;
                case "PostProjectRecord":
                    service = "ProjectRecord";
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
            string path = $"{_configuration["nurlPhase2"]}/api/";
            string service = "";

            switch (key)
            {
                case "PutProjectType":
                    service = $"ProjectType/{id}";
                    break;
                case "PutProjectRecord":
                    service = $"ProjectRecord/{id}";
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
            string path = $"{_configuration["nurlPhase2"]}/api/";
            string service = "";

            switch (key)
            {
                case "DeleteProjectType":
                    service = $"ProjectType/{id}";
                    break;
                case "DeleteProjectRecord":
                    service = $"ProjectRecord/{id}";
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
