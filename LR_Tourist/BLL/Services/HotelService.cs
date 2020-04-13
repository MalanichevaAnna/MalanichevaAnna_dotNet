using AutoMapper;
using BLL.Interfaces;
using BLL.Model;
using DA.Data;
using DA.Services.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class HotelService : IService<Hotel>,ICRUDService<Hotel>
    {
        private readonly IRepository<HotelDTO> repoHotel;

        private readonly IMapper _mapper;

        public HotelService(IRepository<HotelDTO> repositoryHotel, IMapper mapper)
        {
            repoHotel = repositoryHotel;
            _mapper = mapper;
        }

        public async Task<Hotel> GetItem(int id)
        {
            var hotel = await repoHotel.Get(id);
            if (hotel == null)
            {
                throw new ArgumentException("Hotel not found");
            }

            return new Hotel
            {
                Id = hotel.Id,
                Name = hotel.Name,
                Star = hotel.Star,
                Phone = hotel.Phone,
            };
        }

        public async Task<IEnumerable<Hotel>> GetItems()
        {
              return _mapper.Map<IEnumerable<HotelDTO>, List<Hotel>>( await repoHotel.GetAll());
        }

        public async Task Create(Hotel item)
        {
            if(item == null)
            {
                throw new ArgumentNullException(nameof(item));
            }
            else
            {
                await repoHotel.Create(_mapper.Map<HotelDTO>(item));
            }
        }

        public async Task Update(Hotel item)
        {
            if (item == null)
            {
                throw new ArgumentNullException(nameof(item));
            }
            else
            {
                await repoHotel.Update(_mapper.Map<HotelDTO>(item));
            }
        }
        public async Task Delete(int id)
        {
            var item = GetItems().Result.Where(el => el.Id == id).ToList();
            if (item == null)
            {
                throw new ArgumentNullException(nameof(item));
            }
            else
            {
                await repoHotel.Delete(_mapper.Map<HotelDTO>(item[0]).Id);
            }
        }
    }
}
