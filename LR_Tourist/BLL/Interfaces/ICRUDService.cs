using BLL.Model;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    public interface ICRUDService<T>
        where T : class, IEntityBase
    {
        Task Create(T item);

        Task Update(T item);

        Task Delete(int id);
    }
}
