using System.Collections.Generic;
using System.Threading.Tasks;
using BLL.Model;

namespace BLL.Interfaces
{
    public interface ITravelVoucherService
    {
        Task MakeOrder(int idTravelVoucher, int idUser );

        Task<TravelVoucher> GetTravelVoucher(int id);

        Task<IEnumerable<TravelVoucher>> GetTravelVouchers();
    }
}
