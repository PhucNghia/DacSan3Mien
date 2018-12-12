using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DacSan3Mien.Models;

namespace DacSan3Mien.Controllers
{
    public class HomeController : Controller
    {
        DataContext db = new DataContext();
        private DataContext dbcontext = new DataContext();
        public ActionResult Index()
        {
            return View();
        }

       // [HttpDelete]
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}