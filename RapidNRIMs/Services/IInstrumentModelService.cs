using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RapidNRIMs.Model.Instruments;

namespace RapidNRIMs.Services
{
    public interface IInstrumentModelService
    {
        Task <List<InstrumentModel>> GetInstrumentModels();
        Task <InstrumentModel> GetInstrumentModelById(int id);
        Task<InstrumentModel> PostInstrumentModel(InstrumentModel instrumentModel);
    }
}