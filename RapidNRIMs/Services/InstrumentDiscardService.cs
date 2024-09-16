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
    public class InstrumentDiscardService : IInstrumentDiscardService
    {
        private readonly HttpClient _http;
        private readonly IConfiguration _configuration;

        public InstrumentDiscardService(HttpClient http, IConfiguration configuration)
        {
            _http = http;
            _configuration = configuration;
        }
        public Task<InstrumentDiscard> GetInstrumentDiscardById(int ID)
        {
            throw new NotImplementedException();
        }

        public Task<List<InstrumentDiscard>> GetInstrumentDiscards()
        {
            throw new NotImplementedException();
        }

        public async Task<InstrumentDiscard> PostInstrumentDiscard(InstrumentDiscard instrumentDiscard)
        {
            var result = await _http.PostAsJsonAsync($"{_configuration["nurl"]}/api/InstrumentDiscards", instrumentDiscard);
            return await result.Content.ReadFromJsonAsync<InstrumentDiscard>();
        }
    }
}