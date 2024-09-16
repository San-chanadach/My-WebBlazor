using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BC.Printing
{
    internal record PrintOptionsAdapter
    {
        public string Printable { get; init; }
        public string Type { get; init; }
        public bool ShowModal { get; init; }
        public string ModalMessage { get; init; } = "Retrieving Document...";
        public bool? Base64 { get; set; }

        public PrintOptionsAdapter(PrintOptions options)
        {
            Printable = options.Printable;
            Type = Enum.GetName(typeof(PrintType), options.Type).ToLower();
            ShowModal = options.ShowModal;
            ModalMessage = options.ModalMessage;
            Base64 = options.Base64 == true ? true : null;
        }

        public PrintOptionsAdapter(PrintOptions options, PrintType printType  )
        {
            Printable = options.Printable;
            Type = Enum.GetName(typeof(PrintType), printType).ToLower();
            ShowModal = options.ShowModal;
            ModalMessage = options.ModalMessage;
            Base64 = options.Base64 == true ? true : null;
        }
    }
}
