
namespace BLL.Services.Validation
{
    public interface IValidation<T>
        where T : class
    {
        T AddAfterChecking(T item);
    }
}
