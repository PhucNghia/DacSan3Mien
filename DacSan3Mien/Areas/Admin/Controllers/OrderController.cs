using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DacSan3Mien.Models;
using DacSan3Mien.Areas.Admin.Models.ViewModel;
using PagedList;

namespace DacSan3Mien.Areas.Admin.Controllers
{
    public class OrderController : Controller
    {
        private DataContext db = new DataContext();
        
        public ActionResult Index(int page = 1, int pageSize = 5)
        {
            if (!checkAdmin()) return Redirect("/");
            var orders = (from order in db.Orders
                         join user in db.Users on order.userId equals user.id
                         join orderDetail in db.OrderDetails on order.id equals orderDetail.orderId
                         join product in db.Products on orderDetail.productId equals product.id
                         select new OrderViewModel
                         {
                             id = order.id,
                             userId = user.id,
                             productId = product.id,
                             userName = user.name,
                             phone = user.phone,
                             productName = product.name,
                             quantity = orderDetail.quantity,
                             price = product.price,
                             amount = orderDetail.quantity * product.price,
                             date = order.orderDate
                         }).OrderByDescending(n => n.date).ToPagedList(page, pageSize);

            return View(orders);
        }

        [HttpPost]
        public ActionResult Delete(int? id, int? userId, int? productId)
        {
            OrderViewModel orderViewModel = getOrderList().SingleOrDefault(n => n.id == id && n.userId == userId && n.productId == productId);
            if (orderViewModel != null)
            {
                OrderDetail orderDetail = db.OrderDetails.Single(n => n.orderId == orderViewModel.id && n.productId == orderViewModel.productId);
                Order order = db.Orders.Single(n => n.id == orderViewModel.id && n.userId == orderViewModel.userId);

                db.OrderDetails.Remove(orderDetail);
                if (order.OrderDetails.Count == 0)
                    db.Orders.Remove(order);
                db.SaveChanges();

                TempData["success"] = "Xóa đơn hàng thành công!";
                return RedirectToAction("Index");
            }
            else
                return HttpNotFound();
        }

        List<OrderViewModel> getOrderList()
        {
            return (from order in db.Orders
                    join user in db.Users on order.userId equals user.id
                    join orderDetail in db.OrderDetails on order.id equals orderDetail.orderId
                    join product in db.Products on orderDetail.productId equals product.id
                    select new OrderViewModel
                    {
                        id = order.id,
                        userId = user.id,
                        productId = product.id,
                        userName = user.name,
                        phone = user.phone,
                        productName = product.name,
                        quantity = orderDetail.quantity,
                        price = product.price,
                        amount = orderDetail.quantity * product.price,
                        date = order.orderDate
                    }).ToList();
        }

        public bool checkAdmin()
        {
            if (Session["userID"] == null)
                return false;
            else
            {
                User user = db.Users.Find(int.Parse(Session["userId"].ToString()));
                if (user.role == "user")
                    return false;
                else
                    return true;
            }
        }
    }
}