using System;
using System.Net.Http;
using System.Collections.Generic;
using RapidNRIMs.Model;
using System.Linq;
using System.Threading.Tasks;
using System.Net.Http.Json;
using RapidNRIMs.Model.Radiations;

namespace RapidNRIMs.Services
{
    public class RadiationSourceService : IRadiationSourceService
    {
        private readonly HttpClient _http;
        private readonly IConfiguration _configuration;

        public RadiationSourceService(HttpClient http, IConfiguration configuration)
        {
            _http = http;
            _configuration = configuration;
        }

        public async Task<List<RadiationSource>> GetRadiationSourceById(int id)
        {
            return await _http.GetFromJsonAsync<List<RadiationSource>>($"{_configuration["nurl"]}/api/GetRadiationSource/{id}");
        }

        public async Task<List<RadiationSource>> GetRadiationSources()
        {
            return await _http.GetFromJsonAsync<List<RadiationSource>>($"{_configuration["nurl"]}/api/GetRadiationSource");
        }
    }
}