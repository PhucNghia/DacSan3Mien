using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DacSan3Mien.Models;

namespace DacSan3Mien.Controllers
{
    public class AccessQuantityController : Controller
    {
        private DataContext db = new DataContext();

        [HttpPost]
        public ActionResult Edit()
        {
            int currentYear = int.Parse(DateTime.Now.ToString("yyyy"));
            int currentMonth = int.Parse(DateTime.Now.ToString("MM"));
            int currentDay = int.Parse(DateTime.Now.ToString("dd"));
            var accessQuantity = db.AccessQuantities.SingleOrDefault(n => n.date.Year == currentYear && n.date.Month == currentMonth
                && n.date.Day == currentDay) as AccessQuantity;
            if(accessQuantity == null)
            {
                accessQuantity = new AccessQuantity();
                accessQuantity.quantity = 1;
                accessQuantity.date = DateTime.Now;
                db.AccessQuantities.Add(accessQuantity);
                db.SaveChanges();
            }
            else
            {
                accessQuantity.quantity++;
                db.Entry(accessQuantity).State = EntityState.Modified;
                db.SaveChanges();
            }
            return Redirect("/");
        }
    }
}