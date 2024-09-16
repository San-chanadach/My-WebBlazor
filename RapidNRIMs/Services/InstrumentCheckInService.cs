using System;
using System.Net.Http;
using System.Collections.Generic;
using RapidNRIMs.Model;
using System.Linq;
using System.Threading.Tasks;
using System.Net.Http.Json;
using RapidNRIMs.Model.Instruments;

namespace RapidNRIMs.Services
{
    public class InstrumentCheckInService : IInstrumentCheckInService
    {
        private readonly HttpClient _http;
        private readonly IConfiguration _configuration;

        public InstrumentCheckInService(HttpClient http, IConfiguration configuration)
        {
            _http = http;
            _configuration = configuration;
        }
        public Task<InstrumentCheckIn> GetInstrumentCheckInById(int ID)
        {
            throw new NotImplementedException();
        }

        public async Task<List<InstrumentCheckIn>> GetInstrumentCheckIns()
        {
            return await _http.GetFromJsonAsync<List<InstrumentCheckIn>>($"{_configuration["nurl"]}/api/CheckIns");
        }

        public async Task<InstrumentCheckIn> PostInstrumentCheckIn(InstrumentCheckIn instrumentCheckIn)
        {
            var result = await _http.PostAsJsonAsync($"{_configuration["nurl"]}/api/CheckIns", instrumentCheckIn);
            return await result.Content.ReadFromJsonAsync<InstrumentCheckIn>();
        }
    }
}