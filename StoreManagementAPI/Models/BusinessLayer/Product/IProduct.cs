using System;
using System.Collections.Generic;
using System.Text;

namespace StoreManagementAPI.Models.BusinessLayer
{
    public interface IProduct
    {
        int ID { get; set; }
        string Prod_Name { get; set; }
        decimal? Price { get; set; }
        ICurrency Currency { get; set; }
        IUnit Unit { get; set; }
        ICategory Category { get; set; }

    }
}
