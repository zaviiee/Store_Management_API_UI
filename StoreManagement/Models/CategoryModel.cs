using StoreSchema;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace StoreManagement.Models
{
    [Serializable]
    public class CategoryModel:ICategory
    {
        public int ID { get; set; }

        [Required(ErrorMessage ="Enter Category Name")]
        public string Category_Name { get; set; }

        public bool InUse { get; set; }
        public string Mode { get; set; }

        public CategoryModel()
        {
            ID = -1;
            Mode = "A";
            InUse = false;
        }

        public CategoryModel(ModelRequest categoryRequest)
            : this()
        {
            if (categoryRequest.ID != null && categoryRequest.ID > 0)
            {
                ID = categoryRequest.ID;

                var category = Models.Common.CommonFunctionalities.ExecuteGetRequest<Category>("api/Category/GetCategory/" + ID.ToString(),  RestSharp.Method.GET);
                Category_Name = category.Category_Name;
                InUse = category.InUse;

                Mode = categoryRequest.Mode;
            }
        }


        public bool Save()
        {
            Category category = new Category();
            category.ID = ID;
            category.Category_Name = Category_Name;

            var response = false;
            switch (Mode)
            {
                case "A":
                    {
                        response = Models.Common.CommonFunctionalities.ExecuteGetRequest<bool, ICategory>("api/Category/Add", category, RestSharp.Method.POST);
                        break;
                    }
                case "M":
                    {
                        response = Models.Common.CommonFunctionalities.ExecuteGetRequest<bool, ICategory>("api/Category/Update", category, RestSharp.Method.POST);
                        break;
                    }
                case "D":
                    {
                        response = Models.Common.CommonFunctionalities.ExecuteGetRequest<bool>("api/Category/Delete/" + ID.ToString(),  RestSharp.Method.GET);
                        break;
                    }
            }

            return response;
        }
    }
}