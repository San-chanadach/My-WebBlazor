using System;
using System.Net.Http;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Net.Http.Json;
using RapidNRIMs.Model.Instruments;

namespace RapidNRIMs.Services
{
    public class InstrumentLocationService : IInstrumentLocationService
    {
        private readonly HttpClient _http;
        private readonly IConfiguration _configuration;

        public InstrumentLocationService(HttpClient http, IConfiguration configuration)
        {
            _http = http;
            _configuration = configuration;
        }
        public Task<InstrumentLocation> GetInstrumentLocationById(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<InstrumentLocation>> GetInstrumentLocations()
        {
             return await _http.GetFromJsonAsync<List<InstrumentLocation>>($"{_configuration["nurl"]}/api/InstrumentLocations");
        }

        public Task<InstrumentLocation> PostInstrumentLocation(InstrumentLocation instrumentLocation)
        {
            throw new NotImplementedException();
        }
    }
}