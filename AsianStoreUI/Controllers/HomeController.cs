using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DataAccess;

namespace AsianStoreUI.Controllers
{
    public class HomeController : BaseController
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

        public PartialViewResult SliderPartial()
        {
            List<BusinessObjects.SliderProduct> Sps = DataAccess.SliderProductDA.GetAll();
            foreach (BusinessObjects.SliderProduct sp in Sps)
            {
                sp.Product = DataAccess.ProductDA.GetSingle(sp.ProductID);
                sp.SaleInfoLine = $"The Original Price for the {sp.Product.Name} is {sp.Product.Price}. The offer is valid only till {sp.OfferTill.Value.Date}. Click on Buy It Today if you do not want to miss this offer.";
            }
            return PartialView("~/Views/Home/Partials/SliderPartial.cshtml", Sps);
        }

        public PartialViewResult RecommendedItemsPartial()
        {
            List<BusinessObjects.RecommendedProduct> Recommended = DataAccess.RecommendedProductDA.GetAll();
            List<BusinessObjects.Product> Products = DataAccess.ProductDA.GetRecommended(Recommended.Select(c => c.ProductID).ToList());
            return PartialView("~/Views/Home/Partials/RecommendedItemsPartial.cshtml", Products);
        }

        public ActionResult CheapestProductPartial(int ID)
        {
            return PartialView("~/Views/Home/Partials/CheapestProductPartial.cshtml", ProductDA.GetCheapProductbyType(ID));
        }


    }
}
