using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DacSan3Mien.Models.ViewModels
{
    public class ProductRegions
    {
        public int productId { get; set; }
        public string productName { get; set; }
        public string image { get; set; }
        public float price { get; set; }
        public string status { get; set; }
        public string description { get; set; }
        public int regionId { get; set; }
        public string regionName { get; set; }
    }
}