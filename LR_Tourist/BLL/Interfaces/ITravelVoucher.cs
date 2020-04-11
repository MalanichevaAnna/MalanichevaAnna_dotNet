using System.Collections.Generic;
using BLL.Model;
namespace BLL.Interfaces
{
    public interface ITravelVoucher
    {
        void MakeOrder(int idTravelVoucher, int idUser );

        TravelVoucherDTO GetTravelVoucher(int? id);

        IEnumerable<TravelVoucherDTO> GetTravelVouchers();

    }
}
