using BLL.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    public interface IEntityManagementService<T>
        where T : class, IEntityBase
    {
        Task Create(T item);

        Task Update(T item);

        Task Delete(int id);

        Task<T> GetItem(int id);

        Task<IEnumerable<T>> GetItems();
    }
}
