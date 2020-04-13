
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    public interface ICRUDService<T>
        where T : class
    {
        Task Create(T item);

        Task Update(T item);

        Task Delete(int id);
    }
}
