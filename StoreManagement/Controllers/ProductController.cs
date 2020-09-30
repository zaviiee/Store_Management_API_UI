using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace StoreManagement.Controllers
{
    public class ProductController : Controller
    {
        public ActionResult _Product()
        {
            return View();
        }
        // GET: Product
        public ActionResult _ProductDetails()
        {
            var products = Models.Common.CommonFunctionalities.ExecuteGetRequest<List<Models.Product>>("api/Product/GetAll", RestSharp.Method.GET);
            return PartialView(products);
        }

        public ActionResult ShowAllProducts()
        {
            return PartialView("_Product");
        }


        public ActionResult ShowAllProductDetails()
        {
            var products = Models.Common.CommonFunctionalities.ExecuteGetRequest<List<Models.Product>>("api/Product/GetAll", RestSharp.Method.GET);
            return PartialView("_ProductDetails", products);
        }

        [HttpPost]
        public ActionResult ShowManageScreen(Models.ModelRequest productRequest)
        {
            Models.ProductModel product = new Models.ProductModel(productRequest);
            return PartialView("_Manage", product);
        }

        [HttpPost]
        public ActionResult Manage(Models.ProductModel product)
        {
            if (ModelState.IsValid || product.Mode == "D")
            {
                product.Save();
                return PartialView("_Product");
            }
            product.LoadSelectLists();
            return PartialView("_Manage", product);
        }

    }
}