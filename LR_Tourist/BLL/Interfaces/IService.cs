using System.Collections.Generic;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    public interface IService<T> 
        where T : class
    {
         Task<T> GetItem(int id);

         Task<IEnumerable<T>> GetItems();
    }
}
