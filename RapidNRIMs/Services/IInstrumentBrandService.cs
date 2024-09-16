using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RapidNRIMs.Model;
using RapidNRIMs.Model.Instruments;

namespace RapidNRIMs.Services
{
    public interface IInstrumentBrandService
    {
          Task <List<InstrumentBrand>> GetInstrumentBrands();
          Task <InstrumentBrand> GetInstrumentBrandById(int ID);
          Task<InstrumentBrand> PostInstrumentBrand(InstrumentBrand instrumentBrand);
    }
}