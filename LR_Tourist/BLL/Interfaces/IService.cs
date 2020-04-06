using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.Interfaces
{
    public interface IService<T> 
        where T : class
    {
         T GetItem(int? id);

         IEnumerable<T> GetItems();
    }
}
