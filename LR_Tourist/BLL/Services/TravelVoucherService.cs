using AutoMapper;
using BLL.Interfaces;
using BLL.Model;
using BLL.ValidException;
using DA.Data;
using DA.Services.Repository;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BLL.Services
{
    public class TravelVoucherService : ITravelVoucher, ICRUDService<Model.TravelVoucherDTO>
    {
        IRepository<User> repoUser { get; set; }

        IRepository<Hotel> repoHotel { get; set; }

        IRepository<Staff> repoStaff { get; set; }

        IRepository<DA.Data.Services> repoService { get; set; }

        IRepository<DA.Data.TravelVoucher> repoTravelVoucher { get; set; }
        
        private readonly IMapper _mapper;
        
        public TravelVoucherService(IRepository<User> repositoryUser,
                                    IRepository<DA.Data.TravelVoucher> repositoryTravelVoucher, 
                                    IRepository<Staff> repositoryStaff,
                                    IRepository<DA.Data.Services> repositoryService,
                                    IRepository<Hotel> repositoryHotel,
                                    IMapper mapper)
        {
            repoUser = repositoryUser;
            repoTravelVoucher = repositoryTravelVoucher;
            repoStaff = repositoryStaff;
            repoService = repositoryService;
            repoHotel = repositoryHotel;
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

        public void MakeOrder(int idTravelVoucher,int idUser)
        {
            var user = repoUser.Get(idUser);
            var travelVoucher = repoTravelVoucher.Get(idTravelVoucher);
            // валидация
            if (user == null)
            {
                throw new ValidationException("Пользователь не найден", "");
            }
            else if(travelVoucher == null)
            {
                throw new ValidationException("Travel voucher not found", "");
            }

            travelVoucher.UserId = user.Id;
            Update(_mapper.Map <TravelVoucherDTO>(travelVoucher));
            repoTravelVoucher.Save();
        }

        public void Create(Model.TravelVoucherDTO item)
        {
            if (item == null)
            {
                throw new ArgumentNullException(nameof(item));
            }
            else
            {
                
                if (CheckId(item.StaffId, item.HotelId,item.ServicesId))
                {
                    throw new ArgumentException("Check id");
                }
                else
                {
                    repoTravelVoucher.Create(_mapper.Map<DA.Data.TravelVoucher>(item));
                }
                Save();
            }
        }

        public bool CheckId(int idStaff,int idHotel,int idService)
        {
            try
            {
                
                var staff = repoStaff.Get(idStaff);
                var service = repoService.Get(idService);
                var hotel = repoHotel.Get(idHotel);
                if(staff == null || service == null || hotel == null)
                {
                    return true;
                }
                return false;
            }
            catch
            {
                throw new ArgumentException("Check id");
            }
        }

        public void Update(Model.TravelVoucherDTO item)
        {
            if (item == null)
            {
                throw new ArgumentNullException(nameof(item));
            }
            else
            {
                if (CheckId(item.StaffId, item.HotelId, item.ServicesId))
                {
                    throw new ArgumentException("Check id");
                }
                repoTravelVoucher.Update(_mapper.Map<DA.Data.TravelVoucher>(item));
                Save();
            }
        }

        public void Delete(Model.TravelVoucherDTO item)
        {
            if (item == null)
            {
                throw new ArgumentNullException(nameof(item));
            }
            else
            {
                repoTravelVoucher.Delete(_mapper.Map<DA.Data.TravelVoucher>(item));
                Save();
            }
        }
        public void Delete(int id)
        {
            var item = GetTravelVouchers().Where(el => el.Id == id).ToList();
            if (item == null)
            {
                throw new ArgumentNullException(nameof(item));
            }
            else
            {
                repoTravelVoucher.Delete(_mapper.Map<TravelVoucher>(item[0]).Id);
                Save();
            }
        }
        public void Save()
        {
            repoTravelVoucher.Save();
        }
    }
}
