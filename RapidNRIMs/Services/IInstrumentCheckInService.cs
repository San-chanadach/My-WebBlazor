using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RapidNRIMs.Model.Instruments;

namespace RapidNRIMs.Services
{
    public interface IInstrumentCheckInService
    {
        Task <List<InstrumentCheckIn>> GetInstrumentCheckIns();
        Task <InstrumentCheckIn> GetInstrumentCheckInById(int ID);
        Task<InstrumentCheckIn> PostInstrumentCheckIn(InstrumentCheckIn instrumentCheckIn);
    }
}