
using System;
using System.Collections.Generic;

namespace BLL.Interfaces
{
    public interface ICRUDService<T>
        where T : class
    {
        void Create(T item);

        void Update(T item);

        void Delete(T item);

        void Delete(int id);

        void Save();

    }
}
