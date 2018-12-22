using System;
using System.Collections.Generic;
using System.Text;

namespace MUSACA.ViewModels.Orders
{
    public class OrderProductViewModel
    {
        public long Barcode { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
    }
}
