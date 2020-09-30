using System;
using System.Collections.Generic;
using System.Text;

namespace StoreManagementAPI.Models.BusinessLayer
{
    public interface ICategory
    {
        int ID { get; set; }
        string Category_Name { get; set; }
        bool InUse { get; set; }

    }
}
