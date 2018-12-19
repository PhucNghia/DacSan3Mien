using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DacSan3Mien.Models
{
    public class OrderDetail
    {
        public int id { get; set; }
        public int orderId { get; set; }
        public int productId { get; set; }
        public int quantity { get; set; }

        public virtual Order Order { get; set; }
        public virtual Product Product { get; set; }
    }
}