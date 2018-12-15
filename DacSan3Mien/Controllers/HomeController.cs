using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DacSan3Mien.Models;
using DacSan3Mien.Models.ViewModels;

namespace DacSan3Mien.Controllers
{
    public class HomeController : Controller
    {
        DataContext db = new DataContext();
        
        public ActionResult Index()
        {
            ViewBag.northProducts = db.Products.Select(p => new ProductRegions
            {
                productId = p.id,
                productName = p.name,
                image = p.image,
                price = p.price,
                status = p.status,
                description = p.description,
                regionId = p.regionId,
                regionName = p.Region.name
            }).Where(p => p.regionId == 1).ToList();

            ViewBag.centralProducts = db.Products.Select(p => new ProductRegions
            {
                productId = p.id,
                productName = p.name,
                image = p.image,
                price = p.price,
                status = p.status,
                description = p.description,
                regionId = p.regionId,
                regionName = p.Region.name
            }).Where(p => p.regionId == 2).ToList();

            ViewBag.southProducts = db.Products.Select(p => new ProductRegions
            {
                productId = p.id,
                productName = p.name,
                image = p.image,
                price = p.price,
                status = p.status,
                description = p.description,
                regionId = p.regionId,
                regionName = p.Region.name
            }).Where(p => p.regionId == 3).ToList();

            return View();
        }
    }
}