using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DacSan3Mien.Models.ViewModels
{
    public class BookingCart
    {
        public int productId { get; set; }
        public string image { get; set; }
        public string productName { get; set; }
        public float price { get; set; }
        public int quantity { get; set; }

        private DataContext db = new DataContext();
        public float amount()
        {
            return price * quantity;
        }

        public BookingCart(int id)
        {
            Product product = db.Products.Single(n=>n.id == id);
            productId = id;
            image = product.image;
            productName = product.name;
            price = product.price;
            quantity = 1;
        }
    }
}