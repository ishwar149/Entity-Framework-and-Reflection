using AsianStoreUI.Models;
using BusinessObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AsianStoreUI.Controllers
{
    public class UserAccountController : BaseController
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
                if (!string.IsNullOrEmpty(strings[0]))
                {
                    Product product = DataAccess.ProductDA.GetSingle(Convert.ToInt32(strings[0]));
                    product.quantity = Convert.ToInt32(strings[1]);
                    products.Add(product);
                }
            }
            ViewBag.CartTotal = products.Sum(p => p.Price * p.quantity);
            return View(products);
        }

        public ActionResult CheckOut()
        {
            if (User.Identity.IsAuthenticated)
            {
                List<Product> products = new List<Product>();
                string cookie = CookieStore.GetCookie(cookiekey);
                foreach (string s in cookie.Split(','))
                {
                    string[] strings = s.Split(':');
                    if (!string.IsNullOrEmpty(strings[0]))
                    {
                        Product product = DataAccess.ProductDA.GetSingle(Convert.ToInt32(strings[0]));
                        product.quantity = Convert.ToInt32(strings[1]);
                        products.Add(product);
                    }
                }
                ViewBag.CartTotal = products.Sum(p => p.Price * p.quantity) + 7;
                return View(products);
            }
            else
                return RedirectToAction("LoginSignUp", "UserAccount");
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

        public ActionResult DeleteCartItem(int ID, string Url)
        {
            TimeSpan cookieexpire = new TimeSpan(1000, 0, 0, 0);
            CookieStore.DeleteCookieItem(cookiekey, ID, cookieexpire);
            return RedirectToAction(Url, "UserAccount");
        }

        public PartialViewResult CustomerAddress()
        {
            CustomerProfile Profile = DataAccess.CustomerProfileDA.GetByUser(User.Identity.Name);
            ViewBag.CustomerProfile = Profile;
            return PartialView("~/Views/UserAccount/Partials/CustomerAddressPartial.cshtml", DataAccess.CustomerAddressDA.GetCustomerAddress(Profile.ID));
        }

        public JsonResult SaveAddress(CustomerAddress Address)
        {
            if (Address.ID != 0)
                DataAccess.CustomerAddressDA.Update(Address.ID, Address);
            else
                DataAccess.CustomerAddressDA.Add(Address);
            return Json(new { Added = 1 }, JsonRequestBehavior.AllowGet);
        }


        public PartialViewResult PaymentPartial(int PaymentType)
        {
            string PaymentTitle = string.Empty;
            if (PaymentType == 1)
                PaymentTitle = "Cash On Delivery";
            else if (PaymentType == 2)
                PaymentTitle = "Paypal";
            else
                PaymentTitle = "Credit or Debit Card";
            ViewBag.PaymentType = PaymentType;
            ViewBag.PaymentTitle = PaymentTitle;
            return PartialView("~/Views/UserAccount/Partials/PaymentPartial.cshtml");
        }


    }
}