using System;
using System.Net.Http;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Net.Http.Json;
using RapidNRIMs.Model.Instruments;

namespace RapidNRIMs.Services
{
    public class InstrumentBrandService : IInstrumentBrandService
    {
        /// <summary>
        /// 
        /// </summary>
        private readonly HttpClient _http;
        private readonly IConfiguration _configuration;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="http"></param>
        public InstrumentBrandService(HttpClient http, IConfiguration configuration)
        {
            _http = http;
            _configuration = configuration;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public Task<InstrumentBrand> GetInstrumentBrandById(int ID)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public async Task<List<InstrumentBrand>> GetInstrumentBrands()
        {
            return await _http.GetFromJsonAsync<List<InstrumentBrand>>($"{_configuration["nurl"]}/api/GetInstrumentBrand");
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="instrumentBrand"></param>
        /// <returns></returns>
        public async Task<InstrumentBrand> PostInstrumentBrand(InstrumentBrand instrumentBrand)
        {
             var result = await _http.PostAsJsonAsync($"{_configuration["nurl"]}/api/RegisterInstrumentBrand", instrumentBrand);
             return await result.Content.ReadFromJsonAsync<InstrumentBrand>();
        }
    }
}