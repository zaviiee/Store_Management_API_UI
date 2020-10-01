//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace StoreManagementAPI.Models.DataLayer
{
    using System;
    using System.Collections.Generic;
    
    public partial class Product
    {
        public int ID { get; set; }
        public string Product_Name { get; set; }
        public Nullable<int> CategoryXID { get; set; }
        public Nullable<int> UnitXID { get; set; }
        public Nullable<decimal> Price { get; set; }
        public Nullable<int> CurrencyXID { get; set; }
        public Nullable<System.DateTime> Last_Edit { get; set; }
    
        public virtual Category Category { get; set; }
        public virtual Currency Currency { get; set; }
        public virtual Unit Unit { get; set; }
    }
}