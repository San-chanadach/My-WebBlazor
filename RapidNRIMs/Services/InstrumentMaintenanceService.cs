using System;
using System.Net.Http;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Net.Http.Json;
using RapidNRIMs.Model.Instruments;

namespace RapidNRIMs.Services
{
    public class InstrumentMaintenanceService : IInstrumentMaintenanceService
    {
        private readonly HttpClient _http;
        private readonly IConfiguration _configuration;

        public InstrumentMaintenanceService(HttpClient http, IConfiguration configuration)
        {
            _http = http;
            _configuration = configuration;
        }
        public async Task<InstrumentMaintenance> GetInstrumentMaintenanceById(int ID)
        {
             return await _http.GetFromJsonAsync<InstrumentMaintenance>($"{_configuration["nurl"]}/api/Maintenances/{ID}");
        }

        public async Task<List<InstrumentMaintenance>> GetInstrumentMaintenances()
        {
            return await _http.GetFromJsonAsync<List<InstrumentMaintenance>>($"{_configuration["nurl"]}/api/Maintenances");
        }

        public Task<InstrumentMaintenance> PostInstrumentMaintenance(InstrumentMaintenance instrumentMaintenance)
        {
            throw new NotImplementedException();
        }
    }
}