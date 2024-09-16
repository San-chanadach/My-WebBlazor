using System;
using System.Net.Http;
using System.Collections.Generic;
using RapidNRIMs.Model.Cores;
using System.Linq;
using System.Threading.Tasks;
using System.Net.Http.Json;
using RapidNRIMs.Model.Instruments;

namespace RapidNRIMs.Services
{
    public class InstrumentCheckOutService : IInstrumentCheckOutService
    {
        private readonly HttpClient _http;
        private readonly IConfiguration _configuration;

        public InstrumentCheckOutService(HttpClient http, IConfiguration configuration)
        {
            _http = http;
            _configuration = configuration;
        }
        public Task<InstrumentCheckOut> GetInstrumentCheckOutById(int ID)
        {
            throw new NotImplementedException();
        }

        public async Task<List<InstrumentCheckOut>> GetInstrumentCheckOuts()
        {
            return await _http.GetFromJsonAsync<List<InstrumentCheckOut>>($"{_configuration["nurl"]}/api/CheckOuts");
        }

        public async Task<InstrumentCheckOut> PostInstrumentCheckOut(InstrumentCheckOut instrumentCheckOut)
        {
            var result = await _http.PostAsJsonAsync($"{_configuration["nurl"]}/api/CheckOuts", instrumentCheckOut);
            return await result.Content.ReadFromJsonAsync<InstrumentCheckOut>();
        }
    }
}