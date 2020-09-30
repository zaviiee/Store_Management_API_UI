using System;
using System.Collections.Generic;
using System.Text;

namespace StoreSchema
{
    public interface IProduct
    {
        int ID { get; set; }
        string Prod_Name { get; set; }
        decimal? Price { get; set; }
        int Currency_ID { get; set; }
        string Currency_Name { get; set; }
        int Unit_ID { get; set; }
        string Unit_Name { get; set; }
        int Category_ID { get; set; }
        string Category_Name { get; set; }

    }
}
