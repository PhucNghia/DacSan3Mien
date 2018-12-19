using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using DacSan3Mien.Models;
using DacSan3Mien.Models.ViewModels;

namespace DacSan3Mien.Controllers
{
    public class BookingCartController : Controller
    {
        private DataContext db = new DataContext();

        #region Booking cart
        public ActionResult Index()
        {
            if(Session["BookingCart"] == null)
                return Redirect("/");

            List<BookingCart> bookingCarts = getBookingCart();
            ViewBag.quantityTotal = quantityTotal();
            ViewBag.amountTotal = amountTotal();
            return View(bookingCarts);
        }

        public ActionResult Create(int productId)
        {
            Product product = db.Products.Find(productId);
            if (product == null)
                return HttpNotFound();
            List<BookingCart> bookingCarts = getBookingCart();
            BookingCart bookingCart = bookingCarts.SingleOrDefault(n=>n.productId == productId);
            if (bookingCart == null)
            {
                bookingCart = new BookingCart(productId);
                bookingCarts.Add(bookingCart);
            }
            else
                bookingCart.quantity++;

            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult Edit(int productId, int quantity)
        {
            Product product = db.Products.Find(productId);
            if (product == null)
                return HttpNotFound();
            List<BookingCart> bookingCarts = getBookingCart();
            BookingCart bookingCart = bookingCarts.SingleOrDefault(n => n.productId == productId);
            if (bookingCart != null)
            {
                bookingCart.quantity = quantity;
            }
            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult Delete(int productId)
        {
            Product product = db.Products.Find(productId);
            if (product == null)
                return HttpNotFound();
            List<BookingCart> bookingCarts = getBookingCart();
            BookingCart bookingCart = bookingCarts.SingleOrDefault(n => n.productId == productId);
            if (bookingCart != null)
            {
                bookingCarts.RemoveAll(n=>n.productId == bookingCart.productId);
            }
            if (bookingCarts.Count == 0)
                return Redirect("/");
            return RedirectToAction("Index");
        }

        public List<BookingCart> getBookingCart()
        {
            List<BookingCart> bookingCarts = Session["BookingCart"] as List<BookingCart>;
            if(bookingCarts == null)
            {
                bookingCarts = new List<BookingCart>();
                Session["BookingCart"] = bookingCarts;
            }
            return bookingCarts;
        }

        private int quantityTotal()
        {
            int total = 0;
            List<BookingCart> bookingCarts = Session["BookingCart"] as List<BookingCart>;
            if (bookingCarts != null)
                total = bookingCarts.Sum(n => n.quantity);

            return total;
        }

        private float amountTotal()
        {
            float total = 0;
            List<BookingCart> bookingCarts = Session["BookingCart"] as List<BookingCart>;
            if (bookingCarts != null)
                total = bookingCarts.Sum(n => n.amount());

            return total;
        }

        public PartialViewResult totalBookingCart()
        {
            if(quantityTotal() == 0)
                return PartialView();
            ViewBag.quantityTotal = quantityTotal();
            return PartialView();
        }
        #endregion End Booking cart

        #region Order
        [HttpPost]
        public ActionResult Order()
        {
            if (Session["userID"] == null)
            {
                TempData["error"] = "Bạn phải đăng nhập trước khi đặt hàng!";
                return RedirectToAction("Login", "User");
            }
            if(Session["BookingCart"] == null)
                return RedirectToAction("/");

            User user = db.Users.Find((int)Session["userID"]);
            if(user.role == "admin")
            {
                TempData["error"] = "Admin không được đặt hàng!";
                return RedirectToAction("/");
            }

            Order order = new Order();
            List<BookingCart> bookingCarts = getBookingCart();
            order.userId = user.id;
            order.orderDate = DateTime.Now;
            db.Orders.Add(order);
            db.SaveChanges();

            foreach(var product in bookingCarts)
            {
                OrderDetail orderDetail = new OrderDetail();
                orderDetail.orderId = order.id;
                orderDetail.productId = product.productId;
                orderDetail.quantity = product.quantity;
                db.OrderDetails.Add(orderDetail);

                Product productUpdate = db.Products.Find(product.productId);
                productUpdate.quantity -= orderDetail.quantity;
                if(productUpdate.quantity < 0)
                {
                    TempData["error"] = "Hệ thống không đủ số lượng sản phẩm để chi trả!";
                    return Redirect("/");
                }
                if (productUpdate.quantity == 0)
                    productUpdate.status = "Hết hàng";

                db.Entry(productUpdate).State = EntityState.Modified;
            }
            db.SaveChanges();
            Session["BookingCart"] = null;
            TempData["success"] = "Đặt hàng thành công!";
            return Redirect("/");
        }
        #endregion End Order
    }
}