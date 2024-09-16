using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RapidNRIMs.Model.Instruments;

namespace RapidNRIMs.Services
{
    public interface IInstrumentMaintenanceService
    {
        Task <List<InstrumentMaintenance>> GetInstrumentMaintenances();
        Task <InstrumentMaintenance> GetInstrumentMaintenanceById(int ID);
        Task<InstrumentMaintenance> PostInstrumentMaintenance(InstrumentMaintenance instrumentMaintenance);
    }
}