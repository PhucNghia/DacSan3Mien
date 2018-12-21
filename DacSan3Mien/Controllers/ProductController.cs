using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using DacSan3Mien.Models;
using DacSan3Mien.Models.ViewModels;
using PagedList;
using PagedList.Mvc;

namespace DacSan3Mien.Controllers
{
    public class ProductController : Controller
    {
        DataContext db = new DataContext();

        public ActionResult Index(string searchProduct, int page = 1, int pageSize = 5)
        {
            IQueryable<Product> products = db.Products;
            if (!String.IsNullOrEmpty(searchProduct))
            {
                products = products.Where(p => p.name.Contains(searchProduct));
            }

            ViewBag.productTop = db.Products.Take(7).ToList();

            return View(products.OrderBy(n => n.name).ToPagedList(page, pageSize));
        }

        public ActionResult Show(int? id)
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

            ProductRegions productRegion = new ProductRegions
            {
                productId = product.id,
                productName = product.name,
                image = product.image,
                price = product.price,
                status = product.status,
                description = product.description,
                regionId = product.regionId,
                regionName = product.Region.name
            };

            ViewBag.productTop = db.Products.Take(6).ToList();
            return View(productRegion);
        }
    }
}