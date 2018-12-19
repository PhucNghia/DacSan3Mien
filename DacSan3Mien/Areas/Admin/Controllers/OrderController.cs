using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DacSan3Mien.Models;
using DacSan3Mien.Areas.Admin.Models.ViewModel;

namespace DacSan3Mien.Areas.Admin.Controllers
{
    public class OrderController : Controller
    {
        private DataContext db = new DataContext();
        public ActionResult Index()
        {
            var orders = from order in db.Orders
                         join user in db.Users on order.userId equals user.id
                         join orderDetail in db.OrderDetails on order.id equals orderDetail.orderId
                         join product in db.Products on orderDetail.productId equals product.id
                         select new OrderViewModel
                         {
                             userId = user.id,
                             userName = user.name,
                             phone = user.phone,
                             productName = product.name,
                             quantity = orderDetail.quantity,
                             price = product.price,
                             amount = orderDetail.quantity * product.price
                         };
            List<OrderViewModel> listOrder = orders.ToList();

            return View(listOrder);
        }
    }
}