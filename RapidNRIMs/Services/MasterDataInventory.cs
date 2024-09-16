using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace RapidNRIMs.Services
{
    public class MasterDataInventory : IMasterDataInventory
    {
        /// <summary>
        /// inject interface
        /// </summary>
        private readonly HttpClient _http;
        private readonly IConfiguration _configuration;

        public MasterDataInventory(HttpClient http, IConfiguration configuration)
        {
            _http = http;
            _configuration = configuration;
        }

        /// <summary>
        /// GetAllInventoryMasterDataAsync
        /// </summary>
        /// <typeparam name="TModel"></typeparam>
        /// <param name="key"></param>
        /// <returns></returns>
        /// <exception cref="System.NotImplementedException"></exception>
        public async Task<List<TModel>> GetAllInventoryMasterDataAsync<TModel>(string key)
        {
            string path = $"{_configuration["nurl"]}/api/";
            string service = "";

            switch (key)
            {
                case "GetAllInventory":
                    service = "GetInventory";
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
        /// GetInventoryStockMasterDataAsyncByID
        /// </summary>
        /// <typeparam name="TModel"></typeparam>
        /// <param name="key"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        /// <exception cref="System.NotImplementedException"></exception>
        public async Task<List<TModel>> GetInventoryStockMasterDataAsyncByID<TModel>(string key, int id)
        {
            string path = $"{_configuration["nurl"]}/api/";
            string service = "";

            switch (key)
            {
                case "InventoryStockByID":
                    service = $"GetInventoryStock/{id}";
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
        /// PostInventoryMasterDataAsync
        /// </summary>
        /// <typeparam name="TModel"></typeparam>
        /// <param name="key"></param>
        /// <param name="model"></param>
        /// <returns></returns>
        /// <exception cref="System.NotImplementedException"></exception>
        public async Task<List<TModel>> PostInventoryMasterDataAsync<TModel>(string key, TModel model)
        {
            string path = $"{_configuration["nurl"]}/api/";
            string service = "";

            switch (key)
            {
                case "PostInventory":
                    service = "RegisterInventory";
                    break;
                case "PostInventoryAction":
                    service = "RegisterInventoryAction";
                    break;
                case "PostInventoryAgency":
                    service = "RegisterInventoryAgency";
                    break;
                case "PostInventoryBrand":
                    service = "RegisterInventoryBrand";
                    break;
                case "PostInventoryLocation":
                    service = "RegisterInventoryLocation";
                    break;
                case "PostInventoryStockType":
                    service = "RegisterInventoryStockType";
                    break;
                case "PostRadiationSourceLocation":
                    service = "RegisterRadiationSourceLocation";
                    break;
                case "PostRadiationSourceType":
                    service = "RegisterRadiationSourceType";
                    break;
                case "PostRadiationSourceCheckOutAction":
                    service = "RegisterRadiationSourceCheckOutAction";
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
        /// PutInventoryMasterDataAsync
        /// </summary>
        /// <typeparam name="TModel"></typeparam>
        /// <param name="key"></param>
        /// <param name="model"></param>
        /// <returns></returns>
        /// <exception cref="System.NotImplementedException"></exception>
        public async Task<TModel> PutInventoryMasterDataAsync<TModel>(string key, TModel model)
        {
            string path = $"{_configuration["nurl"]}/api/";
            string service = "";

            switch (key)
            {
                case "PutInventory":
                    service = "RegisterInventory";
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
    }
}
