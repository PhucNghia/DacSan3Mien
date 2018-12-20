using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DacSan3Mien.Areas.Admin.Models.ViewModel
{
    public class OrderViewModel
    {
        public int id { get; set; }
        public int userId { get; set; }
        public int productId { get; set; }
        public string userName { get; set; }
        public string phone { get; set; }
        public string productName { get; set; }
        public int quantity { get; set; }
        public float price { get; set; }
        public double amount { get; set; }
        public DateTime date { get; set; }
    }
}