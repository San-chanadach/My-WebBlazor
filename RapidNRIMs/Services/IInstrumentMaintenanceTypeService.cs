using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RapidNRIMs.Model.Instruments;

namespace RapidNRIMs.Services
{
    public interface IInstrumentMaintenanceTypeService
    {
        Task <List<InstrumentMaintenanceType>> GetInstrumentMaintenanceTypes();
        Task <InstrumentMaintenanceType> GetInstrumentMaintenanceTypeById(int ID);
        Task<InstrumentMaintenanceType> PostInstrumentMaintenanceType(InstrumentMaintenanceType instrumentMaintenanceType);
    }
}