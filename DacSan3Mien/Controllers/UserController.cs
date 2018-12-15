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
        DataContext db = new DataContext();
        User user = new User();

        // GET: User
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(FormCollection formCollection)
        {
            string email = formCollection.Get("email");
            string pass = formCollection.Get("password");
            User currentUser = db.Users.SingleOrDefault(n => n.email == email && n.password == pass);
            if (currentUser != null)
            {
                Session["userID"] = currentUser.id;
                Session["userName"] = currentUser.name;

                TempData["success"] = "Đăng nhập thành công!";
                return RedirectToAction("Index", "Home");
            }
            TempData["error"] = "Email hoặc mật khẩu không đúng!";
            return View();
        }

        public ActionResult Logout()
        {
            Session["userID"] = null;
            Session["userName"] = null;
            return Redirect("/");
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