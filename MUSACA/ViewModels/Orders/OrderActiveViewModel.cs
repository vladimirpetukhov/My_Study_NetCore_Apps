using System;
using System.Collections.Generic;
using System.Text;

namespace MUSACA.ViewModels.Orders
{
    public class OrderActiveViewModel
    {
        public string ProductName { get; set; }
        public int Quantity { get; set; }
        public decimal Total { get; set; }
    }
}
