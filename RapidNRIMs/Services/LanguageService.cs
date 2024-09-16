using System;
using System.Net.Http;
using System.Collections.Generic;
using RapidNRIMs.Model;
using System.Linq;
using System.Threading.Tasks;
using System.Net.Http.Json;
using RapidNRIMs.Model.Securitys;

namespace RapidNRIMs.Services
{
    public class LanguageService : ILanguageService
    {
        private readonly HttpClient httpClient;
        private readonly IConfiguration _configuration;

        public LanguageService(HttpClient httpClient, IConfiguration configuration)
        {
            this.httpClient = httpClient;
            this._configuration = configuration;

        }
        public async Task<List<LanguageModels>> GetLanguageModels()
        {
            return await httpClient.GetFromJsonAsync<List<LanguageModels>>($"{_configuration["nurl"]}/api/Languages/GetAllLanguages");
        }

    }
    
}