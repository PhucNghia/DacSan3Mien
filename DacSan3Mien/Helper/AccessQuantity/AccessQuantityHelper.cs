using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DacSan3Mien.Helper.AccessQuantity
{
    public static class AccessQuantityHelper
    {
        public static bool checkAccess(this HtmlHelper helper)
        {
            HttpContext context = HttpContext.Current;

            if (context.Session["AccessQuantity"] == null)
            {
                context.Session["AccessQuantity"] = "true";
                return true;
            }
            else
            {
                context.Session["AccessQuantity"] = "false";
                return false;
            }
        }
    }
}