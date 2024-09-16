using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RapidNRIMs.Model.Instruments;

namespace RapidNRIMs.Services
{
    public interface IInstrumentDiscardService
    {
        Task <List<InstrumentDiscard>> GetInstrumentDiscards();
        Task <InstrumentDiscard> GetInstrumentDiscardById(int ID);
        Task<InstrumentDiscard> PostInstrumentDiscard(InstrumentDiscard instrumentDiscard);
    }
}