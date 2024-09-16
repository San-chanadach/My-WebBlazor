using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BC.Service
{
    interface IBarcodeServices
    {
        Task<byte[]> GenerateBarcodeAsync(string CodeContent = "", BarcodeType type = BarcodeType.Code128);
    }
}
