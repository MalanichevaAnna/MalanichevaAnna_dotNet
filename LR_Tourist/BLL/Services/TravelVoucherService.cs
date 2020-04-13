﻿using AutoMapper;
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
    public class TravelVoucherService : ITravelVoucherService, ICRUDService<TravelVoucher>
    {
        IRepository<UserDTO> repoUser { get; set; }

        IRepository<HotelDTO> repoHotel { get; set; }

        IRepository<StaffDTO> repoStaff { get; set; }

        IRepository<ServiceDTO> repoService { get; set; }

        IRepository<TravelVoucherDTO> repoTravelVoucher { get; set; }
        
        private readonly IMapper _mapper;
        
        public TravelVoucherService(IRepository<UserDTO> repositoryUser,
                                    IRepository<TravelVoucherDTO> repositoryTravelVoucher, 
                                    IRepository<StaffDTO> repositoryStaff,
                                    IRepository<ServiceDTO> repositoryService,
                                    IRepository<HotelDTO> repositoryHotel,
                                    IMapper mapper)
        {
            repoUser = repositoryUser;
            repoTravelVoucher = repositoryTravelVoucher;
            repoStaff = repositoryStaff;
            repoService = repositoryService;
            repoHotel = repositoryHotel;
            _mapper = mapper;
        }
        public async Task<TravelVoucher> GetTravelVoucher(int id)
        {
            var travelVoucher = await repoTravelVoucher.Get(id);
            if (travelVoucher == null)
            {
                throw new ArgumentNullException(nameof(travelVoucher));
            }

            return new Model.TravelVoucher {
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

        public async Task<IEnumerable<TravelVoucher>> GetTravelVouchers()
        {
            return _mapper.Map<IEnumerable<TravelVoucherDTO>, List<TravelVoucher>>(await repoTravelVoucher.GetAll());
        }

        public async Task MakeOrder(int idTravelVoucher,int idUser)
        {
            var user = await repoUser.Get(idUser);
            var travelVoucher = await repoTravelVoucher.Get(idTravelVoucher);
            if (user == null)
            {
                throw new ArgumentException("user not found");
            }
            else if(travelVoucher == null)
            {
                throw new ArgumentException("Travel voucher not found", "");
            }
            travelVoucher.UserId = user.Id;
            await Update(_mapper.Map <TravelVoucher>(travelVoucher));
        }

        public async Task Create(TravelVoucher item)
        {
            if (item == null)
            {
                throw new ArgumentNullException(nameof(item));
            }
            else
            {
                if (CheckId(item.StaffId, item.HotelId,item.ServicesId,item.UserId))
                {
                    throw new ArgumentException("Check id");
                }
                else
                {
                    await repoTravelVoucher.Create(_mapper.Map<TravelVoucherDTO>(item));
                }
            }
        }

        public bool CheckId(int idStaff,int idHotel,int idService,int idUser)
        {
            try
            {
                
                var staff = repoStaff.Get(idStaff);
                var service = repoService.Get(idService);
                var hotel = repoHotel.Get(idHotel);
                var user = repoUser.Get(idUser);
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

        public async Task Update(Model.TravelVoucher item)
        {
            if (item == null)
            {
                throw new ArgumentNullException(nameof(item));
            }
            else
            {
                if (CheckId(item.StaffId, item.HotelId, item.ServicesId, item.UserId))
                {
                    throw new ArgumentException("Check id");
                }
                await repoTravelVoucher.Update(_mapper.Map<DA.Data.TravelVoucherDTO>(item));
            }
        }
        public async Task Delete(int id)
        {
            var item = GetTravelVouchers().Result.Where(el => el.Id == id).ToList();
            if (item == null)
            {
                throw new ArgumentNullException(nameof(item));
            }
            else
            {
                await repoTravelVoucher.Delete(_mapper.Map<DA.Data.TravelVoucherDTO>(item[0]).Id);
            }
        }
    }
}
