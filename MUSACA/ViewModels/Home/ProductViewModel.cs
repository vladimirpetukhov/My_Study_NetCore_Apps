using System;
using System.Collections.Generic;
using System.Text;

namespace MUSACA.ViewModels.Home
{
    public class ProductViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Picture { get; set; }

        public long Barcode { get; set; }

        public decimal Price { get; set; }
    }
}

