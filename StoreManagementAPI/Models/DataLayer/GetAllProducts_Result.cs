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
    
    public partial class GetAllProducts_Result
    {
        public int ID { get; set; }
        public string Product_Name { get; set; }
        public int Category_ID { get; set; }
        public string Category_Name { get; set; }
        public int Unit_ID { get; set; }
        public string Unit_Name { get; set; }
        public int Currency_ID { get; set; }
        public string Currency_Name { get; set; }
        public Nullable<decimal> Price { get; set; }
    }
}
