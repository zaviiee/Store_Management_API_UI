using System;
using System.Collections.Generic;
using System.Text;

namespace StoreManagementAPI.Models.BusinessLayer
{
    public interface ICommonRepository<T> : ICommonReadonlyRepository<T>
    {
        bool Add(T obj);
        bool Update(T obj);
        bool Delete(int ID); 
    }
}
