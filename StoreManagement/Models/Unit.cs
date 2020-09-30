using StoreSchema;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StoreManagement.Models
{
    public class Unit:IUnit
    {
        public int ID { get; set; }
        public string Unit_Name { get; set; }
        public Unit()
        {

        }
    }
}