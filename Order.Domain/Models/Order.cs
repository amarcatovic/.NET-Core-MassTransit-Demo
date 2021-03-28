using System;
using System.Collections.Generic;
using System.Text;

namespace Order.Domain.Models
{
    public class Order
    {
        public int Id { get; set; }

        public string ProductName { get; set; }

        public decimal Total { get; set; }
    }
}
