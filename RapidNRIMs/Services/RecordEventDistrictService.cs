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
    public class RecordEventDistrictService : IRecordEventDistrictService
    {
        private readonly HttpClient _http;
        private readonly IConfiguration _configuration;

        public RecordEventDistrictService(HttpClient http, IConfiguration configuration)
        {
            _http = http;
            _configuration = configuration;
        }

        public async Task<List<RecordEventDistrict>> GetRecordEventDistricts()
        {
            return await _http.GetFromJsonAsync<List<RecordEventDistrict>>($"{_configuration["nurl"]}/api/District");
      
        }
    }
}