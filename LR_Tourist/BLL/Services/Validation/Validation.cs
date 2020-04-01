using DA.Repository;
using BLL.ValidException;
namespace BLL.Services.Validation
{
    public class Validation<T> : IValidation<T>
        where T : class
    {
        private readonly IRepository<T> repository;

        public Validation(IRepository<T> repo)
        {
            repository = repo;
        }
        public T AddAfterChecking(T item)
        {
            if (item == null)
            {
                throw new ValidationException("Object is empty", "");
            }
            else
            {
                repository.Create(item);
                repository.Save();
                return item;
            }

        }
    }
}
