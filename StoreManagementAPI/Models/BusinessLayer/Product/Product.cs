using StoreSchema;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StoreManagementAPI.Models.BusinessLayer
{
    public class Product : IProduct
    {
        public int ID { get; set; }
        public string Prod_Name { get; set; }
        public decimal? Price { get; set; }
        public int Currency_ID { get; set; }
        public string Currency_Name { get; set; }
        public int Unit_ID { get; set; }
        public string Unit_Name { get; set; }
        public int Category_ID { get; set; }
        public string Category_Name { get; set; }
        public Product()
        {

        }
    }
}