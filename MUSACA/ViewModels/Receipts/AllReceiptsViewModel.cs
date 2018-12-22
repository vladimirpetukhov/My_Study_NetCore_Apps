using System;
using System.Collections;
using System.Collections.Generic;

namespace MUSACA.ViewModels.Receipts {
    public class AllReceiptsViewModel:IEnumerable<AllReceiptViewModel> {
        public List<AllReceiptViewModel> Receipts { get; set; } = new List<AllReceiptViewModel>();

        public IEnumerator<AllReceiptViewModel> GetEnumerator() {
            return Receipts.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator() {
            return GetEnumerator();
        }
    }
}
