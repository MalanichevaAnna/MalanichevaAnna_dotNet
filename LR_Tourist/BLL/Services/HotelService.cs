using AutoMapper;
using BLL.Interfaces;
using BLL.Model;
using BLL.ValidException;
using DA.Data;
using DA.Services.Repository;
using System.Collections.Generic;

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
                throw new ValidationException("Не установлено id отеля ", "");
            }

            var hotel = repoHotel.Get(id.Value);

            if (hotel == null)
            {
                throw new ValidationException("Услуга не найден", "");
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
                throw new ValidationException("Пустой объект ", "");
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
                throw new ValidationException("Пустой объект ", "");
            }
            else
            {
                repoHotel.Update(_mapper.Map<Hotel>(item));
                Save();
            }
        }

        public void Delete(HotelDTO item)
        {
            if (item == null)
            {
                throw new ValidationException("Пустой объект ", "");
            }
            else
            {
                repoHotel.Delete(_mapper.Map<Hotel>(item));
                Save();
            }
        }

        public void Save()
        {
            repoHotel.Save();
        }
    }
}
