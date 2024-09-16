using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RapidNRIMs.Model.Instruments;

namespace RapidNRIMs.Services
{
    public interface IInstrumentAgencyService
    {
        Task <List<InstrumentAgency>> GetInstrumentAgencys();
        Task <InstrumentAgency> GetInstrumentAgencyById(int ID);
        Task<InstrumentAgency> PostInstrumentAgency(InstrumentAgency instrumentAgency);
    }
}