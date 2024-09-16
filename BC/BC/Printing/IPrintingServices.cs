using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BC.Printing
{
    public interface IPrintingService
    {
        Task Print(PrintOptions options);
        Task Print(string printable);
        Task Print(string printable, bool showModal);
    }
}
