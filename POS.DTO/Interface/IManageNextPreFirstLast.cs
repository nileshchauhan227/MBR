using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace POS.DTO.Interface
{
    public interface IManageNextPreFirstLast<T>
    {
        T GetPrevious(long key);
        T GetNext(long key);
        T GetFirst(long key);
        T GetLast(long key);
    }
}
