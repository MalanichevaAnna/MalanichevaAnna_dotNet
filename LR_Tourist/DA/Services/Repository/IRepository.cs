using DA.Data;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DA.Services.Repository
{
    public interface IRepository<T>
        where T : class, IEntityBase
    {
        Task<IEnumerable<T>> GetAll();

        Task<T>  Get(int id);

        IEnumerable<T> Find(Func<T, bool> predicate);

        Task Create(T item);

        Task Update(T item);

        Task Delete(int id);
    }
}
