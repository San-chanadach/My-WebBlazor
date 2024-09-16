using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RapidNRIMs.Model;
using RapidNRIMs.Model.EventRecord;

namespace RapidNRIMs.Services
{
    public interface IRecordEventProvinceService
    {
        Task <List<RecordEventProvince>> GetRecordEventProvinces();
    }
}