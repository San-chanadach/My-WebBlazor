using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RapidNRIMs.Model.Instruments;

namespace RapidNRIMs.Services
{
    public interface IInstrumentService
    {
        Task <List<Instrument>> GetInstruments();
        Task <List<Instrument>> GetInstrumentById(int id);
        Task<Instrument> PostInstrument(Instrument instrument);
        //Task<Instrument> Update(int id,Instrument instrument);
        //Task<Instrument> SearchInstrument(string instrumentnumber);
    }
}