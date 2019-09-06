using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BusinessObjects;
using DataAccess;

namespace GroceryStoreAdmin.Controllers
{
    public class ManageSystemController : Controller
    {
        #region Manage Product Types
        public ActionResult ManageProductTypes()
        {
            List<ProductType> Ptypes = ProductTypeDA.GetAll();
            return View(Ptypes);
        }

        public ActionResult AddProductType(ProductType Ptype)
        {
            ProductTypeDA.Add(Ptype);
            return RedirectToAction("ManageProductTypes");
        }
        public ActionResult DeleteProductType(ProductType P)
        {
            ProductTypeDA.Delete(P.ID);
            return RedirectToAction("ManageProductTypes");
        }

        #endregion

        #region Manage Products
        public ActionResult ManageProducts(int? ID)
        {
            List<ProductType> Producttypes = ProductTypeDA.GetAll();
            if (ID == null)
            {

            }
            else
            {

            }
            return View(Producttypes);
        }

        public PartialViewResult ManageProductsPartial(int ID)
        {

            return PartialView("~/Views/ManageSystem/Partials/ManageProductsPartial.cshtml", ProductDA.GetAllByType(ID));
        }
        #region Add 
        public PartialViewResult AddProduct()
        {
            return PartialView("~/Views/ManageSystem/Partials/AddPartial.cshtml");
        }

        public JsonResult AddProductItem(Product Product)
        {
            Product = DataAccess.ProductDA.Add(Product);
            string ImageUrl;
            bool IsMainImage = true;
            if (Request.Files.Count > 0)
            {
                int n = 1;
                foreach (string key in Request.Files)
                {
                    HttpPostedFileBase file = Request.Files[key];
                    ImageUrl = $"/ProductImages/{Product.ID}_{n}_{file.FileName}";
                    file.SaveAs(Server.MapPath("~" + ImageUrl));
                    if (n > 1)
                        IsMainImage = false;
                    else
                    {
                        Product.MainImageURL = ImageUrl;
                        DataAccess.ProductDA.Update(Product.ID, Product);
                    }
                    DataAccess.ImageDA.Add(new Image { ImageURL = ImageUrl, IsMainImage = IsMainImage, ProductID = Product.ID });
                    n++;
                }
            }
            return Json(new { d = 1 }, JsonRequestBehavior.AllowGet);
        }

        #endregion

        #region Update 
        public PartialViewResult EditProduct(int ID)
        {
            Product p = ProductDA.GetSingle(ID);
            p.Images = ImageDA.GetCustomQuery($"Select * from Image Where ProductID={ID}");
            return PartialView("~/Views/ManageSystem/Partials/EditPartial.cshtml", p);
        }

        public JsonResult UpdateProductItem(Product Product)
        {
            DataAccess.ProductDA.Update(Product.ID, Product);
            string ImageUrl;
            bool IsMainImage = false;
            if (Request.Files.Count > 0)
            {
                int n = 1;
                foreach (string key in Request.Files)
                {
                    HttpPostedFileBase file = Request.Files[key];
                    ImageUrl = $"/ProductImages/{Product.ID}_{n}_{file.FileName}";
                    file.SaveAs(Server.MapPath("~" + ImageUrl));
                    Product.MainImageURL = ImageUrl;
                    DataAccess.ProductDA.Update(Product.ID, Product);
                    DataAccess.ImageDA.Add(new Image { ImageURL = ImageUrl, IsMainImage = IsMainImage, ProductID = Product.ID });
                    n++;
                }
            }
            return Json(new { d = 1 }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult UpdateMainImageUrL(int ID, string ImageURL)
        {
            Product p = ProductDA.GetSingle(ID);
            p.MainImageURL = ImageURL;
            ProductDA.Update(ID, p);
            p.Images = ImageDA.GetCustomQuery($"Select * from Image Where ProductID={ID}");
            return PartialView("~/Views/ManageSystem/Partials/EditPartial.cshtml", p);
        }

        #endregion

        public ActionResult DeleteImage(int ID, int ProductID)
        {
            DataAccess.ImageDA.Delete(ID);
            Product p = ProductDA.GetSingle(ProductID);
            p.Images = ImageDA.GetCustomQuery($"Select * from Image Where ProductID={ID}");
            return PartialView("~/Views/ManageSystem/Partials/EditPartial.cshtml", p);

        }

        public ActionResult DeleteProduct(Product P)
        {
            ProductDA.Delete(P.ID);
            return RedirectToAction("ManageProducts");
        }


        #endregion





    }
}