using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DacSan3Mien.Models
{
    public class Order
    {
        public int id { get; set; }
        public int userId { get; set; }
        public DateTime orderDate { get; set; }

        public virtual User User { get; set; }
        public virtual ICollection<OrderDetail> OrderDetails { get; set; }
    }
}