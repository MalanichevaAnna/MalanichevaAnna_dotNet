using DA.Repository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DA.Services.Repository
{
    public class Repository<T> : IRepository<T>
        where T : class
    {
        public Context Context { get; set; }
        
        public Repository()
        {
            Context = new Context();
        }

        IEnumerable<T> IRepository<T>.GetAll()
        {
            return Context.Set<T>().ToList();
        }

        public void Create(T item)
        {
            Context.Set<T>().Add(item);
        }

        public void Update(T item)
        {
            Context.Set<T>().Update(item);
        }

        public void Delete(T item)
        {
            Context.Set<T>().Remove(item);
        }

        public void Save()
        {
            Context.SaveChanges();
        }

        public IEnumerable<T> Find(Func<T, bool> predicate)
        {
            return Context.Set<T>().Where(predicate).ToList();
        }

        public T Get(int id)
        {
            return Context.Set<T>().Find(id);
        }

        public void Delete(int id)
        {
            var item = Context.Set<T>().Find(id);
            if(item != null)
            {
                 Context.Set<T>().Remove(item);
            }
        }
    }
}
