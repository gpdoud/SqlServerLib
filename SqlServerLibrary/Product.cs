using System;
using System.Collections.Generic;
using System.Text;

namespace SqlServerLibrary {
    public class Product {

        public int Id { get; set; }
        public string PartNbr { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string Unit { get; set; } = "Each";
        public string PhotoPath { get; set; }
        public int VendorId { get; set; }
        public string VendorCode { get; set; }

    }
}
