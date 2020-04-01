using BLL.Model;
using System.Collections.Generic;

namespace BLL.Interfaces
{
    public interface IOrderService
    {
        void MakeOrder(ProfileOrder profileOrder);

        ProfileTravelVoucher GetTravelVoucher(int? id);

        IEnumerable<ProfileTravelVoucher> GetTravelVouchers();

        void Dispose();
    }
}
