using AutoMapper;
using BLL.Interfaces;
using BLL.Model;
using BLL.ValidException;
using DA.Data;
using DA.Services.Repository;
using System.Collections.Generic;

namespace BLL.Services
{
    public class TravelVoucherService : ITravelVoucher, ICRUDService<Model.TravelVoucherDTO>
    {
        IRepository<User> repoUser { get; set; }
        private readonly IMapper _mapper;

        IRepository<DA.Data.TravelVoucher> repoTravelVoucher { get; set; }
        public TravelVoucherService(IRepository<User> repositoryUser, IRepository<DA.Data.TravelVoucher> repositoryTravelVoucher, IMapper mapper)
        {
            repoUser = repositoryUser;
            repoTravelVoucher = repositoryTravelVoucher;
            _mapper = mapper;
        }
        public TravelVoucherDTO GetTravelVoucher(int? id)
        {
            if (id == null)
                throw new ValidationException("Не установлено id путевки ", "");
            var travelVoucher = repoTravelVoucher.Get(id.Value);
            if (travelVoucher == null)
                throw new ValidationException("Путевка не найден", "");

            return new TravelVoucherDTO {
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

        public IEnumerable<Model.TravelVoucherDTO> GetTravelVouchers()
        {
            return _mapper.Map<IEnumerable<TravelVoucher>, List<TravelVoucherDTO>>(repoTravelVoucher.GetAll());
        }

        public void MakeOrder(Model.TravelVoucherDTO profileTravelVoucher,UserDTO profileUser)
        {
            //var user = repoUser.Get(profileUser.Id);

            // валидация
            if (profileUser == null)
                throw new ValidationException("Пользователь не найден", "");
           
            var order = new Model.TravelVoucherDTO
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

        public void Create(Model.TravelVoucherDTO item)
        {
            if (item == null)
            {
                throw new ValidationException("Пустой объект ", "");
            }
            else
            {
                repoTravelVoucher.Create(_mapper.Map<DA.Data.TravelVoucher>(item));
                Save();
            }
        }

        public void Update(Model.TravelVoucherDTO item)
        {
            if (item == null)
            {
                throw new ValidationException("Пустой объект ", "");
            }
            else
            {
                repoTravelVoucher.Update(_mapper.Map<DA.Data.TravelVoucher>(item));
                Save();
            }
        }

        public void Delete(Model.TravelVoucherDTO item)
        {
            if (item == null)
            {
                throw new ValidationException("Пустой объект ", "");
            }
            else
            {
                repoTravelVoucher.Delete(_mapper.Map<DA.Data.TravelVoucher>(item));
                Save();
            }
        }

        public void Save()
        {
            repoTravelVoucher.Save();
        }
    }
}
