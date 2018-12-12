using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DacSan3Mien.Models;

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

        public ActionResult Show()
        {
            return View();
        }
    }
}