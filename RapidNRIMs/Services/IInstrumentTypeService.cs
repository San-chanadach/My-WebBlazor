using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RapidNRIMs.Model.Instruments;

namespace RapidNRIMs.Services
{
    public interface IInstrumentTypeService 
    {
        Task <List<InstrumentType>> GetInstrumentTypes();
        Task <InstrumentType> GetInstrumentTypeById(int id);
        Task<InstrumentType> PostInstrumentType(InstrumentType instrumentType);
    }
}