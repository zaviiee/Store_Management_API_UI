using StoreSchema;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StoreManagementAPI.Models.BusinessLayer
{
    public class Category : ICategory
    {
        public int ID { get; set; }
        public string Category_Name { get; set; }
        public bool InUse { get; set; }

        public Category()
        { 
        }
    }
}