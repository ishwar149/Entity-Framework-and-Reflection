using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GroceryStoreUI
{
    public class CookieStore
    {
        public static void SetCookie(string key, string value, TimeSpan expires)
        {
            HttpCookie Cookie = new HttpCookie(key, value);

            if (HttpContext.Current.Request.Cookies[key] != null)
            {
                var cookieOld = HttpContext.Current.Request.Cookies[key];
                cookieOld.Expires = DateTime.Now.Add(expires);
                cookieOld.Value = Cookie.Value + "," + GetCookie(key);
                HttpContext.Current.Response.Cookies.Add(cookieOld);
            }
            else
            {
                Cookie.Expires = DateTime.Now.Add(expires);
                HttpContext.Current.Response.Cookies.Add(Cookie);
            }
        }
        public static string GetCookie(string key)
        {
            string value = string.Empty;
            HttpCookie cookie = HttpContext.Current.Request.Cookies[key];

            if (cookie != null)
            {
                HttpCookie Cookie = cookie;
                value = Cookie.Value;
            }
            return value;
        }

    }
}