using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DacSan3Mien.Models
{
    public class Region
    {
        public int id { get; set; }

        public string name { get; set; }

        public virtual ICollection<Product> Products { get; set; }
    }
}