using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RapidNRIMs.Barcode
{
    interface IBarcodeServices
    {

        Task<byte[]> GenerateBarcodeAsync(string CodeContent = null, string InstrumentName = null, BarcodeType type = BarcodeType.Code128);
        Task<byte[]> GenerateBarcodeAsync(string CodeContent = null, string InstrumentName = null, string InstrumentLocationName = null, BarcodeType type = BarcodeType.Code128);
        Task<byte[]> GenerateBarcodeInstrumentAsync(string CodeContent = null, string InstrumentName = null, string InstrumentLocationName = null, BarcodeType type = BarcodeType.Code128);
    }
}
