using System.Collections.Generic;
using System.Threading.Tasks;
using BLL.Model;

namespace BLL.Interfaces
{
    public interface ITravelVoucherService
    {
        Task MakeOrder(int idTravelVoucher, int idUser );
    }
}
