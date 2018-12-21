using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace DacSan3Mien.Models
{
    public class AccessQuantity
    {
        public int id { get; set; }
        public int quantity { get; set; }
        public DateTime date { get; set; }
    }
}