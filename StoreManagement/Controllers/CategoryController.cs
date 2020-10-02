using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace StoreManagement.Controllers
{
    /// <summary>
    /// Handle Category UI
    /// </summary>
    ///
    public class CategoryController : Controller
    {
        // GET: Category
        public ActionResult _Category()
        {
            return View();
        }

        public ActionResult _CategoryDetails()
        {
            var categories = Models.Common.CommonFunctionalities.ExecuteGetRequest<List<Models.Category>>("api/Category/GetAll", RestSharp.Method.GET);
            return PartialView(categories);
        }

        public ActionResult ShowAllCategories()
        {
            return PartialView("_Category");
        }

        public ActionResult ShowAllCategoryDetails()
        {
            var categories = Models.Common.CommonFunctionalities.ExecuteGetRequest<List<Models.Category>>("api/Category/GetAll", RestSharp.Method.GET);
            return PartialView("_CategoryDetails", categories);
        }

        [HttpPost]
        public ActionResult ShowManageScreen(Models.ModelRequest categoryRequest)
        {
            Models.CategoryModel category = new Models.CategoryModel(categoryRequest);
            return PartialView("_Manage", category);
        }

        [HttpPost]
        public ActionResult Manage(Models.CategoryModel category)
        {
            if (ModelState.IsValid || category.Mode == "D")
            {
                category.Save();
                return PartialView("_Category");
            }
            return PartialView("_Manage", category);
        }

    }
}