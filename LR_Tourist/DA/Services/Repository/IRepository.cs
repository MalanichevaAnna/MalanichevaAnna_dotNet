using System;
using System.Collections.Generic;
using System.Text;

namespace DA.Repository
{
    public interface IRepository<T>
        where T : class
    {
        List<T> GetList(); 

        void Create(T item);

        void Update(T item);

        void Delete(T item);
    }
}
