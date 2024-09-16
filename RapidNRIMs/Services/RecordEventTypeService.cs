using System;
using System.Net.Http;
using System.Collections.Generic;
using RapidNRIMs.Model.Cores;
using System.Linq;
using System.Threading.Tasks;
using System.Net.Http.Json;
using RapidNRIMs.Model.EventRecord;

namespace RapidNRIMs.Services
{
    public class RecordEventTypeService : IRecordEventTypeService
    {
        private readonly HttpClient _http;
        private readonly IConfiguration _configuration;
        public RecordEventTypeService(HttpClient http, IConfiguration configuration)
        {
            _http = http;
            _configuration = configuration; 
        }
        public async Task<List<RecordEventType>> GetRecordEventTypes()
        {
            return await _http.GetFromJsonAsync<List<RecordEventType>>($"{_configuration["nurl"]}/api/EventType");
        }
    }
}