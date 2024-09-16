using System;
using System.Net.Http;
using System.Collections.Generic;
using RapidNRIMs.Model;
using System.Linq;
using System.Threading.Tasks;
using System.Net.Http.Json;
using RapidNRIMs.Model.EventRecord;

namespace RapidNRIMs.Services
{
    public class RecordService : IRecordService
    {
        private readonly HttpClient _http;
        private readonly IConfiguration _configuration;

        public RecordService(HttpClient http, IConfiguration configuration)
        {
            _http = http;
            _configuration = configuration; 
        }

        public async Task<RecordModel> CreateEventRegister(RecordModel request)
        {
            var result = await _http.PostAsJsonAsync($"{_configuration["nurl"]}/api/Record", request);
            return await result.Content.ReadFromJsonAsync<RecordModel>();
        }
        public async Task<RecordModel> GetRecordModelByUrl(string city)
        {
            //var eventmanage = await _http.GetFromJsonAsync<RecordModel>($"api/Record/{url}");
            //return eventmanage;
            var result = await _http.GetAsync($"{_configuration["nurl"]}/api/Record/{city}");
            if (result.StatusCode != System.Net.HttpStatusCode.OK)
            {
                var message = await result.Content.ReadAsStringAsync();
                Console.WriteLine(message);
                return new RecordModel { Instrument = message };
            }
            else
            {
                return await result.Content.ReadFromJsonAsync<RecordModel>();
            }
        }
        public async Task<List<RecordModel>> GetRecordModels()
        {
            return await _http.GetFromJsonAsync<List<RecordModel>>($"{_configuration["nurl"]}/api/Record");
        }
    }
}