using AutoMapper;
using BLL.Interfaces;
using BLL.Model;
using DA.Data;
using DA.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.Services
{
    public class TravelVoucherServices : ITravelVoucher
    {
        IRepository<User> DB { get; set; }

        public ProfileUser GetUser(int? id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ProfileUser> GetUsers()
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<User, ProfileUser>()).CreateMapper();
            return mapper.Map<IEnumerable<User>, List<ProfileUser>>(DB.GetAll());
        }

        public void MakeOrder(ProfileUser profileTravelVoucher)
        {
            throw new NotImplementedException();
        }
    }
}
