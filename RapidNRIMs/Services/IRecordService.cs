using RapidNRIMs.Model.EventRecord;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace RapidNRIMs.Services
{
    public interface IRecordService
    {
        Task <List<RecordModel>> GetRecordModels();
        Task <RecordModel> GetRecordModelByUrl(string city);
        Task<RecordModel> CreateEventRegister(RecordModel request);
        
    }
}