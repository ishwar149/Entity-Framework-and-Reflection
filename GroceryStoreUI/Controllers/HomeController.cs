using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DataAccess;

namespace GroceryStoreUI.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View(ProductTypeDA.GetAll());
        }

        public ActionResult ItemsPartial(int ID)
        {
            ViewBag.TypeName = ProductTypeDA.GetSingle(ID).Name;
            return PartialView("~/Views/Home/Partials/ItemsPartial.cshtml", ProductDA.GetAllByType(ID));
        }

        public ActionResult ItemDetailsPartial(int ID)
        {
            return PartialView("~/Views/Home/Partials/ItemDetailsPartial.cshtml", ProductDA.GetSingle(ID));
        }

        public ActionResult ContactUs()
        {
            return View();
        }

    }
}
