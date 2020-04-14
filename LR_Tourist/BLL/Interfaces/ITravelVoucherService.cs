using System.Threading.Tasks;

namespace BLL.Interfaces
{
    public interface ITravelVoucherService
    {
        Task MakeOrder(int idTravelVoucher, int idUser );
    }
}
