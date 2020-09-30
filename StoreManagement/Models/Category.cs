using StoreSchema;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace StoreManagement.Models
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