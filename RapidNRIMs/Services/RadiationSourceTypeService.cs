using System;
using System.Net.Http;
using System.Collections.Generic;
using RapidNRIMs.Model.Cores;
using System.Linq;
using System.Threading.Tasks;
using System.Net.Http.Json;
using RapidNRIMs.Model.Radiations;

namespace RapidNRIMs.Services
{
    public class RadiationSourceTypeService : IRadiationSourceTypeService
    {
        private readonly HttpClient _http;
        private readonly IConfiguration _configuration;

        public RadiationSourceTypeService(HttpClient http, IConfiguration configuration)
        {
            _http = http;
            _configuration = configuration;
        }
        public async Task<List<RadiationSourceType>> GetRadiationSourceTypes()
        {
            return await _http.GetFromJsonAsync<List<RadiationSourceType>>($"{_configuration["nurl"]}/api/GetRadiationSourceType");
        }
    }
}