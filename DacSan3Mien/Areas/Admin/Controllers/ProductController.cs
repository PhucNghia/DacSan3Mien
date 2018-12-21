using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using DacSan3Mien.Models;
using DacSan3Mien.Models.ViewModels;
using PagedList;

namespace DacSan3Mien.Areas.Admin.Controllers
{
    public class ProductController : Controller
    {
        private DataContext db = new DataContext();

        public ActionResult Index(int page = 1, int pageSize = 5)
        {
            if (!checkAdmin()) return Redirect("/");;
            var productList = db.Products.Select(p => new ProductRegions
            {
                productId = p.id,
                productName = p.name,
                image = p.image,
                price = p.price,
                status = p.status,
                description = p.description,
                regionId = p.regionId,
                regionName = p.Region.name
            }).OrderBy(n => n.productName).ToPagedList(page, pageSize);

            return View(productList);
        }
        
        public ActionResult Details(int? id)
        {
            if (!checkAdmin()) return Redirect("/");;
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = db.Products.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            product.listRegion = getListRegion(product.regionId);
            return View(product);
        }

        [HttpGet]
        public ActionResult Create()
        {
            if (!checkAdmin()) return Redirect("/");;
            Product product = new Product();
            product.listRegion = getListRegion(1);

            return View(product);
        }

        [HttpPost]
        public ActionResult Create(Product product)
        {
            if (ModelState.IsValid)
            {
                db.Products.Add(product);
                db.SaveChanges();
                TempData["success"] = "Thêm sản phẩm thành công!";
                return RedirectToAction("Index");
            }
            TempData["error"] = "Thêm sản phẩm thất bại!";
            product.listRegion = getListRegion(null);

            return View(product);
        }

        public ActionResult Edit(int? id)
        {
            if (!checkAdmin()) return Redirect("/");;
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = db.Products.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            product.listRegion = getListRegion(product.regionId);
            return View(product);
        }

        [HttpPost]
        public ActionResult Edit(Product product)
        {
            if (ModelState.IsValid)
            {
                db.Entry(product).State = EntityState.Modified;
                db.SaveChanges();
                TempData["success"] = "Cập nhật sản phẩm thành công!";
                return RedirectToAction("Index");
            }
            product.listRegion = getListRegion(product.regionId);
            TempData["error"] = "Cập nhật sản phẩm thất bại!";
            return View(product);
        }

        public ActionResult Delete(int? id)
        {
            if (!checkAdmin()) return Redirect("/");;
            Product product = db.Products.Find(id);
            db.Products.Remove(product);
            db.SaveChanges();
            TempData["success"] = "Xóa sản phẩm thành công!";
            return RedirectToAction("Index");
        }
  
        private List<SelectListItem> getListRegion(int? idRegion)
        {
            SelectListItem north = new SelectListItem { Text = "Miền Bắc", Value = "1" };
            SelectListItem central = new SelectListItem { Text = "Miền Trung", Value = "2" };
            SelectListItem south = new SelectListItem { Text = "Miền Nam", Value = "3" };
            List<SelectListItem> list = new List<SelectListItem>();

            north.Selected = idRegion == 1 ? true : false;
            central.Selected = idRegion == 2 ? true : false;
            south.Selected = idRegion == 3 ? true : false;
            list.Add(north);
            list.Add(central);
            list.Add(south);
            
            return list;
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