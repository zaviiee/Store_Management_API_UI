using System;
using System.Collections.Generic;
using System.Text;

namespace StoreManagementAPI.Models.BusinessLayer
{
    public interface ICommonReadonlyRepository<T>
    {
        List<T> GetAll();
        T GetByID(int ID);
    }
}
