using System;
using System.Net.Http;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Net.Http.Json;
using RapidNRIMs.Model.Instruments;

namespace RapidNRIMs.Services
{
    public class InstrumentModelService : IInstrumentModelService
    {
        private readonly HttpClient _http;
        private readonly IConfiguration _configuration;

        public InstrumentModelService(HttpClient http, IConfiguration configuration)
        {
            _http = http;
            _configuration = configuration;
        }
        public Task<InstrumentModel> GetInstrumentModelById(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<InstrumentModel>> GetInstrumentModels()
        {
            return await _http.GetFromJsonAsync<List<InstrumentModel>>($"{_configuration["nurl"]}/api/GetInstrumentModel");
        }

        public Task<InstrumentModel> PostInstrumentModel(InstrumentModel instrumentModel)
        {
            throw new NotImplementedException();
        }
    }
}