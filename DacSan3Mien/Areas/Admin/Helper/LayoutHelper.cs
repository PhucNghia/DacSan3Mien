using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DacSan3Mien.Areas.Admin.Helper
{
    public static class LayoutHelper
    {
        // GET: Admin/LaybleHelper
        public static string activeNavbar(this HtmlHelper helper, string currentController, string controllerName)
        {
            if (currentController.Equals(controllerName))
                return "active";
            else
                return "";
        }
    }
}