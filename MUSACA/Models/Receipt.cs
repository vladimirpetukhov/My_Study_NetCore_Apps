using System;
using System.Collections.Generic;

namespace MUSACA.Models
{
    public class Receipt
    {
        public Receipt()
        {
            this.Orders = new List<Order>();
        }
        public int Id { get; set; }
        public DateTime IssuedOn { get; set; }
        public virtual User Cashier { get; set; }
        public virtual ICollection<Order> Orders { get; set; }

    }
}
