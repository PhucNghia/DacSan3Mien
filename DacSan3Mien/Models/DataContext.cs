using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace DacSan3Mien.Models
{
    public class DataContext : DbContext
    {
        public DataContext() : base("DS3M")
        {

        }
        public DbSet<Region> Regions { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }
    }
}