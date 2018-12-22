using MUSACA.Models;
using MUSACA.ViewModels.Home;
using System;
using System.Collections.Generic;
using System.Text;

namespace MUSACA.ViewModels.Receipts
{
    public class ReceiptViewModel
    {
        public string ProductName { get; set; }
        public int Quantity { get; set; }
        public decimal Total { get; set; }
    }
}
