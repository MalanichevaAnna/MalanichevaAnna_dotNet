using AutoMapper;
using BLL.Interfaces;
using BLL.Model;
using DA.Data;
using DA.Services.Repository;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BLL.Services
{
    public class HotelService : IService<HotelDTO>,ICRUDService<HotelDTO>
    {
        IRepository<Hotel> repoHotel { get; set; }
        private readonly IMapper _mapper;

        public HotelService(IRepository<Hotel> repositoryHotel, IMapper mapper)
        {
            repoHotel = repositoryHotel;
            _mapper = mapper;
        }

        public HotelDTO GetItem(int? id)
        {
            if (id == null)
            {
                throw new ArgumentException("Not installed id");
            }

            var hotel = repoHotel.Get(id.Value);

            if (hotel == null)
            {
                throw new ArgumentException("Services not found");
            }

            return new HotelDTO
            {
                Id = hotel.Id,
                NameHotel = hotel.NameHotel,
                Star = hotel.Star,
                Phone = hotel.Phone,
            };

        }

        public IEnumerable<HotelDTO> GetItems()
        {
              return _mapper.Map<IEnumerable<Hotel>, List<HotelDTO>>(repoHotel.GetAll());
        }

        public void Create(HotelDTO item)
        {
            if(item == null)
            {
                throw new ArgumentNullException(nameof(item));
            }
            else
            {
                repoHotel.Create(_mapper.Map<Hotel>(item));
                Save();
            }
        }

        public void Update(HotelDTO item)
        {
            if (item == null)
            {
                throw new ArgumentNullException(nameof(item));
            }
            else
            {
                repoHotel.Update(_mapper.Map<Hotel>(item));
                Save();
            }
        }
        public void Delete(int id)
        {
            var item = GetItems().Where(el => el.Id == id).ToList();
            if (item == null)
            {
                throw new ArgumentNullException(nameof(item));
            }
            else
            {
                repoHotel.Delete(_mapper.Map<Hotel>(item[0]).Id);
                Save();
            }
        }
        public void Save()
        {
            repoHotel.Save();
        }
    }
}
