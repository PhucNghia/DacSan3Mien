using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using DacSan3Mien.Models;
using DacSan3Mien.Models.ViewModels;

namespace DacSan3Mien.Areas.Admin.Controllers
{
    public class ProductController : Controller
    {
        private DataContext db = new DataContext();

        public ActionResult Index()
        {
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
            }).ToList();

            return View(productList);
        }

        public ActionResult Details(int? id)
        {
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
    }
}