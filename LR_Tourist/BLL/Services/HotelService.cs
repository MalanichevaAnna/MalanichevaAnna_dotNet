using AutoMapper;
using BLL.Interfaces;
using BLL.Model;
using BLL.ValidException;
using DA.Data;
using DA.Repository;
using System;
using System.Collections.Generic;

namespace BLL.Services
{
    public class HotelService : IService<ProfileHotel>,ICRUDService<Hotel>
    {
        IRepository<Hotel> repoHotel { get; set; }

        HotelService(IRepository<Hotel> repositoryHotel)
        {
            repoHotel = repositoryHotel;
        }

        public ProfileHotel GetItem(int? id)
        {
            if (id == null)
            {
                throw new ValidationException("Не установлено id отеля ", "");
            }

            var hotel = repoHotel.Get(id.Value);

            if (hotel == null)
            {
                throw new ValidationException("Услуга не найден", "");
            }

            return new ProfileHotel
            {
                Id = hotel.Id,
                NameHotel = hotel.NameHotel,
                Star = hotel.Star,
                Phone = hotel.Phone,
            };

        }

        public IEnumerable<ProfileHotel> GetItems()
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<Hotel, ProfileHotel>()).CreateMapper();
            return mapper.Map<IEnumerable<Hotel>, List<ProfileHotel>>(repoHotel.GetAll());
        }

        public void Create(Hotel item)
        {
            if(item == null)
            {
                throw new ValidationException("Пустой объект ", "");
            }
            else
            {
                repoHotel.Create(item);
                Save();
            }
        }

        public void Update(Hotel item)
        {
            if (item == null)
            {
                throw new ValidationException("Пустой объект ", "");
            }
            else
            {
                repoHotel.Update(item);
                Save();
            }
        }

        public void Delete(Hotel item)
        {
            if (item == null)
            {
                throw new ValidationException("Пустой объект ", "");
            }
            else
            {
                repoHotel.Delete(item);
                Save();
            }
        }

        public void Save()
        {
            repoHotel.Save();
        }
    }
}
