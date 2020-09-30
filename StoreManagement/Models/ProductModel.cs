using StoreSchema;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace StoreManagement.Models
{
    [Serializable]
    public class ProductModel:IProduct
    {
        public int ID { get; set; }
        
        [Required(ErrorMessage = "Enter Product Name")]
        public string Prod_Name { get; set; }


        [Required(ErrorMessage = "Enter Price")]
        [DisplayFormat(DataFormatString = "{0:n2}", ApplyFormatInEditMode = true)]
        public decimal? Price { get; set; }


        [Required(ErrorMessage = "Select Currency")]
        public int Currency_ID { get; set; }
        public string Currency_Name { get; set; }


        [Required(ErrorMessage = "Select Unit")]
        public int Unit_ID { get; set; }
        public string Unit_Name { get; set; }

        [Required(ErrorMessage = "Select Category")]
        public int Category_ID { get; set; }
        public string Category_Name { get; set; }
        public string Mode { get; set; }

        public SelectList Categories { get; set; }
        public SelectList Units { get; set; }
        public SelectList Currencies { get; set; }

        public ProductModel()
        {
            ID = -1;
            Mode = "A";
        }
        public ProductModel(ModelRequest productRequest)
            : this()
        {
            if (productRequest.ID != null && productRequest.ID > 0)
            {
                ID = productRequest.ID;

                var product = Models.Common.CommonFunctionalities.ExecuteGetRequest<Product>("api/Product/GetProduct/" + ID.ToString(), RestSharp.Method.GET);
                Prod_Name = product.Prod_Name;
                Price = product.Price;
                Currency_ID = product.Currency_ID;
                Currency_Name = product.Currency_Name;
                Unit_ID = product.Unit_ID;
                Unit_Name = product.Unit_Name;
                Category_ID = product.Category_ID;
                Category_Name = product.Category_Name;
                Mode = productRequest.Mode;
            }
            if(!Mode.Equals("D",StringComparison.InvariantCultureIgnoreCase))
            {
                LoadSelectLists();
            }
        }

        public void LoadSelectLists()
        {
            var currencies = Models.Common.CommonFunctionalities.ExecuteGetRequest<List<Currency>>("api/Currency/GetAll".ToString(), RestSharp.Method.GET);
            Currencies = new SelectList(currencies.Select(x => new { Value = x.ID, Text = x.Currency_Name }), "Value", "Text", Currency_ID);

            var units = Models.Common.CommonFunctionalities.ExecuteGetRequest<List<Unit>>("api/Unit/GetAll".ToString(), RestSharp.Method.GET);
            Units = new SelectList(units.Select(x => new { Value = x.ID, Text = x.Unit_Name }), "Value", "Text", Unit_ID);

            var categories = Models.Common.CommonFunctionalities.ExecuteGetRequest<List<Category>>("api/Category/GetAll", RestSharp.Method.GET);
            Categories = new SelectList(categories.Select(x => new { Value = x.ID, Text = x.Category_Name }), "Value", "Text", Category_ID);

        }

        public bool Save()
        {
            Product product = new Product();
            product.ID = ID;
            product.Prod_Name = Prod_Name;
            product.Price = Price;
            product.Currency_ID = Currency_ID;
            product.Currency_Name = Currency_Name;
            product.Unit_ID = Unit_ID;
            product.Unit_Name = Unit_Name;
            product.Category_ID = Category_ID;
            product.Category_Name = Category_Name;

            var response = false;
            switch (Mode)
            {
                case "A":
                    {
                        response = Models.Common.CommonFunctionalities.ExecuteGetRequest<bool, IProduct>("api/Product/Add", product, RestSharp.Method.POST);
                        break;
                    }
                case "M":
                    {
                        response = Models.Common.CommonFunctionalities.ExecuteGetRequest<bool, IProduct>("api/Product/Update", product, RestSharp.Method.POST);
                        break;
                    }
                case "D":
                    {
                        response = Models.Common.CommonFunctionalities.ExecuteGetRequest<bool>("api/Product/Delete/" + ID.ToString(), RestSharp.Method.GET);
                        break;
                    }
            }

            return response;
        }

    }
}