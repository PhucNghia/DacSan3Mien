using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using DacSan3Mien.Models;
using PagedList;

namespace DacSan3Mien.Areas.Admin.Controllers
{
    public class UserController : Controller
    {
        private DataContext db = new DataContext();

        public ActionResult Index(int page = 1, int pageSize = 5)
        {
            if (!checkAdmin())  return Redirect("/");
            IEnumerable<User> users = db.Users.OrderBy(n => n.name).ToPagedList(page, pageSize);

            return View(users);
        }

        public ActionResult Details(int? id)
        {
            if (!checkAdmin()) return Redirect("/");
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            User user = db.Users.Find(id);
            if (user == null)
                return HttpNotFound();
            user.listGender = getListGender();

            return View(user);
        }

        [HttpGet]
        public ActionResult Create()
        {
            if (!checkAdmin()) return Redirect("/");
            User user = new User();
            user.listGender = getListGender();

            return View(user);
        }

        [HttpPost]
        public ActionResult Create(User user)
        {
            if (ModelState.IsValid)
            {
                db.Users.Add(user);
                db.SaveChanges();
                TempData["success"] = "Thêm người dùng thành công!";
                return RedirectToAction("Index");
            }
            TempData["error"] = "Thêm sản phẩm thất bại!";
            user.listGender = getListGender();

            return View(user);
        }

        public ActionResult Edit(int? id)
        {
            if (!checkAdmin()) return Redirect("/");
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User user = db.Users.Find(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            user.password = null;
            user.listGender = getListGender();
            return View(user);
        }

        [HttpPost]
        public ActionResult Edit(User user)
        {
            if (ModelState.IsValid)
            {
                user.role = "admin";
                db.Entry(user).State = EntityState.Modified;
                db.SaveChanges();
                TempData["success"] = "Cập nhật thành công!";
                return RedirectToAction("Index");
            }
            user.listGender = getListGender();
            TempData["error"] = "Cập nhật thất bại!";
            return View(user);
        }

        public ActionResult Delete(int? id)
        {
            User user = db.Users.Find(id);
            db.Users.Remove(user);
            db.SaveChanges();
            TempData["success"] = "Xóa người dùng thành công!";
            return RedirectToAction("Index");
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

        public bool checkAdmin()
        {
            if(Session["userID"] == null)
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