using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace POS.DTO.Interface
{
    public interface IManageCrudOperation<T>
    {
        List<T> GetAll();
        long Create(T obj);
        T GetByID(long key);        
        bool Update(T obj);
        bool Delete(long key);
    }
}
