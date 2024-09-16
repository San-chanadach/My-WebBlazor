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
    public class InstrumentAgencyService : IInstrumentAgencyService
    {
        private readonly HttpClient _http;
        private readonly IConfiguration _configuration;

        public InstrumentAgencyService(HttpClient http, IConfiguration configuration)
        {
            _http = http;
            _configuration = configuration;
        }
        public async Task<InstrumentAgency> GetInstrumentAgencyById(int ID)
        {
            return await _http.GetFromJsonAsync<InstrumentAgency>($"{_configuration["nurl"]}/api/GetInstrumentAgency/{ID}");
             //throw new NotImplementedException();
        }

        public async Task<List<InstrumentAgency>> GetInstrumentAgencys()
        {
            return await _http.GetFromJsonAsync<List<InstrumentAgency>>($"{_configuration["nurl"]}/api/GetInstrumentAgency");
           // throw new NotImplementedException();
        }

        public async Task<InstrumentAgency> PostInstrumentAgency(InstrumentAgency instrumentAgency)
        {
            var result = await _http.PostAsJsonAsync($"{_configuration["nurl"]}/api/RegisterInstrumentAgency", instrumentAgency);
            return await result.Content.ReadFromJsonAsync<InstrumentAgency>();
        }
    }
}