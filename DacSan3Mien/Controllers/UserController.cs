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
        User user = new User();

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
            user.listGender = getListGender();
            return View(user);
        }

        [HttpPost]
        public ActionResult New(User user)
        {
            if (ModelState.IsValid)
            {
                user.role = "user";
                db.Users.Add(user);
                db.SaveChanges();
                TempData["success"] = "Thêm thành công!";
                return RedirectToAction("Index", "Home");
            }
            TempData["error"] = "Không thêm được người dùng!";
            user.listGender = getListGender();
            
            return View(user);
        }

        private List<SelectListItem> getListGender()
        {
            SelectListItem nam = new SelectListItem { Text = "Nam", Value = "Nam" };
            SelectListItem nu = new SelectListItem { Text = "Nữ", Value = "Nữ" };
            List<SelectListItem> list = new List<SelectListItem>();
            list.Add(nam);
            list.Add(nu);
            return list;
        }
    }
}