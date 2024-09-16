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
    public class InstrumentTypeService : IInstrumentTypeService
    {
        private readonly HttpClient _http;
        private readonly IConfiguration _configuration;

        public InstrumentTypeService(HttpClient http, IConfiguration configuration)
        {
            _http = http;
            _configuration = configuration;
        }
        public Task<InstrumentType> GetInstrumentTypeById(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<InstrumentType>> GetInstrumentTypes()
        {
            return await _http.GetFromJsonAsync<List<InstrumentType>>($"{_configuration["nurl"]}/api/GetInstrumentType");
        }

        public Task<InstrumentType> PostInstrumentType(InstrumentType instrumentType)
        {
            throw new NotImplementedException();
        }
    }
}