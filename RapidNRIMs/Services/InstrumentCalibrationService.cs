using System;
using System.Net.Http;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Net.Http.Json;
using RapidNRIMs.Model.Instruments;

namespace RapidNRIMs.Services
{
    public class InstrumentCalibrationService : IInstrumentCalibrationService
    {
        private readonly HttpClient _http;
        private readonly IConfiguration _configuration;

        public InstrumentCalibrationService(HttpClient http, IConfiguration configuration)
        {
            _http = http;
            _configuration = configuration;
        }
        public async Task<InstrumentCalibration> GetInstrumentCalibrationById(int ID)
        {
            return await _http.GetFromJsonAsync<InstrumentCalibration>($"{_configuration["nurl"]}/api/Calibrations/{ID}");
        }

        public async Task<List<InstrumentCalibration>> GetInstrumentCalibrations()
        {
            return await _http.GetFromJsonAsync<List<InstrumentCalibration>>($"{_configuration["nurl"]}/api/Calibrations");
        }

        public Task<InstrumentCalibration> PostInstrumentCalibration(InstrumentCalibration instrumentCalibration)
        {
            throw new NotImplementedException();
        }
    }
}