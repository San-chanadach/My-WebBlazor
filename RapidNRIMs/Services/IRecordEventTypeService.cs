using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RapidNRIMs.Model.Cores;
using RapidNRIMs.Model.EventRecord;

namespace RapidNRIMs.Services
{
    public interface IRecordEventTypeService
    {
        Task <List<RecordEventType>> GetRecordEventTypes();
    }
}