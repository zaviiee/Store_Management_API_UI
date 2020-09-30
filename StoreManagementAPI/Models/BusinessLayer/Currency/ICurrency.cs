using System;
using System.Collections.Generic;
using System.Text;

namespace StoreManagementAPI.Models.BusinessLayer
{
    public interface ICurrency
    {
        int ID { get; set; }
        string Currency_Name { get; set; }
    }
}
