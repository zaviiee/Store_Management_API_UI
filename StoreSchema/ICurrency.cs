using System;
using System.Collections.Generic;
using System.Text;

namespace StoreSchema
{
    public interface ICurrency
    {
        int ID { get; set; }
        string Currency_Name { get; set; }
    }
}
