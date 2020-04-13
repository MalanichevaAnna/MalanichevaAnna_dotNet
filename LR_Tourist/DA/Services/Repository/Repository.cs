using DA.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DA.Services.Repository
{
    public class Repository<T> : IRepository<T>
        where T : class, IEntityBase
    {
        public Context Context { get; set; }
        
        public Repository()
        {
            Context = new Context();
        }

        async Task<IEnumerable<T>> IRepository<T>.GetAll()
        {
            return await Context.Set<T>().ToListAsync();
        }

        public async Task Create(T item)
        {
            await Context.Set<T>().AddAsync(item);
            await Context.SaveChangesAsync();
        }

        public async Task Update(T item)
        {
            var entry = await Context.Set<T>().FirstAsync(e => e.Id == item.Id);
            Context.Entry(entry).CurrentValues.SetValues(item);
            await Context.SaveChangesAsync();
        }

        public async Task Save()
        {
           await Context.SaveChangesAsync();
        }

        public IEnumerable<T> Find(Func<T, bool> predicate)
        {
            return Context.Set<T>().Where(predicate).ToList();
        }

        public async Task<T> Get(int id)
        {
            return await Context.Set<T>().FindAsync(id);
        }

        public async Task Delete(int id)
        {
            var item = Context.Set<T>().Find(id);
            if (item != null)
            {
                 Context.Set<T>().Remove(item);
            }
            await Context.SaveChangesAsync();
        }
    }
}
