using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DacSan3Mien.Models;

namespace DacSan3Mien.Helper.Product
{
    public static class ProductHelper
    {
        private static DataContext db = new DataContext();
        public static bool checkAdmin(this HtmlHelper helper, int? id)
        {
            if (id == null)
                return false;
            User user = db.Users.Find(id);
            if (user == null)
                return false;
            if (user.role == "admin")
                return true;
            return false;
        }
    }
}