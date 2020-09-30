using System;
using System.Collections.Generic;
using System.Text;

namespace StoreManagementAPI.Models.BusinessLayer
{
    public interface IUnit
    {
        int ID { get; set; }
        string Unit_Name { get; set; }
    }
}
