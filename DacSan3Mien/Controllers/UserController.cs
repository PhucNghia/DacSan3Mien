using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DacSan3Mien.Models;

namespace DacSan3Mien.Controllers
{
    public class UserController : Controller
    {
        DACSAN3MIENEntities db = new DACSAN3MIENEntities();
        // GET: User
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Login()
        {
            return View();
        }

        [HttpGet]
        public ActionResult New()
        {
            return View();
        }

        [HttpPost]
        public ActionResult New(User user)
        {
            if (ModelState.IsValid)
            {
                user.id = 1;
                db.Users.Add(user);
                db.SaveChanges();
                TempData["success"] = "Thêm thành công!";
                return RedirectToAction("Index", "Home");
            }
            TempData["error"] = "Không thêm được người dùng!";
            return View();
        }
    }
}