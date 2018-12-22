using System;
using System.Collections.Generic;
using System.Text;

namespace MUSACA.Models
{
    public class Order
    {    
        public int Id { get; set; }
        public Status Status { get; set; }        
        public int Quantity { get; set; }
        public decimal Total { get; set; }
        public int ProductId { get; set; }
        public virtual Product Product { get; set; }        
        public virtual User Cashier { get; set; }
        public int? ReceiptId { get; set; }
        public virtual Receipt Receipt { get; set; }
    }
}
