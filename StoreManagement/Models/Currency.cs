using StoreSchema;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StoreManagement.Models
{
    public class Currency:ICurrency
    {
        public int ID { get; set; }
        public string Currency_Name { get; set; }

        public Currency()
        {

        }
    }
}