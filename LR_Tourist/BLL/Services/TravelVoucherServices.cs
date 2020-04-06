using AutoMapper;
using BLL.Interfaces;
using BLL.Model;
using BLL.ValidException;
using DA.Data;
using DA.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.Services
{
    public class TravelVoucherServices : ITravelVoucher, ICRUDService<TravelVoucher>
    {
        IRepository<User> repoUser { get; set; }

        IRepository<TravelVoucher> repoTravelVoucher { get; set; }
        TravelVoucherServices(IRepository<User> repositoryUser, IRepository<TravelVoucher> repositoryTravelVoucher)
        {
            repoUser = repositoryUser;
            repoTravelVoucher = repositoryTravelVoucher;
        }
        public ProfileTravelVoucher GetTravelVoucher(int? id)
        {
            if (id == null)
                throw new ValidationException("Не установлено id путевки ", "");
            var travelVoucher = repoTravelVoucher.Get(id.Value);
            if (travelVoucher == null)
                throw new ValidationException("Путевка не найден", "");

            return new ProfileTravelVoucher {
                Country = travelVoucher.Country,
                Arrival = travelVoucher.Arrival,
                Departure = travelVoucher.Departure,
                Price = travelVoucher.Price,
                ServicesId = travelVoucher.ServicesId,
                HotelId = travelVoucher.HotelId,
                StaffId = travelVoucher.StaffId,
                UserId = travelVoucher.Id,
            };
        }

        public IEnumerable<ProfileTravelVoucher> GetTravelVouchers()
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<TravelVoucher, ProfileTravelVoucher>()).CreateMapper();
            return mapper.Map<IEnumerable<TravelVoucher>, List<ProfileTravelVoucher>>(repoTravelVoucher.GetAll());
        }

        public void MakeOrder(ProfileTravelVoucher profileTravelVoucher,ProfileUser profileUser)
        {
            //var user = repoUser.Get(profileUser.Id);

            // валидация
            if (profileUser == null)
                throw new ValidationException("Пользователь не найден", "");
           
            var order = new ProfileTravelVoucher
            {
                Country = profileTravelVoucher.Country ,
                Arrival = profileTravelVoucher.Arrival,
                Departure = profileTravelVoucher.Departure,
                Price = profileTravelVoucher.Price,
                ServicesId = profileTravelVoucher.ServicesId,
                HotelId = profileTravelVoucher.HotelId,
                StaffId = profileTravelVoucher.StaffId,
                UserId = profileUser.Id,
            };
           // repoTravelVoucher.Create(order);
            repoTravelVoucher.Save();
        }

        public void Create(TravelVoucher item)
        {
            if (item == null)
            {
                throw new ValidationException("Пустой объект ", "");
            }
            else
            {
                repoTravelVoucher.Create(item);
                Save();
            }
        }

        public void Update(TravelVoucher item)
        {
            if (item == null)
            {
                throw new ValidationException("Пустой объект ", "");
            }
            else
            {
                repoTravelVoucher.Update(item);
                Save();
            }
        }

        public void Delete(TravelVoucher item)
        {
            if (item == null)
            {
                throw new ValidationException("Пустой объект ", "");
            }
            else
            {
                repoTravelVoucher.Delete(item);
                Save();
            }
        }

        public void Save()
        {
            repoTravelVoucher.Save();
        }
    }
}
