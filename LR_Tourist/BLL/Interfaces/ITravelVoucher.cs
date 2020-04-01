using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.Interfaces
{
    public interface ITravelVoucher
    {
        void MakeOrder(ProfileOrder profileOrder);

        ProfileTravelVoucher GetTravelVoucher(int? id);

        IEnumerable<ProfileTravelVoucher> GetTravelVouchers();

        void Dispose();
    }
}
