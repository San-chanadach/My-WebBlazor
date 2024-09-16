using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RapidNRIMs.Model.Instruments;

namespace RapidNRIMs.Services
{
    public interface IInstrumentCheckOutService
    {
        Task <List<InstrumentCheckOut>> GetInstrumentCheckOuts();
        Task <InstrumentCheckOut> GetInstrumentCheckOutById(int ID);
        Task<InstrumentCheckOut> PostInstrumentCheckOut(InstrumentCheckOut instrumentCheckOut);
    }
}