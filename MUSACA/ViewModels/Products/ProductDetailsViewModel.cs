using System;
using System.Collections.Generic;
using System.Text;

namespace MUSACA.ViewModels.Products
{
    public class ProductDetailsViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Picture { get; set; }

        public decimal Price { get; set; }

        public long Barcode { get; set; }
    }
}
