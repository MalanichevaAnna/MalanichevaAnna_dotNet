using System.Collections.Generic;
using BLL.Model;
namespace BLL.Interfaces
{
    public interface ITravelVoucher
    {
        void MakeOrder(TravelVoucherDTO profileTravelVoucher,UserDTO profileUser );

        TravelVoucherDTO GetTravelVoucher(int? id);

        IEnumerable<TravelVoucherDTO> GetTravelVouchers();

    }
}
