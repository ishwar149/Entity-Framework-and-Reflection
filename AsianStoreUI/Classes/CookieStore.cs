using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AsianStoreUI
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
        public static void DeleteCookieItem(string key, int ID, TimeSpan expires)
        {
            if (HttpContext.Current.Request.Cookies[key] != null)
            {
                var cookieOld = HttpContext.Current.Request.Cookies[key];
                cookieOld.Expires = DateTime.Now.Add(expires);
                string[] Products = cookieOld.Value.Split(',');
                string CookienewValue = string.Join(",", Products.Where(c => c.Split(':')[0] != Convert.ToString(ID)));
                cookieOld.Value = CookienewValue;
                HttpContext.Current.Response.Cookies.Add(cookieOld);
            }
        }
    }
}