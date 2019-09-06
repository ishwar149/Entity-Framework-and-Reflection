using BusinessObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GroceryStoreUI.Controllers
{
    public class UserAccountController : Controller
    {

        string cookiekey = "AsianStoreCart";
        // GET: UserAccount
        public ActionResult Cart()
        {
            List<Product> products = new List<Product>();
            string cookie = CookieStore.GetCookie(cookiekey);
            foreach (string s in cookie.Split(','))
            {
                string[] strings = s.Split(':');
                Product product = DataAccess.ProductDA.GetSingle(Convert.ToInt32(strings[0]));
                product.quantity = Convert.ToInt32(strings[1]);
                products.Add(product);
            }
            ViewBag.CartTotal = products.Sum(p => p.Price * p.quantity);
            return View(products);
        }
        public ActionResult CheckOut()
        {
            return View();
        }

        public ActionResult LoginSignUp()
        {
            return View();
        }

        public JsonResult AddItemToCart(int ID, int Quantity)
        {

            if (CookieStore.GetCookie(cookiekey).Contains(ID.ToString()))
            {
                return Json(new { Added = 2 }, JsonRequestBehavior.AllowGet);
            }
            else
            {
                string cookievalue = ID + ":" + Quantity;
                TimeSpan cookieexpire = new TimeSpan(1000, 0, 0, 0);
                CookieStore.SetCookie(cookiekey, cookievalue, cookieexpire);
                return Json(new { Added = 1 }, JsonRequestBehavior.AllowGet);
            }
        }

    }
}