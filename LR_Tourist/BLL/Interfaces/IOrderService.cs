using BLL.Model;
using System.Collections.Generic;

namespace BLL.Interfaces
{
    public interface IOrderService
    {
        void MakeOrder(ProfileOrder profileOrder);

        ProfileUser GetTravelVoucher(int? id);

        IEnumerable<ProfileUser> GetTravelVouchers();

        void Dispose();
    }
}
