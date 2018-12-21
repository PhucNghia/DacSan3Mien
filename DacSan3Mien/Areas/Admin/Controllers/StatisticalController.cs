using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DacSan3Mien.Models;

namespace DacSan3Mien.Areas.Admin.Controllers
{
    public class StatisticalController : Controller
    {
        DataContext db = new DataContext();
        public ActionResult Index()
        {
            if (!checkAdmin()) return Redirect("/");
            List<AccessQuantity> accessQuantities = db.AccessQuantities.Take(8).ToList();

            return View(accessQuantities);
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