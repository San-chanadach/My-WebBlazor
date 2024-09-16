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
    public class InstrumentMaintenanceTypeService : IInstrumentMaintenanceTypeService
    {
        private readonly HttpClient _http;
        private readonly IConfiguration _configuration;

        public InstrumentMaintenanceTypeService(HttpClient http, IConfiguration configuration)
        {
            _http = http;
            _configuration = configuration;
        }
        public Task<InstrumentMaintenanceType> GetInstrumentMaintenanceTypeById(int ID)
        {
            throw new NotImplementedException();
        }

        public async Task<List<InstrumentMaintenanceType>> GetInstrumentMaintenanceTypes()
        {
            return await _http.GetFromJsonAsync<List<InstrumentMaintenanceType>>($"{_configuration["nurl"]}/api/MaintenanceTypes");
        }

        public Task<InstrumentMaintenanceType> PostInstrumentMaintenanceType(InstrumentMaintenanceType instrumentMaintenanceType)
        {
            throw new NotImplementedException();
        }
    }
}