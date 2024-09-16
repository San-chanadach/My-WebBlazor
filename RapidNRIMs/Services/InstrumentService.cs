using System;
using System.Net.Http;
using System.Collections.Generic;
using RapidNRIMs.Model;
using System.Linq;
using System.Threading.Tasks;
using System.Net.Http.Json;
using System.Text.Json;
using System.Text;
using System.IO;
using Newtonsoft.Json;
using System.Net;
using RapidNRIMs.Model.Instruments;

namespace RapidNRIMs.Services
{
    public class InstrumentService : IInstrumentService
    {
        private readonly HttpClient _http;
        private readonly IConfiguration _configuration;

        public InstrumentService(HttpClient http, IConfiguration configuration)
        {
            _http = http;
            _configuration = configuration;
        }

        public async Task<Instrument> PostInstrument(Instrument instrument)
        {
            var result = await _http.PostAsJsonAsync($"{_configuration["nurl"]}/api/Instruments", instrument);
            return await result.Content.ReadFromJsonAsync<Instrument>();
        }

        public async Task<List<Instrument>> GetInstrumentById(int id)
        {
            return await _http.GetFromJsonAsync<List<Instrument>>($"{_configuration["nurl"]}/api/GetInstrument/{id}");
        }

        public async Task<List<Instrument>> GetInstruments()
        {
            return await _http.GetFromJsonAsync<List<Instrument>>($"{_configuration["nurl"]}/api/GetInstrument");
        }

       
       

    }
}