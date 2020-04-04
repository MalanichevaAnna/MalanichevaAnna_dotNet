using System;
using System.Collections.Generic;
using System.Text;
using BLL.Model;
namespace BLL.Interfaces
{
    public interface ITravelVoucher
    {
        void MakeOrder(ProfileUser profileTravelVoucher );

        ProfileUser GetUser(int? id);

        IEnumerable<ProfileUser> GetUsers();

    }
}
