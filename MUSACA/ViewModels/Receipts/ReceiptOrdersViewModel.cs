using System;
using System.Collections.Generic;
using System.Text;

namespace MUSACA.ViewModels.Receipts
{
    public class ReceiptOrdersViewModel
    {
        public int Id { get; set; }
        public string Cashier { get; set; }
        public DateTime IssuedOn { get; set; }
        public List<ReceiptViewModel> Orders { get; set; }
    }
}
