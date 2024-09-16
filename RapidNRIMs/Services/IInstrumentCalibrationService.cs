using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RapidNRIMs.Model.Cores;
using RapidNRIMs.Model.Instruments;

namespace RapidNRIMs.Services
{
    public interface IInstrumentCalibrationService
    {
        Task <List<InstrumentCalibration>> GetInstrumentCalibrations();
        Task <InstrumentCalibration> GetInstrumentCalibrationById(int ID);
        Task<InstrumentCalibration> PostInstrumentCalibration(InstrumentCalibration instrumentCalibration);
    }
}