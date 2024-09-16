using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RapidNRIMs.Model.Radiations
{
    public class RadiationSourcesModel
    {
        public string SourcesNumber { get; set; }

        public string Nuclide { get; set; }

        public string Activity { get; set; }

        public string SourceType { get; set; }

        public DateTime ManufacturedDate { get; set; }

        public DateTime PurchaseDate { get; set; }

        public string Halflife { get; set; }

        public string SerialNumber { get; set; }

        public string PurchaseQuantity { get; set; }

        public string PriceperItem { get; set; }

        public string Picture { get; set; }

        public string SourceNumber { get; set; }

        public string Mfd { get; set; }

        public string CheckOutNumber { get; set; }

        public string Location { get; set; }

        public DateTime ReturnDate { get; set; }

        public string CheckList { get; set; }

        public string Status { get; set; }
    }
}
