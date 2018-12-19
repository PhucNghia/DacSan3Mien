using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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

        public static string formatMoney(this HtmlHelper helper, string money)
        {
            string str = money + "";
            List<char> arrChar = new List<char>();
            char[] arr = str.ToCharArray();
            if (arr.Length <= 3)
                return str;
            else
            {
                for (int i = 0; i < arr.Length; i++)
                    arrChar.Add(arr[i]);

                int count = 1;
                for (int i = arr.Length - 1; i >= 0; i--)
                {
                    if (count < 3)
                        count++;
                    else if (count == 3)
                    {
                        if (i != 0)
                        {
                            arrChar.Insert(arrChar.Count - (arrChar.Count - i), ',');
                            count = 1;
                        }
                    }
                }
                string result = String.Join("", arrChar);

                if (result[0] == '-' && result[1] == ',')
                {
                    StringBuilder sb = new StringBuilder(result);
                    sb.Remove(1, 1);
                    result = sb.ToString();
                }
                return result;
            }
        }

        public static string actionForm(this HtmlHelper helper, string viewBagTitle)
        {
            return viewBagTitle;
        }
    }
}