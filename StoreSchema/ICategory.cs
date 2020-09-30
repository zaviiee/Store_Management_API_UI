using System;
using System.Collections.Generic;
using System.Text;

namespace StoreSchema
{
    public interface ICategory
    {
        int ID { get; set; }
        string Category_Name { get; set; }
        bool InUse { get; set; }

    }
}
