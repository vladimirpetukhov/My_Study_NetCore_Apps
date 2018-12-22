using System;
using System.Collections.Generic;
using System.Text;

namespace MUSACA.ViewModels.Receipts {
    public class AllReceiptViewModel {
        public int Id { get; set; }
        public string Cashier { get; set; }
        public DateTime IssuedOn { get; set; }
        public decimal Total { get; set; }
    }
}
