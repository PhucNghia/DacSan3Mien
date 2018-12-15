using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using DacSan3Mien.Models;
using DacSan3Mien.Models.ViewModels;

namespace DacSan3Mien.Controllers
{
    public class ProductController : Controller
    {
        DataContext db = new DataContext();

        // GET: Product
        public ActionResult Index()
        {
            var products = db.Products.Select(row => row).ToList();
            return View(products);
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

            return View(productRegion);
        }
    }
}