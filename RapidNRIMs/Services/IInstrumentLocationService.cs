using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RapidNRIMs.Model.Instruments;

namespace RapidNRIMs.Services
{
    public interface IInstrumentLocationService
    {
        Task <List<InstrumentLocation>> GetInstrumentLocations();
        Task <InstrumentLocation> GetInstrumentLocationById(int id);
        Task<InstrumentLocation> PostInstrumentLocation(InstrumentLocation instrumentLocation);
         
    }
}