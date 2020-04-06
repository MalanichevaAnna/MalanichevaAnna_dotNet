using System;
using System.Collections.Generic;
using System.Text;
using BLL.Model;
namespace BLL.Interfaces
{
    public interface ITravelVoucher
    {
        void MakeOrder(ProfileTravelVoucher profileTravelVoucher,ProfileUser profileUser );

        ProfileTravelVoucher GetTravelVoucher(int? id);

        IEnumerable<ProfileTravelVoucher> GetTravelVouchers();

    }
}
